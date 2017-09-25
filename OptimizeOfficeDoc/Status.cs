using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimizeOfficeDoc
{
    public static class Status
    {
        private static ToolStripStatusLabel ctlStatus;
        private static ToolStripProgressBar ctlProgressBar;

        public static void Initialize(ToolStripStatusLabel ctlStatus, 
            ToolStripProgressBar ctlProgressBar)
        {
            Status.ctlStatus = ctlStatus;
            Status.ctlProgressBar = ctlProgressBar;
            Reset();
        }

        public static void Reset()
        {
            ctlStatus.Text = "Idle.";
            ctlProgressBar.Value = 0;
        }

        public static void SetStatus(string Message, int? NewProgressValue = null)
        {
            ctlStatus.Text = Message;
            if (NewProgressValue != null)
            {
                SetProgress((int)NewProgressValue);
            }
        }

        public static void SetProgress(int Value)
        {
            ctlProgressBar.Value = Value;
        }
        
    }
}
