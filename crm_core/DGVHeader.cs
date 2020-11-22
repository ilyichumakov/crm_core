using System.Windows.Forms;

namespace crm_core
{
    public static class DGVHeader
    {
        public static void header<T>(this DataGridView dgv)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                dgv.Columns.Add(prop.Name, prop.Name);
            }
        }
    }
}
