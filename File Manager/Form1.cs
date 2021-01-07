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
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _files.Clear();
            listView1.Items.Clear();
            using (var folderBrowserDialog = new FolderBrowserDialog { Description = @"Select your path."})
            {
                if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;

                foreach (var item in GetFiles(folderBrowserDialog.SelectedPath))
                {
                    imageList1.Images.Add(Icon.ExtractAssociatedIcon(item) ?? throw new InvalidOperationException());
                    var fileInfo = new FileInfo(item);
                    _files.Add(fileInfo.FullName);
                    listView1.Items.Add(fileInfo.Name, imageList1.Images.Count - 1);
                }
                
                foreach (var item in GetDirectories(folderBrowserDialog.SelectedPath))
                {
                    //imageList1.Images.Add(Icon.ExtractAssociatedIcon(item) ?? throw new InvalidOperationException());
                    var fileInfo = new FileInfo(item);
                    _files.Add(fileInfo.FullName);
                    listView1.Items.Add(fileInfo.Name, imageList1.Images.Count - 1);
                }
                
                listView1.Sort();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.FocusedItem == null) return;

            if (_files != null) Process.Start(_files[listView1.FocusedItem.Index]);
        }
    }
}