using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui.Admin
{
    public static class FormHelper
    {
        private static readonly Form mainForm;
        public static Form MainForm
        {
            get { return mainForm; }
        }

        static FormHelper()
        {
            mainForm = new MainForm();
        }
    }
}
