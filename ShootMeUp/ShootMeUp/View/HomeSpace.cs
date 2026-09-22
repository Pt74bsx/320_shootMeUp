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

        private void btnCredit_Click(object sender, EventArgs e)
        {
            this.Hide();                        // Masque la fenêtre d'accueil
            SpaceManager.Credit.Show();         // Affiche la fenêtre de crédit
        }

        private void btnCredit_MouseHover(object sender, EventArgs e)
        {
            btnCredit.BackgroundImage = Properties.Resources.btn_over_credit;        // Image au survol 
        }

        private void btnCredit_MouseLeave(object sender, EventArgs e)
        {
            btnCredit.BackgroundImage = Properties.Resources.btn_credit;             // Image d'origine 
        }

        private void btnLeave_MouseHover(object sender, EventArgs e)
        {
            btnLeave.BackgroundImage = Properties.Resources.btn_over_leave;          // Image au survol 
        }

        private void btnLeave_MouseLeave(object sender, EventArgs e)
        {
            btnLeave.BackgroundImage = Properties.Resources.btn_leave;               // Image d'origine 
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlay_MouseHover(object sender, EventArgs e)
        {
            btnPlay.BackgroundImage = Properties.Resources.btn_over_play;          // Image au survol 
        }

        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            btnPlay.BackgroundImage = Properties.Resources.btn_play;               // Image d'origine 
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Hide();                        // Masque la fenêtre d'accueil
            SpaceManager.Game.Show();           // Affiche la fenêtre de jeux
        }
    }
}
