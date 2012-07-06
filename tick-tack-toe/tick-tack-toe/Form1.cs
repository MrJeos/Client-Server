using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tick_tack_toe
{
    public partial class Form1 : Form
    {
        private int[,] Pole = new int[3, 3];

        private const int W = 60, H = 60;

        private System.Drawing.Graphics g;

        private int what = 0;

        public Form1()
        {
            InitializeComponent();

            int row, col;

            for (row = 0; row < 3; row++) 
                for (col = 0; col < 3; col++)
                    Pole[row,col] = 0;

            g = panel1.CreateGraphics();

        }

        private void Show_game(Graphics g, int what)
        {
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    this.field(g, row, col, what);
        }
        private void field(Graphics g, int row, int col, int  what)
        {
            int x, y;

            x = col * W + 1;
            y = row * H + 1;

            if (what == 0)
            {
                g.DrawRectangle(Pens.Black, x - 1, y - 1, W, H);
            }

            if (what == 1)
            {
                draw_cross(g, x, y);
            }
            
            if (what == 2)
            {
                draw_nil(g, x, y);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Show_game(g, what);
            what = 1;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int row = (int)(e.Y / H);
            int col = (int)(e.X / W);

            this.field(g, row, col, what);

            if (what == 1)
            {
                Pole[row, col] = 1;
                what = 2;
            }
            else
            {
                Pole[row,col] = 0;
                what = 1;
            }
        }

        private void draw_cross(Graphics g, int x, int y)
        {
            Pen p = new Pen(Brushes.Black, 3);
            g.DrawLine(p, x + 5, y + 5, x + W - 5, y + H - 5);
            g.DrawLine(p, x + W - 5, y + 5, x + 5, y + H - 5);
        }

        private void draw_nil(Graphics g, int x, int y)
        {
            Pen p = new Pen(Brushes.Black, 5);
            g.DrawPie(p, x + 5, y + 5, W - 10, H - 10, 0, 360);
            g.FillPie(Brushes.White, x + 5, y + 5, W - 10, H - 10, 0, 360);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }
    }
}
