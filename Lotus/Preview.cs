using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotus
{
    public partial class Preview : Form
    {
        public Preview()
        {
           
            InitializeComponent();
        }

        private void Preview_Load(object sender, EventArgs e)
        {
          //   this.Location = new Point((int)((Screen.AllScreens[0].Bounds.Width/2 - (this.Width/2)) * 1.9), (int)((Screen.AllScreens[0].Bounds.Height/2  - (this.Height/2)) * 1.9));
            //  this.WindowState = FormWindowState.Maximized;
        }
    }
}
