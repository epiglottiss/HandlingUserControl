using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormTest
{
    public partial class uscTest : UserControl
    {
        public uscTest()
        {
            InitializeComponent();
        }

        public uscTest(Form1 form) : this()
        {
            form.measureEvent += HandelEvent;
        }

        private void HandelEvent(object sender, DataEventArgs e)
        {
            listBox1.Items.Insert(0, e.Message);
        }
    }
}
