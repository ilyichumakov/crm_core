using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;
using crm_core.Forms;

namespace crm_core
{
    public partial class ListForm : Form
    {
        public const string CLIENTS = "CLIENTS";
        public const string LEADS = "LEADS";
        public const string ORDERS = "ORDERS";
        public const string BILLS = "BILLS";
        public const string DOCUMENTS = "DOCUMENTS";
        public const string GOODS = "GOODS";
        public const string SERVICES = "SERVICES";
        public const string STAFF = "STAFF";

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
        private event Paginator paginate;
        public void Notify(int parameter)
        {
            paginate?.Invoke(parameter);
        }
        
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
                this.Notify(target);
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
                    {DOCUMENTS, "Документы" },
                    {GOODS, "Товары" },
                    {SERVICES, "Услуги" },
                    {STAFF, "Сотрудники" },
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
                if (prop.Name == "Id")
                    props.Insert(0, prop);
                else
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

        private void show_edit_form(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView table = data_panel.Controls[0] as DataGridView;
            DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell) table.Rows[e.RowIndex].Cells[e.ColumnIndex];
            int pk = Int32.Parse(table.Rows[e.RowIndex].Cells[0].Value.ToString());
            object item;

            try
            {
                using (crmContext db = new crmContext())
                {
                    switch (State)
                    {
                        case LEADS:
                           item = db.Leads.Find(pk);
                            break;
                        case CLIENTS:
                            item = db.NaturalPerson.Find(pk);
                            break;
                        case ORDERS:
                            item = db.Deals.Find(pk);
                            break;
                        case BILLS:
                            item = db.Bills.Find(pk);
                            break;
                        case DOCUMENTS:
                            item = db.Documents.Find(pk);
                            break;
                        case GOODS:
                            item = db.Goods.Find(pk);
                            break;
                        case SERVICES:
                            item = db.Services.Find(pk);
                            break;
                        case STAFF:
                            item = db.Staff.Find(pk);
                            break;
                        default:
                            item = "Not found";
                            break;
                    }
                }
            }
            catch (InvalidOperationException)
            {
                var res = MessageBox.Show("Сервер недоступен", "Сетевые неполадки", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (res == DialogResult.Cancel)
                {
                    Owner.Dispose();
                }
                return;
            }
            EditForm edit_form = new EditForm();
            edit_form.init_values(item);
            edit_form.ShowDialog(this);
        }

        private void load_data(int page = 1)
        {
            try
            {
                DataGridView table = new DataGridView();
                clear_form();
                table.AutoSize = true;
                table.ReadOnly = true;
                table.CellClick += show_edit_form;
                
                List<object[]> rows;

                using (crmContext db = new crmContext())
                {
                    switch (State)
                    {
                        case LEADS:
                            _pages = db.Leads.Count();
                            var leads_list = db.Leads.OrderByDescending(
                                    l => l.DtUpdated
                                ).Skip(
                                    (page - 1) * _page_size
                                ).Take(
                                    _page_size
                                ).ToList();

                            table.header<Leads>();
                            rows = iterate_data(leads_list);
                            break;
                        case CLIENTS:
                            _pages = db.NaturalPerson.Count();
                            var client_list = db.NaturalPerson.OrderByDescending(
                                    p => p.DtUpdated
                                ).Skip(
                                    (page - 1) * _page_size
                                ).Take(
                                    _page_size
                                ).ToList();

                            table.header<NaturalPerson>();
                            rows = iterate_data(client_list);
                            break;
                        case ORDERS:
                            _pages = db.Deals.Count();
                            var order_list = db.Deals.OrderByDescending(
                                    d => d.DtUpdated
                                ).Skip(
                                    (page - 1) * _page_size
                                ).Take(
                                    _page_size
                                ).ToList();

                            table.header<Deals>();
                            rows = iterate_data(order_list);
                            break;
                        case BILLS:
                            _pages = db.Bills.Count();
                            var bill_list = db.Deals.OrderByDescending(
                                    b => b.DtUpdated
                                ).Skip(
                                    (page - 1) * _page_size
                                ).Take(
                                    _page_size
                                ).ToList();

                            table.header<Bills>();
                            rows = iterate_data(bill_list);
                            break;
                        case DOCUMENTS:
                            _pages = db.Documents.Count();
                            var doc_list = db.Documents.OrderByDescending(
                                    doc => doc.DtUpdated
                                ).Skip(
                                    (page - 1) * _page_size
                                ).Take(
                                    _page_size
                                ).ToList();

                            table.header<Documents>();
                            rows = iterate_data(doc_list);
                            break;
                        case GOODS:
                            _pages = db.Goods.Count();
                            var goods_list = db.Goods.OrderByDescending(
                                    good => good.DtUpdated
                                ).Skip(
                                    (page - 1) * _page_size
                                ).Take(
                                    _page_size
                                ).ToList();

                            table.header<Goods>();
                            rows = iterate_data(goods_list);
                            break;
                        case SERVICES:
                            _pages = db.Services.Count();
                            var service_list = db.Services.OrderByDescending(
                                    srv => srv.DtUpdated
                                ).Skip(
                                    (page - 1) * _page_size
                                ).Take(
                                    _page_size
                                ).ToList();

                            table.header<Services>();
                            rows = iterate_data(service_list);
                            break;
                        case STAFF:
                            _pages = db.Staff.Count();
                            var staff_list = db.Staff.OrderByDescending(
                                    srv => srv.DtUpdated
                                ).Skip(
                                    (page - 1) * _page_size
                                ).Take(
                                    _page_size
                                ).ToList();

                            table.header<Staff>();
                            rows = iterate_data(staff_list);
                            break;
                        default:
                            _pages = 1;
                            rows = new List<object[]>();
                            break;
                    }
                }

                foreach (object[] row in rows)
                {
                    table.Rows.Add(row);
                }
                data_panel.Controls.Add(table);
                pages_label.Text = $"{_page}/{_pages}";
            }
            catch (InvalidOperationException)
            {
                var res = MessageBox.Show("Сервер недоступен", "Сетевые неполадки", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (res == DialogResult.Cancel)
                {
                    Owner.Dispose();
                }
                return;
            }            
        }

        public ListForm( Form1 owner)
        {
            InitializeComponent();
            Owner = owner;
            paginate += load_data;
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

        private void next_page_Click(object sender, EventArgs e)
        {
            Page += 1;
        }

        private void prev_page_Click(object sender, EventArgs e)
        {
            Page -= 1;
        }

        private void ListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Dispose();
        }
    }
}
