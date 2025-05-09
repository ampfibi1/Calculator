using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ElipseByTamjid
{
    public class ElipseControl : Component
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        private Control control;
        private int cornerRadius = 25;

        public Control TargetControl
        {
            get => control;
            set
            {
                control = value;
                ApplyElipse(); // Apply initially

                // Reapply when size changes
                control.SizeChanged += (sender, e) => ApplyElipse();
            }
        }

        public int CornerRadius
        {
            get => cornerRadius;
            set
            {
                cornerRadius = value;
                ApplyElipse();
            }
        }

        private void ApplyElipse()
        {
            if (control != null && control.Width > 0 && control.Height > 0)
            {
                control.Region = Region.FromHrgn(CreateRoundRectRgn(
                    0, 0, control.Width, control.Height, cornerRadius, cornerRadius));
            }
        }
    }
}
