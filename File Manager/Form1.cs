using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.IO.Directory;

namespace File_Manager
{
    public partial class Form1 : Form
    {

        private readonly List<string> _files = new List<string>();

        private string _folderBrowserDialog;

        public Form1()
        {
            InitializeComponent();
            //var form2 = new form_2();
            //Application.Run(form2);
        }

        public void button1_Click()
        {
            _files.Clear();
            listView1.Items.Clear();
            imageList1.Images.Clear();
            textBox1.Text = _folderBrowserDialog;
            //using (_folderBrowserDialog = new FolderBrowserDialog { Description = @"Select your path."})
            //if (_folderBrowserDialog.ShowDialog() != DialogResult.OK) return;

            foreach (var item in GetFiles(_folderBrowserDialog))
            {
                imageList1.Images.Add(Icon.ExtractAssociatedIcon(item) ?? throw new InvalidOperationException());
                var fileInfo = new FileInfo(item);
                _files.Add(fileInfo.FullName);
                listView1.Items.Add(fileInfo.Name, imageList1.Images.Count - 1);
            }
            
            foreach (var item in GetDirectories(_folderBrowserDialog))
            {
                //imageList1.Images.Add(Icon.ExtractAssociatedIcon(pictureBox1.ImageLocation) ?? throw new InvalidOperationException());
                var fileInfo = new FileInfo(item);
                _files.Add(fileInfo.FullName);
                listView1.Items.Add(fileInfo.Name, imageList1.Images.Count - 1);
            }
            listView1.Sort();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listView1.FocusedItem == null) return;

            //if (_files != null) Process.Start(_files[listView1.FocusedItem.Index]);
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            var item = listView1.SelectedItems[0].Text;
            if (item == null) return;

            var fileAttributes = File.GetAttributes(_folderBrowserDialog + item + @"\");

            if ((fileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
            {

                _folderBrowserDialog = _folderBrowserDialog + item + @"\";
                button1_Click();
            }
            else
            {
                if (_files != null) Process.Start(_files[listView1.FocusedItem.Index]);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13) return;

            _folderBrowserDialog = textBox1.Text;
            button1_Click();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text.Replace(@"\", " > ");
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text.Replace(" > ", @"\");
        }
    }
}