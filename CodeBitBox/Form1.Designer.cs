﻿namespace CodeBitBox
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Языки программирования", System.Windows.Forms.HorizontalAlignment.Left);
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.item1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.item2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.NameOfBit = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.DescOfBit = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ForCode = new ICSharpCode.TextEditor.TextEditorControl();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.materialContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item1ToolStripMenuItem,
            this.item2ToolStripMenuItem});
            this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(154, 48);
            // 
            // item1ToolStripMenuItem
            // 
            this.item1ToolStripMenuItem.Name = "item1ToolStripMenuItem";
            this.item1ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.item1ToolStripMenuItem.Text = "Add new";
            this.item1ToolStripMenuItem.Click += new System.EventHandler(this.MaterialRaisedButton1_Click);
            // 
            // item2ToolStripMenuItem
            // 
            this.item2ToolStripMenuItem.Name = "item2ToolStripMenuItem";
            this.item2ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.item2ToolStripMenuItem.Text = "Delete selected";
            this.item2ToolStripMenuItem.Click += new System.EventHandler(this.Item2ToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "php.png");
            this.imageList1.Images.SetKeyName(1, "csharp.png");
            this.imageList1.Images.SetKeyName(2, "js.png");
            this.imageList1.Images.SetKeyName(3, "html.png");
            this.imageList1.Images.SetKeyName(4, "css.png");
            this.imageList1.Images.SetKeyName(5, "SQL.png");
            this.imageList1.Images.SetKeyName(6, "cpp.png");
            this.imageList1.Images.SetKeyName(7, "pb.png");
            this.imageList1.Images.SetKeyName(8, "java.png");
            this.imageList1.Images.SetKeyName(9, "swift.png");
            this.imageList1.Images.SetKeyName(10, "python.png");
            this.imageList1.Images.SetKeyName(11, "delphi.png");
            this.imageList1.Images.SetKeyName(12, "ruby.png");
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.ForeColor = System.Drawing.Color.White;
            listViewGroup1.Header = "Языки программирования";
            listViewGroup1.Name = "listViewGroup1";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listView1.LabelWrap = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(3, 107);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(222, 732);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(478, 73);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(49, 19);
            this.materialLabel1.TabIndex = 19;
            this.materialLabel1.Text = "Name";
            // 
            // NameOfBit
            // 
            this.NameOfBit.Depth = 0;
            this.NameOfBit.Enabled = false;
            this.NameOfBit.Hint = "";
            this.NameOfBit.Location = new System.Drawing.Point(601, 73);
            this.NameOfBit.MouseState = MaterialSkin.MouseState.HOVER;
            this.NameOfBit.Name = "NameOfBit";
            this.NameOfBit.PasswordChar = '\0';
            this.NameOfBit.SelectedText = "";
            this.NameOfBit.SelectionLength = 0;
            this.NameOfBit.SelectionStart = 0;
            this.NameOfBit.Size = new System.Drawing.Size(574, 23);
            this.NameOfBit.TabIndex = 4;
            this.NameOfBit.Text = "...";
            this.NameOfBit.UseSystemPasswordChar = false;
            this.NameOfBit.TextChanged += new System.EventHandler(this.NameOfBit_KeyUp);
            // 
            // DescOfBit
            // 
            this.DescOfBit.Depth = 0;
            this.DescOfBit.Enabled = false;
            this.DescOfBit.Hint = "";
            this.DescOfBit.Location = new System.Drawing.Point(601, 102);
            this.DescOfBit.MouseState = MaterialSkin.MouseState.HOVER;
            this.DescOfBit.Name = "DescOfBit";
            this.DescOfBit.PasswordChar = '\0';
            this.DescOfBit.SelectedText = "";
            this.DescOfBit.SelectionLength = 0;
            this.DescOfBit.SelectionStart = 0;
            this.DescOfBit.Size = new System.Drawing.Size(574, 23);
            this.DescOfBit.TabIndex = 5;
            this.DescOfBit.Text = "...";
            this.DescOfBit.UseSystemPasswordChar = false;
            this.DescOfBit.TextChanged += new System.EventHandler(this.DescOfBit_TextChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(478, 102);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(86, 19);
            this.materialLabel2.TabIndex = 12;
            this.materialLabel2.Text = "Description";
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Editing-Copy-icon.png");
            this.imageList2.Images.SetKeyName(1, "save.png");
            this.imageList2.Images.SetKeyName(2, "delete.png");
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.imageList2;
            this.button1.Location = new System.Drawing.Point(482, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 58);
            this.button1.TabIndex = 6;
            this.button1.Text = "Copy";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(229, 66);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(238, 38);
            this.materialRaisedButton1.TabIndex = 2;
            this.materialRaisedButton1.Text = "Add new Bit";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.MaterialRaisedButton1_Click);
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView2.ContextMenuStrip = this.materialContextMenuStrip1;
            this.listView2.ForeColor = System.Drawing.Color.White;
            this.listView2.LargeImageList = this.imageList1;
            this.listView2.Location = new System.Drawing.Point(229, 107);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(238, 732);
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Tile;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.ListView2_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 113;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.ImageIndex = 1;
            this.button2.ImageList = this.imageList2;
            this.button2.Location = new System.Drawing.Point(586, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 58);
            this.button2.TabIndex = 7;
            this.button2.Text = "Save";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteButton.ForeColor = System.Drawing.Color.LightCoral;
            this.DeleteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteButton.ImageIndex = 2;
            this.DeleteButton.ImageList = this.imageList2;
            this.DeleteButton.Location = new System.Drawing.Point(1069, 129);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(106, 58);
            this.DeleteButton.TabIndex = 9;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.Item2ToolStripMenuItem_Click);
            // 
            // ForCode
            // 
            this.ForCode.AutoScroll = true;
            this.ForCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ForCode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ForCode.BackgroundImage")));
            this.ForCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ForCode.Enabled = false;
            this.ForCode.ForeColor = System.Drawing.Color.White;
            this.ForCode.IsReadOnly = false;
            this.ForCode.Location = new System.Drawing.Point(482, 190);
            this.ForCode.Name = "ForCode";
            this.ForCode.ShowSpaces = true;
            this.ForCode.ShowTabs = true;
            this.ForCode.Size = new System.Drawing.Size(693, 649);
            this.ForCode.TabIndex = 8;
            this.ForCode.TextChanged += new System.EventHandler(this.IsTextChanged);
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.Teal;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Image = ((System.Drawing.Image)(resources.GetObject("SettingsButton.Image")));
            this.SettingsButton.Location = new System.Drawing.Point(1131, 23);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(44, 41);
            this.SettingsButton.TabIndex = 20;
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 851);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.ForCode);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DescOfBit);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.NameOfBit);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "Form1";
            this.Text = "CodeBit BOX - Casket with important bits of code";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.materialContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem item1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem item2ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.ListView listView1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField NameOfBit;
        private MaterialSkin.Controls.MaterialSingleLineTextField DescOfBit;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button button1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button DeleteButton;
        private ICSharpCode.TextEditor.TextEditorControl ForCode;
        private System.Windows.Forms.Button SettingsButton;
    }
}

