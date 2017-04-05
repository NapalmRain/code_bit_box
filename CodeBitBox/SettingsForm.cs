using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SQLite;

namespace CodeBitBox
{
    public partial class SettingsForm : MaterialForm
    {
        SQLiteConnection connection;
        Form1 f;
        public SettingsForm(SQLiteConnection c, Form1 f1)
        {
            connection = c;
            f = f1;
            InitializeComponent();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            SQLiteCommand command = new SQLiteCommand("UPDATE `Languages` SET `Active` = 1", connection);
            command.ExecuteNonQuery();

            command = new SQLiteCommand("UPDATE `Languages` SET `Active` = @ACTIVE WHERE `id` = @ID;", connection);

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (!listView1.Items[i].Checked) {
                    command.Parameters.Add("@ID", DbType.Int16);
                    command.Parameters["@ID"].Value = listView1.Items[i].SubItems[1].Text;
                    command.Parameters.AddWithValue("@ACTIVE", 0);
                    command.ExecuteNonQuery();
                }
            }
            f.listView1.Items.Clear();
            command = new SQLiteCommand("SELECT `id`, `Name`, `SyntaxPrefix`, `IconIndex` FROM `Languages` WHERE `Active` = 1", connection);
            SQLiteDataReader CodeBits = command.ExecuteReader();

            while (CodeBits.Read())
            {
                ListViewItem lvi;
                lvi = f.listView1.Items.Add(CodeBits.GetString(1), CodeBits.GetInt16(3));
                lvi.SubItems.Add(CodeBits.GetString(2));
                lvi.SubItems.Add(CodeBits.GetInt16(0).ToString());
            }
            this.Hide();
        }
    }
}
