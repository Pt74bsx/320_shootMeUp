using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShootMeUp
{
    internal class NavigationManager
    {
        // Réécrit avec l'aide de l'IA : navigation avec des boutons et événements nommés.
        private Form fenetre;
        private List<Button> boutons;
        private Button? boutonRetour;
        private bool curseurCache = false;

        public NavigationManager(Form fenetre, List<Button> boutons, Button? boutonRetour = null)
        {
            this.fenetre = fenetre;
            this.boutons = boutons;
            this.boutonRetour = boutonRetour;

            fenetre.KeyPreview = true;
            fenetre.KeyDown += TouchePressee;
            fenetre.MouseMove += SourisBouge;

            fenetre.VisibleChanged += FenetreVisibleChangee;
            fenetre.Deactivate += FenetreDesactivee;

            foreach (Button bouton in boutons)
            {
                bouton.PreviewKeyDown += AvantTouche;
                bouton.MouseMove += SourisBouge;
            }

            if (boutons.Count > 0)
                fenetre.ActiveControl = boutons[0];
        }

        private void FenetreVisibleChangee(object? sender, EventArgs e)
        {
            if (!fenetre.Visible)
            {
                AfficherCurseur();
            }
        }

        private void FenetreDesactivee(object? sender, EventArgs e)
        {
            AfficherCurseur();
        }

        private void AvantTouche(object? sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape ||
                e.KeyCode == Keys.Back)
            {
                e.IsInputKey = true;
            }
        }

        private void TouchePressee(object? sender, KeyEventArgs e)
        {
            // Échap ou Suppr : retour en arrière si possible
            if ((e.KeyCode == Keys.Escape || e.KeyCode == Keys.Back) && boutonRetour != null)
            {
                e.SuppressKeyPress = true;
                AfficherCurseur();
                boutonRetour.PerformClick();
            }
            // Entrée
            else if (e.KeyCode == Keys.Enter)
            {
                foreach (Button bouton in boutons)
                {
                    if (fenetre.ActiveControl == bouton)
                    {
                        e.SuppressKeyPress = true;
                        AfficherCurseur();
                        bouton.PerformClick();
                        break;
                    }
                }
            }
            // Les flèches parcourent la liste de boutons
            else if (boutons.Count > 0 &&
                     (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                      e.KeyCode == Keys.Left || e.KeyCode == Keys.Right))
            {
                if (!curseurCache)
                {
                    Cursor.Hide();
                    curseurCache = true;
                }

                int position = 0;
                for (int i = 0; i < boutons.Count; i++)
                {
                    if (fenetre.ActiveControl == boutons[i])
                    {
                        position = i;
                        break;
                    }
                }

                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
                    position--;
                else
                    position++;

                if (position < 0)
                    position = boutons.Count - 1;

                if (position == boutons.Count)
                    position = 0;

                boutons[position].Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void SourisBouge(object? sender, MouseEventArgs e)
        {
            AfficherCurseur();

            foreach (Button bouton in boutons)
            {
                if (sender == bouton)
                {
                    bouton.Focus();
                    break;
                }
            }
        }

        private void AfficherCurseur()
        {
            if (curseurCache)
            {
                Cursor.Show();
                curseurCache = false;
            }
        }
    }
}
