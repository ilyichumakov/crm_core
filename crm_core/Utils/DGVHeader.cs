using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace crm_core
{
    public static class DGVHeader
    {
        public static void header<T>(this DataGridView dgv)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                bool implementICollection = prop.PropertyType.GetInterfaces().Any(
                    x => x.IsGenericType &&
                    x.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                );
                bool implementsClone = prop.PropertyType.GetInterfaces().Any(
                    x => x == typeof(ICloneable)
                );

                if (implementICollection && !implementsClone)
                    continue;

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
