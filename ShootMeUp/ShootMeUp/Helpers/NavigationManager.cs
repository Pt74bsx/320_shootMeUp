using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShootMeUp
{
    internal class NavigationManager
    {
        private Form fenetre;
        private List<Button> boutons;
        private Action? retour;
        private bool curseurCache = false;

        public NavigationManager(Form fenetre, List<Button> boutons, Action? retour = null)
        {
            this.fenetre = fenetre;
            this.boutons = boutons;
            this.retour = retour;

            fenetre.KeyPreview = true;
            fenetre.KeyDown += TouchePressee;
            fenetre.MouseMove += SourisBouge;

            fenetre.VisibleChanged += (s, e) =>
            {
                if (!fenetre.Visible)
                    AfficherCurseur();
            };

            fenetre.Deactivate += (s, e) => AfficherCurseur();

            foreach (Button bouton in boutons)
            {
                bouton.PreviewKeyDown += AvantTouche;
                bouton.MouseMove += SourisBouge;
            }

            if (boutons.Count > 0)
                fenetre.ActiveControl = boutons[0];
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
            if ((e.KeyCode == Keys.Escape || e.KeyCode == Keys.Back) && retour != null)
            {
                e.SuppressKeyPress = true;
                AfficherCurseur();
                retour();
            }
            // Entrée
            else if (e.KeyCode == Keys.Enter &&
                     fenetre.ActiveControl is Button bouton &&
                     boutons.Contains(bouton))
            {
                e.SuppressKeyPress = true;
                AfficherCurseur();
                bouton.PerformClick();
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

                int position = boutons.IndexOf(
                    fenetre.ActiveControl as Button ?? boutons[0]);

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

            if (sender is Button bouton)
                bouton.Focus();
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