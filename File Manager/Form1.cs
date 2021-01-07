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

        private FolderBrowserDialog _folderBrowserDialog;

        public Form1()
        {
            InitializeComponent();
            //var form2 = new form_2();
            //Application.Run(form2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _files.Clear();
            listView1.Items.Clear();
            using (_folderBrowserDialog = new FolderBrowserDialog { Description = @"Select your path."})
            {
                if (_folderBrowserDialog.ShowDialog() != DialogResult.OK) return;

                foreach (var item in GetFiles(_folderBrowserDialog.SelectedPath))
                {
                    imageList1.Images.Add(Icon.ExtractAssociatedIcon(item) ?? throw new InvalidOperationException());
                    var fileInfo = new FileInfo(item);
                    _files.Add(fileInfo.FullName);
                    listView1.Items.Add(fileInfo.Name, imageList1.Images.Count - 1);
                }
                
                foreach (var item in GetDirectories(_folderBrowserDialog.SelectedPath))
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

            //if (_files != null) Process.Start(_files[listView1.FocusedItem.Index]);
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.FocusedItem == null) return;

            var fileAttributes = File.GetAttributes(_folderBrowserDialog.SelectedPath + "/" + listView1.FocusedItem.Name);

            if ((fileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                _folderBrowserDialog.SelectedPath = _folderBrowserDialog.SelectedPath + @"/" + listView1.FocusedItem.Name;

                _files.Clear();
                listView1.Items.Clear();
                foreach (var item in GetFiles(_folderBrowserDialog.SelectedPath))
                {
                    imageList1.Images.Add(Icon.ExtractAssociatedIcon(item) ?? throw new InvalidOperationException());
                    var fileInfo = new FileInfo(item);
                    _files.Add(fileInfo.FullName);
                    listView1.Items.Add(fileInfo.Name, imageList1.Images.Count - 1);
                }
                
                foreach (var item in GetDirectories(_folderBrowserDialog.SelectedPath))
                {
                    //imageList1.Images.Add(Icon.ExtractAssociatedIcon(item) ?? throw new InvalidOperationException());
                    var fileInfo = new FileInfo(item);
                    _files.Add(fileInfo.FullName);
                    listView1.Items.Add(fileInfo.Name, imageList1.Images.Count - 1);
                }
                
                listView1.Sort();
            }
            else
            {
                if (_files != null) Process.Start(_files[listView1.FocusedItem.Index]);
            }
        }
    }
}