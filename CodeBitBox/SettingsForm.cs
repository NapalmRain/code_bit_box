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
        public SettingsForm(SQLiteConnection c)
        {
            connection = c;
            InitializeComponent();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            SQLiteCommand command = new SQLiteCommand("UPDATE `Languages` SET `Active` = @ACTIVE WHERE `id` = @ID;", connection);

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                command.Parameters.Add("@ID", DbType.Int16);
                command.Parameters["@ID"].Value = listView1.Items[i].SubItems[1].Text;
                if (listView1.Items[i].Checked) {
                    command.Parameters.AddWithValue("@ACTIVE", 1);
                } else {
                    command.Parameters.AddWithValue("@ACTIVE", 0);
                }
                command.ExecuteNonQuery();
            }
            this.Close();
        }
    }
}
