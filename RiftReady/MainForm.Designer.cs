namespace LOLUtil
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            browser = new Microsoft.Web.WebView2.WinForms.WebView2();
            contextMenu = new ContextMenuStrip(components);
            menuExit = new ToolStripMenuItem();
            notifyIcon = new NotifyIcon(components);
            ((System.ComponentModel.ISupportInitialize)browser).BeginInit();
            contextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // browser
            // 
            browser.AllowExternalDrop = true;
            browser.CreationProperties = null;
            browser.DefaultBackgroundColor = Color.White;
            browser.Dock = DockStyle.Fill;
            browser.Location = new Point(0, 0);
            browser.Name = "browser";
            browser.Size = new Size(760, 463);
            browser.TabIndex = 0;
            browser.ZoomFactor = 1D;
            // 
            // contextMenu
            // 
            contextMenu.Items.AddRange(new ToolStripItem[] { menuExit });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(101, 26);
            contextMenu.ItemClicked += Menu_Clicked;
            // 
            // menuExit
            // 
            menuExit.Name = "menuExit";
            menuExit.Size = new Size(100, 22);
            menuExit.Text = "退出";
            // 
            // notifyIcon
            // 
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Visible = true;
            notifyIcon.MouseClick += Icon_MouseClick;
            notifyIcon.MouseDoubleClick += Icon_DoubleClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 463);
            Controls.Add(browser);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)browser).EndInit();
            contextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 browser;
        private ContextMenuStrip contextMenu;
        private NotifyIcon notifyIcon;
        private ToolStripMenuItem menuExit;
    }
}
