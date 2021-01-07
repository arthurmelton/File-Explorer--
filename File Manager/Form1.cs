﻿using System;
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
            if (!textBox1.Focused) textBox1.Text = textBox1.Text.Replace(@"\", " > ");
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

            var fileAttributes = !_folderBrowserDialog.EndsWith(@"\") ? File.GetAttributes(_folderBrowserDialog + @"\" + item) : File.GetAttributes(_folderBrowserDialog + item);

            if ((fileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                if (_folderBrowserDialog.EndsWith(@"\"))
                {
                    _folderBrowserDialog += item;
                }
                else
                {
                    _folderBrowserDialog += @"\" + item;
                }
                button1_Click();
            }
            else
            {
                var i = 0;
                foreach (var items in listView1.SelectedItems)
                {
                    if (_files != null) Process.Start(_files[listView1.SelectedItems[i].Index]);
                    i++;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13) return;

            textBox1.Text = textBox1.Text.Replace(" > ", @"\");

            _folderBrowserDialog = textBox1.Text;
            if (!textBox1.Focused) textBox1.Text = textBox1.Text.Replace(@"\", " > ");
            button1_Click();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(@"\", " > ");
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(" > ", @"\");
        }

        private void Button1Click(object sender, EventArgs e)
        {
            var split = _folderBrowserDialog.Remove(_folderBrowserDialog.Length - 1);

            while (split.EndsWith(@"\") == false) split = split.Remove(split.Length - 1);

            _folderBrowserDialog = split;
            textBox1.Text = _folderBrowserDialog;
            if (!textBox1.Focused) textBox1.Text = textBox1.Text.Replace(@"\", " > ");
            button1_Click();
        }

        public void ChangeDirectory(string a)
        {
            _folderBrowserDialog = a;
            textBox1.Text = _folderBrowserDialog;
            if (!textBox1.Focused) textBox1.Text = textBox1.Text.Replace(@"\", " > ");
            button1_Click();
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 46) return;

            if (listView1.SelectedItems[0].Text == null) return;

            var i = 0;
            foreach (var item in listView1.SelectedItems)
            {
                var loc = listView1.SelectedItems[i].Index;

                if (_files != null) File.Delete(_files[loc]);
                listView1.Items.RemoveAt(loc);
                if (_files != null) _files.RemoveAt(loc);
                i++;
            }
        }
    }
}