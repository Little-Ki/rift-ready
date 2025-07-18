
using RiftReady.Assist;
using RiftReady.Assist.LOL;
using RiftReady.Assist.Server;
using RiftReady.Core;
using RiftReady.Core.Controller;
using RiftReady.Assist;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace RiftReady
{
    public partial class MainForm : Form
    {
        private readonly Worker worker = new();

        private readonly HttpServer server = new(2345);

        private readonly PageController page = new();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var config = Assist.Utils.ReadJson<Config>("config.json");

            Module<Config>.Value = config ?? new();
            Module<Champions>.Value.Update();

            server.Start();
            server
                .Register("GET", "\\/api\\/heros", ApiController.GetHeros)
                .Register("GET", "\\/api\\/config", ApiController.GetConfig)
                .Register("GET", "\\/api\\/status", ApiController.GetStatus)
                .Register("POST", "\\/api\\/config", ApiController.PostConfig)
                .Register("GET", "\\/(?!api)([-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)?", page.Handle);

            worker.Start();

            browser.Source = new Uri("http://localhost:5173/");
            //browser.Source = new Uri(server.Url);

            browser.CoreWebView2InitializationCompleted += (sender, e) =>
            {
                if (e.IsSuccess)
                {
                    browser.CoreWebView2!.Settings.AreBrowserAcceleratorKeysEnabled = false;
                    browser.CoreWebView2!.Settings.AreDefaultContextMenusEnabled = false;
                }
            };
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                notifyIcon.Visible = false;
                server.Stop();
                worker.Stop();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
                Hide();
                WindowState = FormWindowState.Minimized;
                Utils.Notification("通知", "窗口已隐藏至后台");
            }
        }

        protected override void WndProc(ref Message msg)
        {
            const int WM_NCLBUTTONDBLCLK = 0x00A3;

            if (msg.Msg == WM_NCLBUTTONDBLCLK)
            {
                msg.Result = IntPtr.Zero;
                return;
            }

            base.WndProc(ref msg);
        }

        private void Icon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenu.Show(Cursor.Position);
            }
        }
        private void Icon_DoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                Activate();
                WindowState = FormWindowState.Normal;
            }
        }

        private void Menu_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var name = e.ClickedItem?.Name ?? string.Empty;

            if (name == "menuExit")
            {
                Application.Exit();
            }
        }

    }
}
