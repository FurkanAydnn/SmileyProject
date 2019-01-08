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
            foreach (Categories item in category)
            {
                Button b = new Button();
                b.Text = item.Category;
                b.Name = item.Category;
                b.Height = 60;
                b.Width = 125;
                b.Click += new EventHandler(b1_Click);
                flpMain.Controls.Add(b);
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            flpMain.Controls.Clear();
            foreach (Categories item in category)
            {
                if (item.Category == button.Name)
                {
                    foreach (var smiley in item.items)
                    {
                        Button b = new Button();
                        b.Text = smiley.Name + "\n" + smiley.Art;
                        b.Name = smiley.Art;
                        b.Height = 60;
                        b.Width = 125;
                        b.Click += new EventHandler(b2_Click);
                        flpMain.Controls.Add(b);
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
