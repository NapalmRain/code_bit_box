using MaterialSkin;
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
        int ActiveLang = 0, ActiveBitIndex = -1;
        string ActiveBit = "-1";
        string baseName = "codebit.sqlite";
        SQLiteConnection connection;

        public Form1() {
            InitializeComponent();

            connection = new SQLiteConnection(string.Format("Data Source={0};", baseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT `id`, `Name`, `Description`, `Language`, `Syntax` FROM `UserBits` WHERE `Language` = '"+ActiveLang.ToString()+"';", connection);
            SQLiteDataReader CodeBits = command.ExecuteReader();

            while (CodeBits.Read())
            {
                ListViewItem lvi;
                lvi = listView2.Items.Add(CodeBits.GetString(1), CodeBits.GetInt16(0));
                lvi.ImageIndex = CodeBits.GetInt16(3);
                lvi.SubItems.Add(CodeBits.GetString(2));
                lvi.SubItems.Add(CodeBits.GetInt16(0).ToString());
                lvi.SubItems.Add(CodeBits.GetString(4));

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
            if (listView1.SelectedIndices.Count > 0)
            {
                ActiveLang = listView1.SelectedIndices[0];
                ActiveBitIndex = -1;
                listView2.Items.Clear();
                switch (ActiveLang)
                {
                    case 0:
                        ForCode.SetHighlighting("PHP");
                        break;
                    case 1:
                        ForCode.SetHighlighting("C#");
                        break;
                    case 2:
                        ForCode.SetHighlighting("JavaScript");
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
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("SELECT `id`, `Name`, `Description`, `Language`, `Syntax` FROM `UserBits` WHERE `Language` = '" + ActiveLang.ToString() + "';", connection);
                SQLiteDataReader CodeBits = command.ExecuteReader();

                while (CodeBits.Read())
                {
                    ListViewItem lvi;
                    lvi = listView2.Items.Add(CodeBits.GetString(1), CodeBits.GetInt16(0));
                    lvi.ImageIndex = CodeBits.GetInt16(3);
                    lvi.SubItems.Add(CodeBits.GetString(2));
                    lvi.SubItems.Add(CodeBits.GetInt16(0).ToString());
                    lvi.SubItems.Add(CodeBits.GetString(4));

                }
                connection.Close();
            }
                
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e) {
            if (listView2.SelectedIndices.Count>0) {
                ActiveBitIndex = listView2.SelectedIndices[0];
                ActiveBit = listView2.Items[listView2.SelectedIndices[0]].SubItems[2].Text;

                NameOfBit.Text = listView2.Items[listView2.SelectedIndices[0]].Text;
                DescOfBit.Text = listView2.Items[listView2.SelectedIndices[0]].SubItems[1].Text;
                ForCode.Text = listView2.Items[listView2.SelectedIndices[0]].SubItems[3].Text;
                ForCode.Refresh();
            }
        }

        private void NameOfBit_Enter(object sender, EventArgs e)
        {
            if (ActiveBitIndex>=0)
            {
                listView2.Items[ActiveBitIndex].Text = NameOfBit.Text;
            }
        }

        private void NameOfBit_KeyUp(object sender, KeyEventArgs e)
        {
            if (ActiveBitIndex >= 0)
            {
                listView2.Items[ActiveBitIndex].Text = NameOfBit.Text;
            }
        }

        private void DescOfBit_KeyUp(object sender, KeyEventArgs e)
        {
            if (ActiveBitIndex >= 0)
            {
                listView2.Items[ActiveBitIndex].SubItems[1].Text = DescOfBit.Text;
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            ListViewItem lvi;
            lvi = listView2.Items.Add("Новый кусок", ActiveLang);
            lvi.SubItems.Add("Описание");
            lvi.SubItems.Add("-1");
            lvi.SubItems.Add(" ");
        }

     
        private void ForCode_Enter(object sender, EventArgs e)
        {
            if (ActiveBitIndex >= 0)
            {
                listView2.Items[ActiveBitIndex].SubItems[3].Text = ForCode.Text;
            }
        }

        private void ForCode_DockChanged(object sender, EventArgs e)
        {
            if (ActiveBitIndex >= 0)
            {
                listView2.Items[ActiveBitIndex].SubItems[3].Text = ForCode.Text;
            }
        }

        private void ForCode_TextChanged(object sender, EventArgs e)
        {
            if (ActiveBitIndex >= 0)
            {
                listView2.Items[ActiveBitIndex].SubItems[3].Text = ForCode.Text;
            }
        }

        private void item2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveBitIndex >= 0)
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("DELETE FROM `UserBits` WHERE `id` = '" + ActiveBit + "';", connection);
                command.ExecuteNonQuery();
                connection.Close();

                listView2.Items.Clear();
                connection.Open();
                command = new SQLiteCommand("SELECT `id`, `Name`, `Description`, `Language`, `Syntax` FROM `UserBits` WHERE `Language` = '" + ActiveLang.ToString() + "';", connection);
                SQLiteDataReader CodeBits = command.ExecuteReader();

                while (CodeBits.Read())
                {
                    ListViewItem lvi;
                    lvi = listView2.Items.Add(CodeBits.GetString(1), CodeBits.GetInt16(0));
                    lvi.ImageIndex = CodeBits.GetInt16(3);
                    lvi.SubItems.Add(CodeBits.GetString(2));
                    lvi.SubItems.Add(CodeBits.GetInt16(0).ToString());
                    lvi.SubItems.Add(CodeBits.GetString(4));

                }
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            SQLiteCommand command;
            if (ActiveBit!="-1") {
                connection.Open();
                command = new SQLiteCommand("UPDATE `UserBits` SET `Name` = '" + NameOfBit.Text + "', `Description` = '"+DescOfBit.Text+"', `Syntax` = '"+ForCode.Text+"' WHERE `id` = '" + ActiveBit + "';", connection);
                command.ExecuteNonQuery();
                connection.Close();
            } else {
                connection.Open();
                command = new SQLiteCommand("INSERT INTO `UserBits` (`Name`, `Description`, `Syntax`, `Language`) VALUES ('" + NameOfBit.Text + "', '" + DescOfBit.Text + "', '" + ForCode.Text + "', '"+ActiveLang.ToString()+"');", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

            listView2.Items.Clear();

            connection.Open();
            command = new SQLiteCommand("SELECT `id`, `Name`, `Description`, `Language`, `Syntax` FROM `UserBits` WHERE `Language` = '" + ActiveLang.ToString() + "';", connection);
            SQLiteDataReader CodeBits = command.ExecuteReader();

            while (CodeBits.Read())
            {
                ListViewItem lvi;
                lvi = listView2.Items.Add(CodeBits.GetString(1), CodeBits.GetInt16(0));
                lvi.ImageIndex = CodeBits.GetInt16(3);
                lvi.SubItems.Add(CodeBits.GetString(2));
                lvi.SubItems.Add(CodeBits.GetInt16(0).ToString());
                lvi.SubItems.Add(CodeBits.GetString(4));

            }
            connection.Close();
        }
    }
}
