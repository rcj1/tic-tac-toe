using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{   
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
            Form1_Load();
            Game_Start();

        }

        private void Game_Start()
        {
            this.xplaces = new List<string>();
            this.oplaces = new List<string>();
            this.x = r.Next(2);
            //this.textBox1.Text = "";
            foreach (Control ctrl in this.tableLayoutPanel1.Controls)
            {
                ctrl.Text = "";
            }
            this.textBox2.Text = string.Format("{0} is playing", symbols[x]);
        }

        private static Random r = new Random();
        List<String> xplaces;
        List<String> oplaces;
        List<List<string>> winners = new List<List<string>>()
            {
                new List<string>()
                {
                    "00", "01", "02"
                },
                new List<string>()
                {
                    "10", "11", "12"
                },
                new List<string>()
                {
                    "20", "21", "22"
                },
                new List<string>()
                {
                    "00", "10", "20"
                },
                new List<string>()
                {
                    "01", "11", "21"
                },
                new List<string>()
                {
                    "02", "12", "22"
                },
                new List<string>()
                {
                    "00", "11", "22"
                },
                new List<string>()
                {
                    "02", "11", "20"
                },
            };
        int x;
        String[] symbols = { "O", "X" };

        protected void add_place(object sender, int x)
        {
            string name = ((Button)sender).Name;
            if (x == 0)
            {
                xplaces.Add(name);
            }
            else
            {
                oplaces.Add(name);
            }
        }


        protected bool check_for_win(int x)
        {
            List<string> myl;
            if (x == 0)
            {
                myl = xplaces;
            }
            else
            {
                myl = oplaces;
            }

            foreach(List<string> l in winners)
            {
                if (myl.Contains(l[0]) && myl.Contains(l[1]) && myl.Contains(l[2])) {
                    
                    return true;
                }
            }
            return false;
        }

        protected void letter_change(int newx)
        {
            x = newx;
            this.textBox2.Text = string.Format("{0} is playing", symbols[newx]);
        }

        private void buttonClick(object sender, EventArgs e)
        {
            (sender as Button).Text = symbols[x];
            add_place(sender, x);
            var temp = x;
            if (x == 0)
            {
                letter_change(1);
                this.textBox1.Text = "";
            }
            else
            {
                letter_change(0);
                this.textBox1.Text = "";
            }

            if (check_for_win(temp))
            {
                this.textBox1.Text = string.Format("{0} won", symbols[temp]);
                System.Threading.Thread.Sleep(200);
                Game_Start();
            }
        }
    }
}
