using ShootMeUp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShootMeUp
{
    public partial class HomeSpace : Form
    {
        public HomeSpace()
        {
            InitializeComponent();

        }

        private void btnLeave_MouseHover(object sender, EventArgs e)
        {
            btnLeave.BackgroundImage = Resources.btn_over_leave;
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {

        }
    }
}
