namespace ShootMeUp
{
    internal sealed class NavigationBoutons : IMessageFilter, IDisposable
    {
        private const int TOUCHE_ENFONCEE = 0x0100; // Message Windows WM_KEYDOWN.

        private bool _curseurCache;
        private Point _positionSouris;
        private Form? _fenetreClavier;

        public NavigationBoutons()
        {
            Application.AddMessageFilter(this);
        }

        public bool PreFilterMessage(ref Message message)
        {
            if (_curseurCache && Cursor.Position != _positionSouris)
                AfficherCurseur();

            if (message.Msg != TOUCHE_ENFONCEE || Control.ModifierKeys != Keys.None)
                return false;

            Button? boutonActuel = Control.FromHandle(message.HWnd) as Button;
            if (boutonActuel == null || !boutonActuel.Focused)
                return false;

            Keys touche = (Keys)message.WParam.ToInt32();
            if (touche == Keys.Enter)
            {
                boutonActuel.PerformClick();
                return true;
            }

            if (touche != Keys.Left && touche != Keys.Right &&
                touche != Keys.Up && touche != Keys.Down)
                return false;

            Form? fenetre = boutonActuel.FindForm();
            if (fenetre == null)
                return false;

            CacherCurseur(fenetre);

            List<Button> boutons = new List<Button>();
            AjouterBoutons(fenetre, boutons);
            Button? prochainBouton = TrouverVoisin(boutonActuel, boutons, touche);

            if (prochainBouton != null)
                prochainBouton.Focus();

            return true;
        }

        private void AjouterBoutons(Control parent, List<Button> boutons)
        {
            foreach (Control controle in parent.Controls)
            {
                if (!controle.Visible || !controle.Enabled)
                    continue;

                if (controle is Button bouton && bouton.CanSelect)
                    boutons.Add(bouton);

                AjouterBoutons(controle, boutons);
            }
        }

        private Button? TrouverVoisin(Button actuel, List<Button> boutons, Keys touche)
        {
            Button? voisin = null;
            double meilleureDistance = double.MaxValue;
            Point centre = actuel.PointToScreen(new Point(actuel.Width / 2, actuel.Height / 2));

            foreach (Button bouton in boutons)
            {
                if (bouton == actuel)
                    continue;

                Point autreCentre = bouton.PointToScreen(new Point(bouton.Width / 2, bouton.Height / 2));
                double ecartX = autreCentre.X - centre.X;
                double ecartY = autreCentre.Y - centre.Y;

                bool bonneDirection =
                    (touche == Keys.Right && ecartX > 0) ||
                    (touche == Keys.Left && ecartX < 0) ||
                    (touche == Keys.Down && ecartY > 0) ||
                    (touche == Keys.Up && ecartY < 0);

                double distance = ecartX * ecartX + ecartY * ecartY;
                if (bonneDirection && distance < meilleureDistance)
                {
                    meilleureDistance = distance;
                    voisin = bouton;
                }
            }

            return voisin;
        }

        private void CacherCurseur(Form fenetre)
        {
            if (_curseurCache)
                return;

            _positionSouris = Cursor.Position;
            Cursor.Hide();
            _curseurCache = true;
            _fenetreClavier = fenetre;
            fenetre.Deactivate += QuitterFenetre;
            fenetre.FormClosed += QuitterFenetre;
        }

        private void QuitterFenetre(object? sender, EventArgs e)
        {
            AfficherCurseur();
        }

        private void AfficherCurseur()
        {
            if (!_curseurCache)
                return;

            Cursor.Show();
            _curseurCache = false;
            if (_fenetreClavier != null)
            {
                _fenetreClavier.Deactivate -= QuitterFenetre;
                _fenetreClavier.FormClosed -= QuitterFenetre;
                _fenetreClavier = null;
            }
        }

        public void Dispose()
        {
            Application.RemoveMessageFilter(this);
            AfficherCurseur();
        }
    }
}

