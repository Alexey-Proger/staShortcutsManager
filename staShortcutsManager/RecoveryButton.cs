using staShortcutsManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace staShortcutsManager
{
    public partial class RecoveryButton : UserControl
    {
        public new event EventHandler Click;

        private int recoveryIcon = 0;
        private string recoveryDesc = "Default description";

        [Category("Button data")]
        public int RecoveryIcon
        {
            get => recoveryIcon;
            set
            {
                recoveryIcon = value;

                switch (recoveryIcon)
                {
                    case 0:
                        recovery_icon.Image = (Image)new Bitmap((Image)Resources.twrp2, new Size(GetProperSize(64), GetProperSize(64)));
                        recovery_name.Text = "TWRP";
                        break;
                    case 1:
                        recovery_icon.Image = (Image)new Bitmap((Image)Resources.ofox, new Size(GetProperSize(64), GetProperSize(64)));
                        recovery_name.Text = "oFox Recovery";
                        break;
                    case 2:
                        recovery_icon.Image = (Image)new Bitmap((Image)Resources.pbrp, new Size(GetProperSize(64), GetProperSize(64)));
                        recovery_name.Text = "PBRP";
                        break;
                    default:
                        recovery_icon.Image = (Image)new Bitmap((Image)Resources.icon1, new Size(GetProperSize(64), GetProperSize(64)));
                        recovery_name.Text = "Load failed!";
                        this.Enabled = false;
                        break;
                }

                this.Size = new Size(GetProperSize(350), GetProperSize(76) - 5);
                recovery_icon.Location = new Point(GetProperSize(8), GetProperSize(3));
                recovery_icon.Size = new Size(GetProperSize(65), GetProperSize(65));
                recovery_name.Location = new Point(GetProperSize(83), GetProperSize(4));
                recovery_desk.Location = new Point(GetProperSize(85), GetProperSize(28));
                recovery_desk.Size = new Size(GetProperSize(261), GetProperSize(46));

                Invalidate();
            }
        }

        [Category("Button data")]
        public string RecoveryDesc
        {
            get => recoveryDesc;
            set
            {
                recoveryDesc = value;
                if (recovery_desk != null)
                    recovery_desk.Text = recoveryDesc;
                Invalidate();
            }
        }

        public RecoveryButton()
        {
            InitializeComponent();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control.MouseClick += (s, ev) => this.OnMouseClick(ev);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            this.OnClick(e);
            base.OnMouseClick(e);
        }

        private int GetProperSize(int size)
        {
            int properIconSize;
            using (Graphics graphics = this.CreateGraphics())
                properIconSize = (int)((double)size * ((double)graphics.DpiX / 96.0));
            return properIconSize;
        }
    }
}
