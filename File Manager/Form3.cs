using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;

namespace File_Manager
{
    public partial class Form3 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint="CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        private Form1 frm1;
        
        public Form3()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn( 0, 0, Width-0, Height-0, 7, 7));
            frm1 = new Form1 {TopLevel = false, Visible = true};
            panel1.Controls.Add(frm1);
            //panel1.Dock = DockStyle.Fill;
            label1.Font = new Font(label1.Font, FontStyle.Bold);
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            var treeList = new ImageList();
            treeList.Images.Add(pictureBox4.Image);
            treeList.Images.Add(pictureBox2.Image);
            treeList.Images.Add(pictureBox3.Image);
            treeList.Images.Add(pictureBox5.Image);
            treeList.Images.Add(pictureBox6.Image);
            treeList.Images.Add(pictureBox7.Image);
            treeView1.ImageList = treeList;
            //listBox1.Items.Add("OneDrive");
            var i = 0;
            var pc = treeView1.Nodes.Find("This PC", false);
            var Desktop = treeView1.Nodes.Find("Desktop", true);
            var down = treeView1.Nodes.Find("Downloads", true);
            var quick = treeView1.Nodes.Find("Quick Access", false);
            var pic = treeView1.Nodes.Find("Pictures", true);
            pc[0].ImageIndex = 1;
            pc[0].SelectedImageIndex = 1;
            quick[0].ImageIndex = 2;
            quick[0].SelectedImageIndex = 2;
            Desktop[0].ImageIndex = 3;
            Desktop[0].SelectedImageIndex = 3;
            down[0].ImageIndex = 4;
            down[0].SelectedImageIndex = 4;
            pic[0].ImageIndex = 5;
            pic[0].SelectedImageIndex = 5;
            foreach(var drive in DriveInfo.GetDrives())
            {
                if (pc[0] == null) return;
                var edit = pc[0].Nodes.Add(drive.Name);
                edit.Name = drive.Name;
                edit.BackColor = Color.FromArgb(206, 217, 230);
                edit.NodeFont = new Font(FontFamily.GenericSerif, 12);
                //edit.ImageIndex = 1;
                i++;
            }
            treeView1.Nodes[treeView1.Nodes.Count - 1].EnsureVisible();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
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

            frm1.ChangeDirectory(listBox);
        }
    }
}