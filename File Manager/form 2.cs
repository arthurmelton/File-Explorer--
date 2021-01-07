using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace File_Manager
{
    public partial class form_2 : Form
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

        private Form1 _Form1;
        
        public form_2()
        {
            _Form1 = new Form1();
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn( 0, 0, Width-0, Height-0, 5, 5)); // adjust these parameters to get the look you want.
            panel1.Controls.Add(_Form1);
            
        }
    }
}