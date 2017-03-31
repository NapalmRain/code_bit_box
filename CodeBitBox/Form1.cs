﻿using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using System.IO;
using System.Diagnostics;
using System.Data.SQLite;

namespace CodeBitBox
{
    public partial class Form1 : MaterialForm
    {
        int ActiveLang = 0;
        string ActiveBit = '0';
        string baseName = "codebit.sqlite";
        SQLiteConnection connection;

        public Form1() {
            InitializeComponent();

            connection = new SQLiteConnection(string.Format("Data Source={0};", baseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT `id`, `Name`, `Description`, `Language` FROM `UserBits` WHERE `Language` = '"+ActiveLang.ToString()+"';", connection);
            SQLiteDataReader CodeBits = command.ExecuteReader();

            while (CodeBits.Read())
            {
                ListViewItem lvi;
                lvi = listView2.Items.Add(CodeBits.GetString(1), CodeBits.GetInt16(0));
                lvi.ImageIndex = CodeBits.GetInt16(3);
                lvi.SubItems.Add(CodeBits.GetString(2));
                lvi.SubItems.Add(CodeBits.GetInt16(0).ToString());

            }
            connection.Close();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan900, Primary.BlueGrey900, Primary.DeepOrange400, Accent.LightBlue200, TextShade.WHITE);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        }

        private void Form1_Load(object sender, EventArgs e) {
            string dirc = Application.StartupPath;
            FileSyntaxModeProvider fsmp;
            if (Directory.Exists(dirc)) {

                fsmp = new FileSyntaxModeProvider(dirc);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
                ForCode.SetHighlighting("SQL");
            }
        }

        private void Form1_Resize(object sender, EventArgs e) {
            listView1.Height = this.Height - 119;
            listView2.Height = this.Height - 119;
            ForCode.Height = this.Height - 202;
            ForCode.Width = this.Width - 494;
            NameOfBit.Width = this.Width - 613;
            DescOfBit.Width = this.Width - 613;
        }

        
        private void ListView1_SelectedIndexChanged(object sender, EventArgs e) {
            ActiveLang = listView1.SelectedIndices[0];
            switch (ActiveLang) {
                case 0:
                    ForCode.SetHighlighting("PHP");
                    break;
                case 1:
                    ForCode.SetHighlighting("C#");
                    break;
                case 2:
                    ForCode.SetHighlighting("JS");
                    break;
                case 3:
                    ForCode.SetHighlighting("HTML");
                    break;
                case 4:
                    ForCode.SetHighlighting("CSS");
                    break;
                case 5:
                    ForCode.SetHighlighting("SQL");
                    break;
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e) {
            ActiveBit = listView2.Items[listView2.SelectedIndices[0]].SubItems[2].Text;
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT `Syntax`, `Name`, `Description` FROM `UserBits` WHERE `id` = '" + ActiveBit + "';", connection);
            SQLiteDataReader CodeBits = command.ExecuteReader();

            while (CodeBits.Read())
            {
                NameOfBit.Text = CodeBits.GetString(1);
                DescOfBit.Text = CodeBits.GetString(2);
                ForCode.Text = CodeBits.GetString(0);
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("UPDATE `UserBits` SET `Name` = '"+NameOfBit.Text+"' WHERE `id` = '" + ActiveBit + "';", connection);
                        
            connection.Close();
        }
    }
}
