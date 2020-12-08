using System.Windows.Forms;
using System.Collections.Generic;

namespace crm_core
{
    public static class DGVHeader
    {
        public static void header<T>(this DataGridView dgv)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.Name == "Id")
                {
                    var col = new DataGridViewTextBoxColumn();
                    col.HeaderText = prop.Name;
                    col.Name = prop.Name;
                    dgv.Columns.Insert(0, col);
                }
                else {
                    dgv.Columns.Add(prop.Name, prop.Name);
                }
            }
        }
    }
}
