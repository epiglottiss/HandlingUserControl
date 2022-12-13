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
    public class DataEventArgs : EventArgs
    {
        public DataEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }

    public partial class Form1 : Form
    {
        int n;

        

        public event EventHandler<DataEventArgs> measureEvent;

        private async Task OnRaiseEvent(DataEventArgs e)
        {
            var eventHandler = measureEvent;
            if (measureEvent != null)
            {
                var task = Task.Run(() => eventHandler(this, e));
                listBox1.Items.Insert(0, "event sent.");
                await task;
            }

            listBox1.Items.Insert(0, "OnRaiseEvent end.");
        }

        public Form1()
        {
            InitializeComponent();
            n = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(n.ToString(), n.ToString());
            uscTest test = new uscTest(this);
            test.Dock = DockStyle.Fill;
            

            tabControl1.TabPages[n.ToString()].Controls.Add(test);
            n++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            n--; 
            tabControl1.TabPages.RemoveByKey(n.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            ListBox lbox = (ListBox)tabControl1.TabPages[(n-1).ToString()].Controls[0].Controls[0];
            this.Invoke(new Action(delegate ()
            {
                lbox.Items.Insert(0, "newLine");
            }));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OnRaiseEvent(new DataEventArgs("message"));
        }
    }
}
