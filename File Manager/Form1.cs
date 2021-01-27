using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using File_Manager.Properties;
using Microsoft.WindowsAPICodePack.Shell;
using static System.IO.Directory;

namespace File_Manager
{
    public partial class Form1 : Form
    {

        private static readonly List<string> Files = new List<string>();

        public static bool QualityNotQuantity = true;

        private static List<string> _dir;

        private static string _text;

        private static ImageList _imageList;

        private static ListView _listView;

        private string _folderBrowserDialog;

        private readonly Form3 _form3;

        private Thread _thread;

        public Form1(Thread thread, Form3 form3)
        {
            _form3 = form3;
            _thread = thread;
            InitializeComponent();
            try
            {
                //if ((bool) Settings.Default["QualityNotQuantity"]) return;

                checkBox1.Checked = !Settings.Default.QualityNotQuantity;
                QualityNotQuantity = !checkBox1.Checked;

            }
            catch (SettingsPropertyNotFoundException)
            {
                Settings.Default.QualityNotQuantity = checkBox1.Checked;
                Settings.Default.Save();
            }
        }

        private void button1_Click()
        {
            _thread = new Thread(ThreadThis);
            _thread.Start();
            Files.Clear();
            listView1.Items.Clear();
            imageList1.Images.Clear();
            textBox1.Text = _folderBrowserDialog;
            if (!textBox1.Focused) textBox1.Text = textBox1.Text.Replace(@"\", " > ");
            listView1.BeginUpdate();
            progressBar1.Refresh();
            progressBar1.Value = 0;
            progressBar1.Maximum = GetFiles(_folderBrowserDialog).Length;
            progressBar1.Visible = true;
            progressBar1.Maximum = GetFiles(_folderBrowserDialog).Length;
        }

        private void ThreadThis()
        {

            foreach (var item in GetFiles(_folderBrowserDialog)) AddItem(item);

            foreach (var item in GetDirectories(_folderBrowserDialog))
            {
                try
                {
                    using (var shellFile = ShellFile.FromFilePath(item))
                    {

                        using (var img = new Bitmap(shellFile.Thumbnail.ExtraLargeBitmap.Width, shellFile.Thumbnail.ExtraLargeBitmap.Height))
                        {
                            using (var g = Graphics.FromImage(img))
                            {
                                var bm = shellFile.Thumbnail.ExtraLargeBitmap;
                                bm.MakeTransparent(Color.Black);
                                g.DrawImage(bm, new Rectangle(0, 0, shellFile.Thumbnail.ExtraLargeBitmap.Width, shellFile.Thumbnail.ExtraLargeBitmap.Height));
                                imageList1.Images.Add(img);
                            }
                        }
                    }
                }
                catch
                {
                    try
                    {
                        imageList1.Images.Add(imageList2.Images[6]);
                    }
                    catch
                    {
                        // ignored
                    }
                }
                var fileInfo = new FileInfo(item);
                Files.Add(fileInfo.FullName);
                listView1.Items.Add(fileInfo.Name, imageList1.Images.Count - 1);
            }
            listView1.EndUpdate();
            listView1.Sort();
            progressBar1.Visible = false;
        }

        public void AddItem(string item)
        {
            if (QualityNotQuantity)
                try
                {
                    using (var shellFile = ShellFile.FromFilePath(item))
                    {

                        using (var img = new Bitmap(shellFile.Thumbnail.ExtraLargeBitmap.Width, shellFile.Thumbnail.ExtraLargeBitmap.Height))
                        {
                            using (var g = Graphics.FromImage(img))
                            {
                                var bm = shellFile.Thumbnail.ExtraLargeBitmap;
                                bm.MakeTransparent(Color.Black);
                                g.DrawImage(bm, new Rectangle(0, 0, shellFile.Thumbnail.ExtraLargeBitmap.Width, shellFile.Thumbnail.ExtraLargeBitmap.Height));
                                imageList1.Images.Add(img);
                            }
                        }
                    }
                }
                catch
                {
                    try
                    {
                        imageList1.Images.Add(Icon.ExtractAssociatedIcon(item) ?? throw new InvalidOperationException());
                    }
                    catch
                    {
                        imageList1.Images.Add(imageList2.Images[6]);
                    }
                }
            else imageList1.Images.Add(Icon.ExtractAssociatedIcon(item) ?? throw new InvalidOperationException());
            var fileInfo = new FileInfo(item);
            Files.Add(fileInfo.FullName);
            // ReSharper disable once InconsistentNaming
            var _item = listView1.Items.Add(fileInfo.Name, imageList1.Images.Count - 1);
            _item.Tag = fileInfo.FullName;
            progressBar1.Value++;
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
                if (_folderBrowserDialog.EndsWith(@"\")) _folderBrowserDialog += item;
                else _folderBrowserDialog += @"\" + item;
                button1_Click();
            }
            else
            {
                var i = 0;
                foreach (var unused in listView1.SelectedItems)
                {
                    if (Files != null) Process.Start(Files[listView1.SelectedItems[i].Index]);
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
            switch (a)
            {
                case "OneDrive":
                    _folderBrowserDialog = @"C:\Users\" + WindowsIdentity.GetCurrent().Name.Split(Convert.ToChar(@"\")).Last() + @"\OneDrive";

                    break;
                case "Desktop":
                    _folderBrowserDialog = @"C:\Users\" + WindowsIdentity.GetCurrent().Name.Split(Convert.ToChar(@"\")).Last() + @"\Desktop";

                    break;
                case "Documents":
                    _folderBrowserDialog = @"C:\Users\" + WindowsIdentity.GetCurrent().Name.Split(Convert.ToChar(@"\")).Last() + @"\Documents";

                    break;
                case "Pictures":
                    _folderBrowserDialog = @"C:\Users\" + WindowsIdentity.GetCurrent().Name.Split(Convert.ToChar(@"\")).Last() + @"\Pictures";

                    break;
                case "Downloads":
                    _folderBrowserDialog = @"C:\Users\" + WindowsIdentity.GetCurrent().Name.Split(Convert.ToChar(@"\")).Last() + @"\Downloads";

                    break;
                default:
                    _folderBrowserDialog = a;

                    break;
            }
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

            foreach (var unused in listView1.SelectedItems)
            {
                var loc = listView1.SelectedItems[0].Index;

                if (Files != null) File.Delete(Files[loc]);
                listView1.Items.RemoveAt(loc);
                Files?.RemoveAt(loc);
            }
        }

        private void contextMenu1_Popup(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Right) return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(_folderBrowserDialog + @"\untitled.txt"))
            {
                Add(1);
            }
            else
            {
                Files.Add("untitled.txt");
                File.Create(_folderBrowserDialog + @"\untitled.txt");
                listView1.SelectedItems.Clear();
                imageList1.Images.Add(Icon.ExtractAssociatedIcon(_folderBrowserDialog + @"\untitled.txt") ?? throw new InvalidOperationException());
                listView1.Items.Add("untitled.txt", imageList1.Images.Count - 1);
            }

        }

        private void Add(int i)
        {
            while (true)
            {
                if (File.Exists(_folderBrowserDialog + @"\untitled (" + i + ").txt"))
                {
                    i += 1;

                    continue;
                }
                Files.Add("untitled (" + i + ").txt");
                File.Create(_folderBrowserDialog + @"\untitled (" + i + ").txt");
                listView1.SelectedItems.Clear();
                imageList1.Images.Add(Icon.ExtractAssociatedIcon(_folderBrowserDialog + @"\untitled (" + i + ").txt") ?? throw new InvalidOperationException());
                listView1.Items.Add("untitled (" + i + ").txt", imageList1.Images.Count - 1);

                break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0].Text == null) return;

            var loc = Files[listView1.SelectedItems[0].Index];
            var split = listView1.SelectedItems[0].Name.Remove(listView1.SelectedItems[0].Name.Length - 1);
            while (split.EndsWith(@"\") == false) split = split.Remove(split.Length - 1);
            File.Move(loc, split + "tes.txt");
        }

        public void ChangeSize(int h, int w)
        {
            Width = w;
            Height = h;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13) return;

            _text = textBox2.Text;
            _imageList = imageList1;
            _listView = listView1;
            _dir = null;

            var thread1 = new Thread(() => GetAllSubDir(_folderBrowserDialog));
            thread1.Start();
            thread1.Join();
            var thread2 = new Thread(() => GetAllFiles(_dir[0]));
            thread2.Start();
            thread2.Join();
        }

        private static void GetAllSubDir(string e)
        {
            foreach (var directory in GetDirectories(e))
            {
                _dir.Add(directory);
                GetAllSubDir(directory);
            }
        }

        private static void GetAllFiles(string e)
        {
            foreach (var file in GetFiles(e))
            {
                if (!_text.Contains(file)) continue;

                try
                {
                    using (var shellFile = ShellFile.FromFilePath(file))
                    {

                        using (var img = new Bitmap(shellFile.Thumbnail.ExtraLargeBitmap.Width, shellFile.Thumbnail.ExtraLargeBitmap.Height))
                        {
                            using (var g = Graphics.FromImage(img))
                            {
                                var bm = shellFile.Thumbnail.ExtraLargeBitmap;
                                bm.MakeTransparent(Color.Black);
                                g.DrawImage(bm, new Rectangle(0, 0, shellFile.Thumbnail.ExtraLargeBitmap.Size.Width, shellFile.Thumbnail.ExtraLargeBitmap.Size.Height));
                                _imageList.Images.Add(img);
                            }
                        }
                    }
                }
                catch
                {
                    try
                    {
                        _imageList.Images.Add(Icon.ExtractAssociatedIcon(file) ?? throw new InvalidOperationException());
                    }
                    catch
                    {
                        // ignored
                    }
                }
                var fileInfo = new FileInfo(file);
                Files.Add(fileInfo.FullName);
                _listView.Items.Add(fileInfo.Name, _imageList.Images.Count - 1);
            }
            _dir.RemoveAt(0);
            if (_dir[0] != null) GetAllFiles(_dir[0]);

        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (!(e.Data.GetData(DataFormats.FileDrop) is string[] files) || !files.Any()) return;

            foreach (var file in files)
            {
                string i;
                if (_folderBrowserDialog.EndsWith(@"\")) i = _folderBrowserDialog + file.Split(Convert.ToChar(@"\")).Last();
                else i = _folderBrowserDialog + @"\" + file.Split(Convert.ToChar(@"\")).Last();
                File.Move(file, i);
                AddItem(i);
            }
        }

        private void listView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Link : DragDropEffects.None;
        }

        private void listView1_DragLeave(object sender, EventArgs e)
        {
            //
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            if (Files == null) return;

            var files = new string[listView1.SelectedItems.Count];
            for (var i = 0; i < listView1.SelectedItems.Count; i++) files[i] = Files[listView1.SelectedItems[i].Index];
            DoDragDrop(new DataObject(DataFormats.FileDrop, files), DragDropEffects.Copy);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            QualityNotQuantity = !checkBox1.Checked;
            Settings.Default.QualityNotQuantity = !checkBox1.Checked;
            Settings.Default.Save();
            Console.Out.WriteLine(Settings.Default.QualityNotQuantity);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _form3.AddItemToTree(_folderBrowserDialog);
        }
    }
}