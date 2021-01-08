using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

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
            //listBox1.Items.Add("OneDrive");
            var i = 0;
            foreach(var drive in DriveInfo.GetDrives())
            {
                listBox1.Items.Add(drive.Name);
                i++;
            }
            panel6.Height = i * 20;
            button4.FlatAppearance.BorderSize = 0;
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null) return;

            var listBox = listBox2.SelectedItem.ToString();

            frm1.ChangeDirectory(listBox);
            listBox1.ClearSelected();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel6.Visible = !panel6.Visible;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel7.Visible = !panel7.Visible;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
        
            var listBox = listBox1.SelectedItem.ToString();

            frm1.ChangeDirectory(listBox);

            listBox2.ClearSelected();
        }
    }
}