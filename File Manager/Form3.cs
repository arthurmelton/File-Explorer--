using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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
        
        public Form3()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn( 0, 0, Width-0, Height-0, 7, 7));
            var frm1 = new Form1 {TopLevel = false, Visible = true};
            panel1.Controls.Add(frm1);
            //panel1.Dock = DockStyle.Fill;
            label1.Font = new Font(label1.Font, FontStyle.Bold);

        }
    }
}