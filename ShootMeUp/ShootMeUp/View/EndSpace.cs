using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace ShootMeUp
{
    public partial class EndSpace : Form
    {
        public EndSpace()
        {
            InitializeComponent();

            new NavigationManager(this, new List<Button> { btnReplay, btnBackToHome });

            ResponsiveHelpers.ConfigureScreen(this);
        }

        /// <summary>
        /// Permet d'afficher le score 
        /// de la partie
        /// </summary>
        /// <param name="score"></param>
        public void SetScore(int score)
        {
            lblEndScore.Text = score.ToString();
        }

        // Action du bouton "Rejouer"
        private void btnReplay_Click(object sender, EventArgs e)
        {
            this.Hide();                        // Masque la fenêtre de fin
            SpaceManager.Game.ResetGame();      // Remet les valeurs du jeux par défaut
            SpaceManager.Game.Show();           // Affiche la fenêtre de jeux
        }

        // Action du bouton "Retourner à l'accueil"
        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            this.Hide();                        // Masque la fenêtre de fin
            SpaceManager.Game.ResetGame();      // Remet les valeurs du jeux par défaut 
            SpaceManager.Home.Show();           // Affiche la fenêtre d'accueil
        }
    }
}
