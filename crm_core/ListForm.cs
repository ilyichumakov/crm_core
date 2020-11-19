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

        private void load_data()
        {
            try
            {
                switch (State)
                {
                    case LEADS:                    
                        using (crmContext db = new crmContext())
                        {
                            var list = db.Leads.OrderByDescending(l => l.DtUpdated).Take(50).ToList();
                            clear_form();
                            DataGridView table = new DataGridView();
                            List<PropertyInfo> props = new List<PropertyInfo>();

                            foreach(var prop in typeof(Leads).GetProperties())
                            {
                                table.Columns.Add(prop.Name, prop.Name);
                                props.Add(prop);
                            }
                                
                            
                            data_panel.Controls.Add(table);

                            foreach (Leads l in list)
                            {
                                List<object> values = new List<object>();
                                foreach(var prop in props)
                                {
                                    values.Add(prop.GetValue(l, null));
                                }
                                table.Rows.Add(values.ToArray());
                            }
                        }
                        break;
                }
                
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

        public new void Dispose()
        {
            Owner.Dispose();
        }

    }
}
