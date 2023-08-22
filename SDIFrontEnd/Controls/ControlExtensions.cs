using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDIFrontEnd
{
    public static class ControlExtensions
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        //Method used agains flickering
        public static void Suspend(this Control control)
        {
            LockWindowUpdate(control.Handle);
        }

        public static void Resume(this Control control)
        {
            LockWindowUpdate(IntPtr.Zero);
        }

        public static void SetVirtualGridRows(this DataGridView dgv, int rowCount)
        {
            dgv.AllowUserToAddRows = false;
            dgv.RowCount = 0;
            dgv.AllowUserToAddRows = true;
            dgv.RowCount = rowCount;
        }

        public static void AddAndSelect(this ComboBox cbo, string item)
        {
            if (item == null)
                return;

            if (!cbo.Items.Contains(item))
                cbo.Items.Insert(0, item);

            cbo.SelectedItem = item;
        }

    }
}
