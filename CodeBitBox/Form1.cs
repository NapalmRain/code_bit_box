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

namespace CodeBitBox
{
    public partial class Form1 : MaterialForm
    {
        public Form1() {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan900, Primary.BlueGrey900, Primary.DeepOrange400, Accent.LightBlue200, TextShade.WHITE);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            listView1.Height = this.Height - 66;
        }
    }
}
