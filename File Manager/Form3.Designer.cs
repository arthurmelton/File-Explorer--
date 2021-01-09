using System.ComponentModel;

namespace File_Manager
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Desktop", 3, 3);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Documents");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Downloads", 2, 2);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Pictures", 5, 5);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Quick Access", 8, 8, new System.Windows.Forms.TreeNode[] {treeNode1, treeNode2, treeNode3, treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("This PC", 7, 7);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(204, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 641);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Location = new System.Drawing.Point(-241, -36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(802, 39);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (206)))), ((int) (((byte) (217)))), ((int) (((byte) (239)))));
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1050, 37);
            this.panel3.TabIndex = 1;
            //this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint());
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button3.Location = new System.Drawing.Point(935, 11);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(16, 16);
            this.button3.TabIndex = 4;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button2.Location = new System.Drawing.Point(980, 11);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(16, 16);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button1.Location = new System.Drawing.Point(1025, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(16, 16);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image) (resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image) (resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (30)))), ((int) (((byte) (30)))), ((int) (((byte) (55)))));
            this.label1.Location = new System.Drawing.Point(32, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 35);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.UseMnemonic = false;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (206)))), ((int) (((byte) (217)))), ((int) (((byte) (239)))));
            this.panel4.Controls.Add(this.treeView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(206, 638);
            this.panel4.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (206)))), ((int) (((byte) (217)))), ((int) (((byte) (239)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.FullRowSelect = true;
            this.treeView1.Indent = 25;
            this.treeView1.ItemHeight = 40;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (206)))), ((int) (((byte) (217)))), ((int) (((byte) (230)))));
            treeNode1.ForeColor = System.Drawing.SystemColors.WindowText;
            treeNode1.ImageIndex = 3;
            treeNode1.Name = "Desktop";
            treeNode1.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            treeNode1.SelectedImageIndex = 3;
            treeNode1.Text = "Desktop";
            treeNode2.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (206)))), ((int) (((byte) (217)))), ((int) (((byte) (230)))));
            treeNode2.ForeColor = System.Drawing.SystemColors.WindowText;
            treeNode2.Name = "Documents";
            treeNode2.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            treeNode2.Text = "Documents";
            treeNode3.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (206)))), ((int) (((byte) (217)))), ((int) (((byte) (230)))));
            treeNode3.ForeColor = System.Drawing.SystemColors.WindowText;
            treeNode3.ImageIndex = 2;
            treeNode3.Name = "Downloads";
            treeNode3.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            treeNode3.SelectedImageIndex = 2;
            treeNode3.Text = "Downloads";
            treeNode4.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (206)))), ((int) (((byte) (217)))), ((int) (((byte) (230)))));
            treeNode4.ForeColor = System.Drawing.SystemColors.WindowText;
            treeNode4.ImageIndex = 5;
            treeNode4.Name = "Pictures";
            treeNode4.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            treeNode4.SelectedImageIndex = 5;
            treeNode4.Text = "Pictures";
            treeNode5.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (206)))), ((int) (((byte) (217)))), ((int) (((byte) (230)))));
            treeNode5.ForeColor = System.Drawing.SystemColors.WindowText;
            treeNode5.ImageIndex = 8;
            treeNode5.Name = "Quick Access";
            treeNode5.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            treeNode5.SelectedImageIndex = 8;
            treeNode5.Text = "Quick Access";
            treeNode6.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (206)))), ((int) (((byte) (217)))), ((int) (((byte) (230)))));
            treeNode6.ForeColor = System.Drawing.SystemColors.WindowText;
            treeNode6.ImageIndex = 7;
            treeNode6.Name = "This PC";
            treeNode6.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            treeNode6.SelectedImageIndex = 7;
            treeNode6.Text = "This PC";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {treeNode5, treeNode6});
            this.treeView1.ShowLines = false;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.Size = new System.Drawing.Size(206, 675);
            this.treeView1.TabIndex = 8;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "real9.png");
            this.imageList1.Images.SetKeyName(1, "real8.png");
            this.imageList1.Images.SetKeyName(2, "real7.png");
            this.imageList1.Images.SetKeyName(3, "real6.png");
            this.imageList1.Images.SetKeyName(4, "real5.png");
            this.imageList1.Images.SetKeyName(5, "real4.png");
            this.imageList1.Images.SetKeyName(6, "real3.png");
            this.imageList1.Images.SetKeyName(7, "real2.png");
            this.imageList1.Images.SetKeyName(8, "real1.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "real9.png");
            this.imageList2.Images.SetKeyName(1, "real8.png");
            this.imageList2.Images.SetKeyName(2, "real7.png");
            this.imageList2.Images.SetKeyName(3, "real6.png");
            this.imageList2.Images.SetKeyName(4, "real5.png");
            this.imageList2.Images.SetKeyName(5, "real4.png");
            this.imageList2.Images.SetKeyName(6, "real3.png");
            this.imageList2.Images.SetKeyName(7, "real2.png");
            this.imageList2.Images.SetKeyName(8, "real1.png");
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (206)))), ((int) (((byte) (217)))), ((int) (((byte) (239)))));
            this.ClientSize = new System.Drawing.Size(1050, 675);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form3";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ImageList imageList2;

        private System.Windows.Forms.ImageList imageList1;

        private System.Windows.Forms.TreeView treeView1;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Panel panel4;

        private System.Windows.Forms.Panel panel3;

        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.Panel panel1;

        #endregion

    }
}