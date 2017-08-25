using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Route66
{
    public partial class SPLASH : Form
    {
        public SPLASH()
        {
            
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            progressBar1.Refresh();
            if (progressBar1.Value == 10) timer1.Stop();
        }
    }
}
