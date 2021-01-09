using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
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
            SetStyle(ControlStyles.ResizeRedraw, true);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width - 0, Height - 0, 7, 7));
            _frm1 = new Form1 {TopLevel = false, Visible = true};
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
                Point dif = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
                Location = Point.Add(_dragFormPoint, new Size(dif));
            }
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private const int CGrip = 16; // Grip size

        private const int CCaption = 32; // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            var rc = new Rectangle(ClientSize.Width - CGrip, ClientSize.Height - CGrip, CGrip, CGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, BackColor, rc);
            rc = new Rectangle(0, 0, ClientSize.Width, CCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width - 0, Height - 0, 7, 7));
            _frm1.ChangeSize(panel1.Size.Height, panel1.Size.Width);
        }

        protected override void WndProc(ref Message m)
        {

            if (m.Msg == 0x84)
            {
                // Trap WM_NCHITTEST
                var pos = new Point(m.LParam.ToInt32());
                pos = PointToClient(pos);
                if (pos.Y < CCaption)
                {
                    m.Result = (IntPtr) 2; // HTCAPTION

                    return;
                }
                if (pos.X >= ClientSize.Width - CGrip && pos.Y >= ClientSize.Height - CGrip)
                {
                    m.Result = (IntPtr) 17; // HTBOTTOMRIGHT

                    return;
                }
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width - 0, Height - 0, 7, 7));
            }
            base.WndProc(ref m);
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