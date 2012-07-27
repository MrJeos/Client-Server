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
        private int[,] Pole = new int[3, 3];  // игровое поле - массив 3 х 3

        private const int W = 60, H = 60;     // ширина и высота одной клетки игрового поля

        private System.Drawing.Graphics g;

        private int what = 0;                 // переменная, показывающая кто ходит (0 - начало игры,
                                              // 1 - ходит первый игрок, 2 - ходит второй игрок)
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void Show_game(Graphics g, int what)   // отображает поле в начале игры
        {           
            int row, col;                     
            for (row = 0; row < 3; row++) 
                for (col = 0; col < 3; col++) 
                    Pole[row,col] = 0;

            g.Clear(Color.White);

            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    this.field(g, r, c, what);
        }
        private void field(Graphics g, int row, int col, int  what)  // в зависимости от значения переменной what, либо отображает поле в начале игры
        {                                                            // либо рисует крестик, либо нолик в клетке с [row, col]
            int x, y;

            x = col * W + 1;
            y = row * H + 1;

            if (what == 0)
                g.DrawRectangle(Pens.Black, x - 1, y - 1, W, H);
            if (what == 1) 
                draw_cross(g, x, y);
            if (what == 2) 
                draw_nil(g, x, y);
        }

        private bool if_win()
        {
            for (int i = 0; i < 3; i++)
            {
                if ((Pole[i, 0] + Pole[i, 1] + Pole[i, 2] == 6) || (Pole[0, i] + Pole[1, i] + Pole[2, i] == 6) || (Pole[0, 0] + Pole[1, 1] + Pole[2, 2] == 6) || (Pole[0, 2] + Pole[1, 1] + Pole[2, 0] == 6) || (Pole[i, 0] + Pole[i, 1] + Pole[i, 2] == 15) || (Pole[0, i] + Pole[1, i] + Pole[2, i] == 15) || (Pole[0, 0] + Pole[1, 1] + Pole[2, 2] == 15) || (Pole[0, 2] + Pole[1, 1] + Pole[2, 0] == 15))
                {
                    return true;
                }
            }
            return false;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)  // начало игры
        {
            Show_game(g, what);
            what = 1;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)  // заполнение массива и отображение крестиков, ноликов
        {
            int row = (int)(e.Y / H);
            int col = (int)(e.X / W);

            if (Pole[row,col] == 0)
            {
                this.field(g, row, col, what);

                if (what == 1)
                {
                    Pole[row, col] = 2;
                    what = 2;
                    if (if_win())
                    {
                        label1.Text = "Вы победили";
                        Form2 f2 = new Form2();
                        f2.ShowDialog();
                        if (DialogResult.OK == f2.DialogResult)
                        {
                            Show_game(g, 0);
                        }
                        else Close();
                    }
                    else label1.Text = "Ход соперника";
                }
                else
                {
                    Pole[row, col] = 5;
                    what = 1;
                    if (if_win())
                    {
                        label1.Text = "Соперник победил";
                        Form2 f2 = new Form2();
                        f2.ShowDialog();
                        if (DialogResult.OK == f2.DialogResult)
                        {
                            Show_game(g, 0);
                        }
                        else Close();

                    }
                    else label1.Text = "Ваш ход";
                }
            }
        }

        private void draw_cross(Graphics g, int x, int y)    //нарисовать крестик
        {
            Pen p = new Pen(Brushes.Black, 3);
            g.DrawLine(p, x + 5, y + 5, x + W - 5, y + H - 5);
            g.DrawLine(p, x + W - 5, y + 5, x + 5, y + H - 5);
        }

        private void draw_nil(Graphics g, int x, int y)      // нарисовать нолик
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
            label1.Visible = true;
            button3.Visible = true;
            button3.Enabled = true;
            label1.Text = "Ваш ход";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if (DialogResult.OK == f2.DialogResult)
            {
                Show_game(g, 0);
            }
            else Close();
        }
    }
}
