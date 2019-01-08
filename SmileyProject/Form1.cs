using SmileyProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmileyProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Categories> category = Program.jsonHelper.GetCategories();
        private void Form1_Load(object sender, EventArgs e)
        {
            btnBack.Visible = false;
            foreach (Categories item in category)
            {
                CreateButton(item.Category, item.Category);
            }
        }

        private void CreateButton(string buttonText, string buttonName,bool isCat = true)
        {
            Button b = new Button();
            b.Text = buttonText;
            b.Name = buttonName;
            b.Height = 60;
            b.Width = 125;
            if (isCat is true)
                b.Click += new EventHandler(b1_Click);
            else
                b.Click += new EventHandler(b2_Click);
            flpMain.Controls.Add(b);
        }

        private void b1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            btnBack.Visible = true;

            flpMain.Controls.Clear();
            foreach (Categories item in category)
            {
                if (item.Category == button.Name)
                {
                    foreach (var smiley in item.items)
                    {
                        CreateButton(smiley.Name + "\n" + smiley.Art, smiley.Art,false);
                    }
                }
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Clipboard.SetText(button.Name);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            flpMain.Controls.Clear();
            Form1_Load(sender, e);
        }
    }
}
