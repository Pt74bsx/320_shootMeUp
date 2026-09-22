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
    public partial class CreditSpace : Form
    {
        public CreditSpace()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Au clic du bouton 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_out_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();                                                        // Masque la fenêtre de crédit
            SpaceManager.Home.Show();                                           // Affiche la fenêtre d'accueil
        }

        /// <summary>
        /// Survole de la souris 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_out_MouseHover(object sender, EventArgs e)
        {
            btn_out.BackgroundImage = Properties.Resources.btn_over_out;        // Image au survol 
        }

        /// <summary>
        /// Sortie du survol de la souris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_out_MouseLeave(object sender, EventArgs e)
        {
            btn_out.BackgroundImage = Properties.Resources.btn_out;             // Image d'origine 
        }
    }
}
