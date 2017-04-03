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
        int ActiveLang = 0, ActiveBitIndex = -1, ActiveUser = 0, IconIndex = 0;
        string ActiveBit = "-1";
        string baseName = "codebit.sqlite";
        public SQLiteConnection connection;
        SettingsForm secondForm;

        private void UpdateAllElements(int ID = -1) {
            ActiveBit = "-1";
            ActiveBitIndex = -1;
            listView2.Items.Clear();

            SQLiteCommand command = new SQLiteCommand("SELECT `id`, `Name`, `Description`, `Language`, `Syntax` FROM `UserBits` WHERE `Language` = @ID AND `UserID` = @USERID", connection);
            command.Parameters.Add("@ID", DbType.Int16);
            command.Parameters["@ID"].Value = ActiveLang;
            command.Parameters.Add("@USERID", DbType.Int16);
            command.Parameters["@USERID"].Value = ActiveUser;

            SQLiteDataReader CodeBits = command.ExecuteReader();

            while (CodeBits.Read())
            {
                ListViewItem lvi;
                lvi = listView2.Items.Add(CodeBits.GetString(1), IconIndex);
                lvi.SubItems.Add(CodeBits.GetString(2));
                lvi.SubItems.Add(CodeBits.GetInt16(0).ToString());
                lvi.SubItems.Add(CodeBits.GetString(4));

            }
            
            ForCode.Text = "";
            ForCode.Refresh();
            NameOfBit.Text = "";
            DescOfBit.Text = "";
            if (ID >=0) {
                listView2.Items[ID].Selected = true;
            } else {
                ActiveBit = ID.ToString();
                ActiveBitIndex = ID;
            }
        }

        public Form1() {
            InitializeComponent();

            connection = new SQLiteConnection(string.Format("Data Source={0};", baseName));
            secondForm = new SettingsForm(connection);

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan900, Primary.BlueGrey900, Primary.DeepOrange400, Accent.LightBlue200, TextShade.WHITE);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT COUNT(*) FROM `Users`", connection);
            SQLiteDataReader CodeBits = command.ExecuteReader();

            if (CodeBits.Read())
            {
                int count = CodeBits.GetInt16(0);
                
                if (count==0)
                {
                    command = new SQLiteCommand("INSERT INTO `Users` (`BaseID`, `Name`, `Key`, `Active`) VALUES ('0', 'Default', ' ', '1');", connection);
                    command.ExecuteNonQuery(); 
                }
                
                command = new SQLiteCommand("SELECT `LocalID` FROM `Users` WHERE `Active` = 1;", connection);
                CodeBits = command.ExecuteReader();
                if (CodeBits.Read())
                {
                    ActiveUser = CodeBits.GetInt16(0);
                }
                
            }

            command = new SQLiteCommand("SELECT `id`, `Name`, `SyntaxPrefix`, `IconIndex` FROM `Languages` WHERE `Active` = 1", connection);
            CodeBits = command.ExecuteReader();

            while (CodeBits.Read())
            {
                ListViewItem lvi;
                lvi = listView1.Items.Add(CodeBits.GetString(1), CodeBits.GetInt16(3));
                lvi.SubItems.Add(CodeBits.GetString(2));
                lvi.SubItems.Add(CodeBits.GetInt16(0).ToString());
            }

            UpdateAllElements();

            command = new SQLiteCommand("SELECT `id`, `Name`, `SyntaxPrefix`, `IconIndex`, `Active` FROM `Languages`", connection);
            CodeBits = command.ExecuteReader();

            while (CodeBits.Read())
            {
                ListViewItem lvi;
                lvi = secondForm.listView1.Items.Add(CodeBits.GetString(1), CodeBits.GetInt16(3));
                lvi.SubItems.Add(CodeBits.GetInt16(0).ToString());
                if (CodeBits.GetInt16(4) == 1) {
                    lvi.Checked = true;
                } else {
                    lvi.Checked = false;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e) {
            string dirc = Application.StartupPath;
            FileSyntaxModeProvider fsmp;
            if (Directory.Exists(dirc)) {
                fsmp = new FileSyntaxModeProvider(dirc);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
                ForCode.SetHighlighting("PHP");
            }
        }

        private void Form1_Resize(object sender, EventArgs e) {
            listView1.Height = this.Height - 119;
            listView2.Height = this.Height - 119;
            ForCode.Height = this.Height - 202;
            ForCode.Width = this.Width - 494;
            NameOfBit.Width = this.Width - 613;
            DescOfBit.Width = this.Width - 613;
            DeleteButton.Left = this.Width - 118;
            SettingsButton.Left = this.Width - 56;
        }

        
        private void ListView1_SelectedIndexChanged(object sender, EventArgs e) {
            ForCode.Text = "";
            ForCode.Refresh();
            ForCode.Enabled = false;
            NameOfBit.Text = "";
            NameOfBit.Enabled = false;
            DescOfBit.Text = "";
            DescOfBit.Enabled = false;
            ActiveBit = "-1";
            ActiveBitIndex = -1;

            if (listView1.SelectedIndices.Count > 0)
            {
                ActiveLang = Int32.Parse(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text);
                IconIndex = listView1.Items[listView1.SelectedIndices[0]].ImageIndex;
                ActiveBitIndex = -1;
                listView2.Items.Clear();
                String Synt = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text;
                ForCode.SetHighlighting(Synt);
                
                UpdateAllElements();
            }
                
        }

        private void ListView2_SelectedIndexChanged(object sender, EventArgs e) {
            if (listView2.SelectedIndices.Count>0) {
                ActiveBitIndex = listView2.SelectedIndices[0];
                ActiveBit = listView2.Items[listView2.SelectedIndices[0]].SubItems[2].Text;

                NameOfBit.Text = listView2.Items[listView2.SelectedIndices[0]].Text;
                NameOfBit.Enabled = true;
                DescOfBit.Text = listView2.Items[listView2.SelectedIndices[0]].SubItems[1].Text;
                DescOfBit.Enabled = true;
                ForCode.Text = listView2.Items[listView2.SelectedIndices[0]].SubItems[3].Text;
                ForCode.Refresh();
                ForCode.Enabled = true;
            } else {
                ActiveBitIndex = -1;
                ActiveBit = "-1";
                NameOfBit.Text = "";
                NameOfBit.Enabled = false;
                DescOfBit.Text = "";
                DescOfBit.Enabled = false;
                ForCode.Text = "";
                ForCode.Refresh();
                ForCode.Enabled = false;
            }
        }

        private void MaterialRaisedButton1_Click(object sender, EventArgs e)
        {
            Button2_Click(null, null);
            SQLiteCommand command = new SQLiteCommand("INSERT INTO `UserBits` (`Name`, `Description`, `Syntax`, `Language`, `UserID`) VALUES (@NAME, @DESCRIPTION, @SYNTAX, @LANGUAGE, @USERID);", connection);
            command.Parameters.Add("@LANGUAGE", DbType.Int16);
            command.Parameters["@LANGUAGE"].Value = ActiveLang;
            command.Parameters.AddWithValue("@NAME", "NewBit");
            command.Parameters.AddWithValue("@DESCRIPTION", "BitDescription");
            command.Parameters.AddWithValue("@SYNTAX", "");
            command.Parameters.Add("@USERID", DbType.Int16);
            command.Parameters["@USERID"].Value = ActiveUser;
            command.ExecuteNonQuery();
            UpdateAllElements();
            listView2.Items[listView2.Items.Count - 1].Selected = true;
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

        private void Item2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveBitIndex >= 0)
            {
                string message = "It will not be possible to cancel this operation.\nAre you sure you want to do this ?";
                string caption = "WARNING";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    SQLiteCommand command = new SQLiteCommand("DELETE FROM `UserBits` WHERE `id` = @ID;", connection);
                    command.Parameters.Add("@ID", DbType.Int16);
                    command.Parameters["@ID"].Value = ActiveBit;
                    command.ExecuteNonQuery();

                    UpdateAllElements();
                    ActiveBitIndex = -1;
                    ActiveBit = "-1";
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void NameOfBit_KeyUp(object sender, EventArgs e)
        {
            if (NameOfBit.Text.Length>25) {
                NameOfBit.Text = NameOfBit.Text.Substring(0, 25);
                NameOfBit.SelectionStart = NameOfBit.Text.Length;
            }
            if (ActiveBitIndex >= 0)
            {
                listView2.Items[ActiveBitIndex].Text = NameOfBit.Text;
            }
        }

        private void DescOfBit_TextChanged(object sender, EventArgs e)
        {
            if (DescOfBit.Text.Length > 125)
            {
                DescOfBit.Text = DescOfBit.Text.Substring(0, 125);
                DescOfBit.SelectionStart = DescOfBit.Text.Length;
            }
            if (ActiveBitIndex >= 0)
            {
                listView2.Items[ActiveBitIndex].SubItems[1].Text = DescOfBit.Text;
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            secondForm.Show();
        }

        private void IsTextChanged(object sender, EventArgs e)
        {
            if (ActiveBitIndex >= 0)
            {
                listView2.Items[ActiveBitIndex].SubItems[3].Text = ForCode.Text;
            }
        }

        private void Button1_Click(object sender, EventArgs e) {
            if (ForCode.Text.Length>0) {
                Clipboard.SetText(ForCode.Text);
            }
        }

        private void Button2_Click(object sender, EventArgs e) {
            if (ActiveBitIndex >= 0) {
                if (NameOfBit.Text.Length <= 0)
                {
                    MessageBox.Show("Please input Name for save", "WARNING");
                    return;
                }
                SQLiteCommand command;
                if (ActiveBit != "-1")
                {
                    command = new SQLiteCommand("UPDATE `UserBits` SET `Name` = @NAME, `Description` = @DESCRIPTION, `Syntax` = @SYNTAX WHERE `id` = @ID;", connection);
                    command.Parameters.Add("@ID", DbType.Int16);
                    command.Parameters["@ID"].Value = ActiveBit;
                    command.Parameters.AddWithValue("@NAME", NameOfBit.Text);
                    command.Parameters.AddWithValue("@DESCRIPTION", DescOfBit.Text);
                    command.Parameters.AddWithValue("@SYNTAX", ForCode.Text);
                    command.ExecuteNonQuery();
                }
                else
                {
                    command = new SQLiteCommand("INSERT INTO `UserBits` (`Name`, `Description`, `Syntax`, `Language`, `UserID`) VALUES (@NAME, @DESCRIPTION, @SYNTAX, @LANGUAGE, @USERID);", connection);
                    command.Parameters.Add("@LANGUAGE", DbType.Int16);
                    command.Parameters["@LANGUAGE"].Value = ActiveLang;
                    command.Parameters.AddWithValue("@NAME", NameOfBit.Text);
                    command.Parameters.AddWithValue("@DESCRIPTION", DescOfBit.Text);
                    command.Parameters.AddWithValue("@SYNTAX", ForCode.Text);
                    command.Parameters.Add("@USERID", DbType.Int16);
                    command.Parameters["@USERID"].Value = ActiveUser;
                    command.ExecuteNonQuery();
                }
                UpdateAllElements(ActiveBitIndex);
            }
        }
    }
}
