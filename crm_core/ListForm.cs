using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;

namespace crm_core
{
    public partial class ListForm : Form
    {
        public const string CLIENTS = "CLIENTS";
        public const string LEADS = "LEADS";
        public const string ORDERS = "ORDERS";
        public const string BILLS = "BILLS";
        public const string DOCUMENTS = "DOCUMENTS";
        private int _page_size = 50;
        public int PageSize { 
            get
            {
                return _page_size;
            } 
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Выберите положительное количество элементов на странице");
                }
                if (value > 500)                
                    _page_size = 500;                
                else
                    _page_size = value;
            }
        }

        private int _page = 1;
        private int _pages = 1;
        public int Page
        {
            get
            {
                return _page;
            }
            set
            {
                int target = 1;
                if (value > 0)
                    target = value;
                if (target > _pages)
                    target = _pages;
                _page = target;
            }
        }
        public Dictionary<string, string> state_choices { 
            get
            {
                return new Dictionary<string, string>()
                {
                    {CLIENTS, "Клиенты" },
                    {LEADS, "Лиды" },
                    {ORDERS, "Заказы" },
                    {BILLS, "Счета" },
                    {DOCUMENTS, "Документы" }
                };
            } 
        }
        private string _state;

        public string State
        {
            get 
            {
                return _state;
            }
            set
            {
                if(!state_choices.ContainsKey(value))
                {
                    throw new ArgumentException("Unknown state");
                }
                _state = value;
                Text = state_choices[value];
                load_data();
                var owner = Owner as Form1;
                owner.child_ready();
            }
        }

        private void clear_form()
        {
            data_panel.Controls.Clear();
        }

        private List<object[]> iterate_data<T>(List<T> query)
        {
            List<object[]> result = new List<object[]>();
            List<PropertyInfo> props = new List<PropertyInfo>();

            foreach (var prop in typeof(T).GetProperties())
            {
                props.Add(prop);
            }

            foreach (T item in query)
            {
                List<object> values = new List<object>();
                foreach (var prop in props)
                {
                    values.Add(prop.GetValue(item, null));
                }
                result.Add(values.ToArray());
            }

            return result;
        }

        private void load_data()
        {
            try
            {
                DataGridView table = new DataGridView();
                clear_form();
                table.AutoSize = true;
                List<object[]> rows;

                using (crmContext db = new crmContext())
                {
                    switch (State)
                    {
                        case LEADS:
                            var leads_list = db.Leads.OrderByDescending(l => l.DtUpdated).Take(50).ToList();
                            table.header<Leads>();
                            rows = iterate_data(leads_list);
                            break;
                        case CLIENTS:                            
                            var client_list = db.NaturalPerson.OrderByDescending(p => p.DtUpdated).Take(50).ToList();
                            table.header<NaturalPerson>();
                            rows = iterate_data(client_list);
                            break;
                        default:
                            rows = new List<object[]>();
                            break;
                    }
                }

                foreach (object[] row in rows)
                {
                    table.Rows.Add(row);
                }
                data_panel.Controls.Add(table);

            }
            catch (InvalidOperationException)
            {
                var res = MessageBox.Show("Сервер недоступен", "Сетевые неполадки", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (res == DialogResult.Cancel)
                {
                    Owner.Dispose();
                }
            }            
        }

        public ListForm( Form1 owner)
        {
            InitializeComponent();
            Owner = owner;            
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            var groups = menuStrip1.Items["toolStripComboBox1"] as ToolStripComboBox;      
            var states = state_choices;
            groups.Items.AddRange(states.Values.ToArray());
            
            groups.SelectedIndex = 0;
            groups.SelectedIndexChanged += changed_menu_category;
        }

        private void changed_menu_category(object sender, EventArgs e)
        {
            var groups = menuStrip1.Items["toolStripComboBox1"] as ToolStripComboBox;
            State = state_choices.FirstOrDefault(x => x.Value == groups.Text).Key;
        }
    }
}
