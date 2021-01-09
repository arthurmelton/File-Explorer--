using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace File_Manager
{
    public sealed partial class Form3 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        private readonly Form1 _frm1;

        public Form3()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width - 0, Height - 0, 7, 7));
            _frm1 = new Form1(Thread.CurrentThread) {TopLevel = false, Visible = true};
            panel1.Controls.Add(_frm1);
            //panel1.Dock = DockStyle.Fill;
            label1.Font = new Font(label1.Font, FontStyle.Bold);
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            treeView1.ImageList = imageList1;
            //listBox1.Items.Add("OneDrive");
            treeView1.ImageIndex = 6;
            treeView1.SelectedImageIndex = 6;
            var pc = treeView1.Nodes.Find("This PC", false);
            /*var Desktop = treeView1.Nodes.Find("Desktop", true);
            var down = treeView1.Nodes.Find("Downloads", true);
            var quick = treeView1.Nodes.Find("Quick Access", false);
            var pic = treeView1.Nodes.Find("Pictures", true);
            pc[0].ImageIndex = 7;
            pc[0].SelectedImageIndex = 7;
            quick[0].ImageIndex = 8;
            quick[0].SelectedImageIndex = 8;
            Desktop[0].ImageIndex = 3;
            Desktop[0].SelectedImageIndex = 3;
            down[0].ImageIndex = 2;
            down[0].SelectedImageIndex = 2;
            pic[0].ImageIndex = 5;
            pic[0].SelectedImageIndex = 5;*/
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (pc[0] == null) return;

                var edit = pc[0].Nodes.Add(drive.Name);
                edit.Name = drive.Name;
                edit.BackColor = Color.FromArgb(206, 217, 230);
                edit.NodeFont = new Font(FontFamily.GenericSerif, 12);
                //edit.ImageIndex = 1;
            }
            treeView1.Nodes[treeView1.Nodes.Count - 1].EnsureVisible();
        }

        private bool _dragging;

        private Point _dragCursorPoint;

        private Point _dragFormPoint;

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _dragCursorPoint = Cursor.Position;
            _dragFormPoint = Location;
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                var dif = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
                Location = Point.Add(_dragFormPoint, new Size(dif));
            }
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        protected override void OnPaint(PaintEventArgs e) // you can safely omit this method if you want
        {
            e.Graphics.FillRectangle(Brushes.Green, Left);
            e.Graphics.FillRectangle(Brushes.Green, Right);
            e.Graphics.FillRectangle(Brushes.Green, Bottom);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width - 0, Height - 0, 7, 7));
            _frm1.ChangeSize(panel1.Size.Height, panel1.Size.Width);
        }

        private const int
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17;

        private const int _ = 10; // you can rename this variable if you like

        private Rectangle Top => new Rectangle(0, 0, ClientSize.Width, _);

        private Rectangle Left => new Rectangle(0, 0, _, ClientSize.Height);

        private Rectangle Bottom => new Rectangle(0, ClientSize.Height - _, ClientSize.Width, _);

        private Rectangle Right => new Rectangle(ClientSize.Width - _, 0, _, ClientSize.Height);

        private Rectangle TopLeft => new Rectangle(0, 0, _, _);

        private Rectangle TopRight => new Rectangle(ClientSize.Width - _, 0, _, _);

        private Rectangle BottomLeft => new Rectangle(0, ClientSize.Height - _, _, _);

        private Rectangle BottomRight => new Rectangle(ClientSize.Width - _, ClientSize.Height - _, _, _);


        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == 0x84) // WM_NCHITTEST
            {
                var cursor = PointToClient(Cursor.Position);

                if (TopLeft.Contains(cursor)) message.Result = (IntPtr) HTTOPLEFT;
                else if (TopRight.Contains(cursor)) message.Result = (IntPtr) HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr) HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr) HTBOTTOMRIGHT;

                else if (Top.Contains(cursor)) message.Result = (IntPtr) HTTOP;
                else if (Left.Contains(cursor)) message.Result = (IntPtr) HTLEFT;
                else if (Right.Contains(cursor)) message.Result = (IntPtr) HTRIGHT;
                else if (Bottom.Contains(cursor)) message.Result = (IntPtr) HTBOTTOM;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width - 0, Height - 0, 7, 7));
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode == null) return;

            var listBox = treeView1.SelectedNode.Name;

            if (listBox == "This PC" || listBox == "Quick Access") return;

            _frm1.ChangeDirectory(listBox);
        }

    }
}