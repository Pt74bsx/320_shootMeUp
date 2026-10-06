using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShootMeUp
{
    internal static class ResponsiveHelpers
    {
        public static void ConfigureScreen(Form form)
        {
            form.ClientSize = new Size(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);
            form.MinimumSize = CalculateSizeWindow(form, Config.SCREEN_MIN_WIDTH, Config.SCREEN_MIN_HEIGHT);
            form.MaximumSize = CalculateSizeWindow(form, Config.SCREEN_MAX_WIDTH, Config.SCREEN_MAX_HEIGHT);
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        private static Size CalculateSizeWindow(Form form, int width, int height)
        {
            Size border = form.Size - form.ClientSize;
            return new Size(width + border.Width, height + border.Height);
        }
    }
}