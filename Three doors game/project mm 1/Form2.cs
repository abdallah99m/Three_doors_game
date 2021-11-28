using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_mm_1
{
    
    public partial class Form2 : Form
    {
        List<CActor> ldoor = new List<CActor>();
        List<CActor> limg = new List<CActor>();
        Bitmap unSeen;
        CActor pnn;
        public Form2()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Form2_Paint;
         //   this.KeyDown += Form2_KeyDown;
            this.MouseDown += Form2_MouseDown;
            this.Load += Form2_Load;
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if( e.X>limg[0].X&& e.X < limg[0].X+ limg[0].img.Width&& e.Y > limg[0].Y&& e.Y < limg[0].Y + limg[0].img.Height)
            {
                limg[0].Y += 10;
                DrawDubb(this.CreateGraphics());
                this.Hide();
                Form1 obj = new Form1();
                obj.Show();

            }
            if (e.X > limg[1].X && e.X < limg[1].X + limg[1].img.Width && e.Y > limg[1].Y && e.Y < limg[1].Y + limg[1].img.Height)
            {
                limg[1].Y += 10;
                DrawDubb(this.CreateGraphics());
                this.Hide();
                Form3 obj = new Form3();
                obj.Show();

            }
            if (e.X > limg[2].X && e.X < limg[2].X + limg[2].img.Width && e.Y > limg[2].Y && e.Y < limg[2].Y + limg[2].img.Height)
            {
                limg[2].Y += 10;
                DrawDubb(this.CreateGraphics());
                this.Hide();
                Form4 obj = new Form4();
                obj.Show();

            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            unSeen = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            pnn = new CActor();
           
            pnn.img = new Bitmap("door.png");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            pnn.rcSrc = new Rectangle(0, 0, pnn.img.Width, pnn.img.Height);
            pnn.rcDst = new Rectangle(0, 0, this.Width , this.Height);
            ldoor.Add(pnn);

            pnn = new CActor();
            pnn.img = new Bitmap("start.jpg");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
           
            pnn.X = 170;
            pnn.Y = this.Height /2+100;
            limg.Add(pnn);

            pnn = new CActor();
            pnn.img = new Bitmap("start.jpg");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));

            pnn.X = 620;
            pnn.Y = this.Height / 2 + 100;
            limg.Add(pnn);

            pnn = new CActor();
            pnn.img = new Bitmap("start.jpg");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));

            pnn.X = 1070;
            pnn.Y = this.Height / 2 + 100;
            limg.Add(pnn);
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(this.CreateGraphics());
        }

       /* private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Right)
            { ldoor[1].X +=10; }
            if (e.KeyCode == Keys.Left)
            { ldoor[1].X -= 10; }
            if (e.KeyCode == Keys.Up)
            { ldoor[1].Y -= 10; }
            if (e.KeyCode == Keys.Down)
            { ldoor[1].Y += 10; }


            /*if (e.KeyCode==Keys.NumPad1)
            {if (ldoor[1].X < this.Width / 3)
                {
                    this.Hide();
                    Form1 obj = new Form1();
                    obj.Show();
                }
                
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                if (ldoor[1].X < this.Width / 3*2)
                {
                    this.Hide();
                    Form3 obj = new Form3();
                    obj.Show();
                }

            }
            DrawDubb(this.CreateGraphics());
        }*/
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(unSeen);
            DrawScene(g2);
            g.DrawImage(unSeen, 0, 0);
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.Gray);
            SolidBrush bb = new SolidBrush(Color.Black);
            g.DrawImage(ldoor[0].img, ldoor[0].rcDst, ldoor[0].rcSrc, GraphicsUnit.Pixel);
            for (int i = 0; i < limg.Count; i++)
            {
                g.DrawImage(limg[i].img, limg[i].X, limg[i].Y);
            }
        }
    }
}
