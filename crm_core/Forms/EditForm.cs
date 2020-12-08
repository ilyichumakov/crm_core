using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;

namespace crm_core.Forms
{
    public partial class EditForm : Form
    {
        private List<PropertyInfo> props;
        private object Item;
        public EditForm()
        {
            InitializeComponent();
        }

        public void init_values<T>(T Item)
        {
            this.Item = Item;            
            props = new List<PropertyInfo>(Item.GetType().GetProperties());
            panel_inputs.Controls.Clear();            
            const int INPUT_HEIGHT = 20;
            const int INPUT_WIDTH = 150;
            int y_offset = 10 + INPUT_HEIGHT;
            foreach (PropertyInfo property in props)
            {
                bool implementICollection = property.PropertyType.GetInterfaces().Any(
                    x => x.IsGenericType &&
                    x.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                );
                bool implementsClone = property.PropertyType.GetInterfaces().Any(
                    x => x == typeof(ICloneable)
                );

                if (implementICollection && !implementsClone)
                    continue;

                TextBox inpt = new TextBox();
                Label label = new Label();

                inpt.Name = property.Name + "_inpt";
                label.Name = property.Name + "_lbl";
                label.Text = property.Name;
                var value = property.GetValue(Item, null);
                if (value is null)
                {
                    inpt.Text = String.Empty;
                }
                else
                {
                    inpt.Text = value.ToString();
                }                

                inpt.Size = new Size(INPUT_WIDTH, INPUT_HEIGHT);
                inpt.Location = new Point(10, y_offset);
                label.Location = new Point(25 + INPUT_WIDTH, y_offset);
                y_offset += INPUT_HEIGHT;

                panel_inputs.Controls.Add(inpt);
                panel_inputs.Controls.Add(label);
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
