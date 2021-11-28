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
    public class CActor
    {
        public int X, w,h,Y;
        public Bitmap img;
        public int dx;
        public int dy;
        public Rectangle rcSrc;
        public Rectangle rcDst;

    }
    public partial class Form1 : Form
    {
        List<CActor> Line = new List<CActor>();
        List<CActor> limg = new  List<CActor>();
        List<CActor> ltree = new List<CActor>();
        List<CActor> lrec = new List<CActor>();
        List<CActor> lenm = new List<CActor>();
        List<CActor> Line1 = new List<CActor>();
        List<CActor> ldouble = new List<CActor>();
        Timer tt = new Timer();
        Bitmap unSeen;
        int counttick = 0;
         int catch1=0;
        int ct = 0,ct2=0,by=2;
        Random rr = new Random();
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Form1_Paint1;
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
            tt.Tick += Tt_Tick;
            tt.Start();
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (limg[0].X + limg[0].img.Width < this.Width / 4 * 3 + 50)
                {
                    limg[0].X += 5;
                }

            }
            if (e.KeyCode == Keys.Left)
            {
                if (limg[0].X > this.Width / 4 - 50)
                {
                    limg[0].X -= 5;
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
                Form2 obj = new Form2();
                obj.Show();
            }
            if (e.KeyCode == Keys.Space)
            {
                CActor pnn = new CActor();
                pnn.X = limg[0].img.Width / 2 + limg[0].X;
                pnn.Y = this.Height - limg[0].img.Height;
                pnn.w = limg[0].img.Width / 2 + limg[0].X;
                pnn.h = 0;
                Line1.Add(pnn);
                for (int i = 0; i < lenm.Count; i++)
                {
                    if (lenm[i].X < Line1[0].X && lenm[i].X + lenm[i].img.Width > Line1[0].X)
                    { lenm.RemoveAt(i);
                        ct2++;
                    }
                }
                flage1 = 1;
                
            }
        }
        int flage1 = 0;
        int flage = 0;
        private void Tt_Tick(object sender, EventArgs e)
        {if(ct2%10==0)
            { by++; }
            ct+=by;
            CActor pnn;
            if (flage == 0)
            {
                if (counttick % 1 == 0)
                {
                    for (int i = 0; i < lenm.Count; i++)
                    {
                        if (lenm[i].Y>this.Height)
                        { lenm.RemoveAt(i); }
                    }
                    for (int i = 0; i < lenm.Count; i++)
                    {
                        if (lenm[i].X > limg[0].X && lenm[i].X < limg[0].img.Width + limg[0].X && lenm[i].Y+lenm[i].img.Height >= limg[0].Y)
                        {
                            this.Hide();
                            //MessageBox.Show("game over");
                            Form2 obj = new Form2();
                            obj.Show();
                            tt.Stop();
                            flage = 1;
                            break;
                        }
                    }
                    if (Line[Line.Count - 1].Y >= 20)
                    {
                        pnn = new CActor();
                        pnn.X = this.ClientSize.Width / 2;
                        pnn.Y = -30;
                        pnn.w = 5;
                        pnn.h = 30;
                        Line.Add(pnn);
                    }
                    for (int i = 0; i < Line.Count; i++)
                    {
                        Line[i].Y += 10;
                    }
                   /* for (int i = 0; i < lrec.Count; i++)
                    {
                        lrec[i].rcSrc = new Rectangle(
                                                lrec[i].rcSrc.Left,
                                                lrec[i].rcSrc.Top - 10,
                                                lrec[i].rcSrc.Width,
                                                lrec[i].rcSrc.Height);
                    }
                    */
                    for(int i=0;i<lrec.Count;i++)
                    { lrec[i].Y += 10; }
                    for (int i = 0; i < lenm.Count; i++)
                    {
                        lenm[i].Y += 10;
                    }
                }
                if (counttick % 10 == 0)
                {
                    pnn = new CActor();
                    pnn.X = rr.Next(this.Width / 4, this.Width / 4 * 3);
                    pnn.Y = 0;
                    pnn.img = new Bitmap("image_1.bmp");
                    pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                    lenm.Add(pnn);

                }
                if(counttick%20==0)
                {
                    pnn = new CActor();
                    pnn.img = new Bitmap("tree.png");
                    pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                    //pnn.rcSrc = new Rectangle(0, 0, pnn.img.Width, pnn.img.Height);
                    //pnn.rcDst = new Rectangle(0, 0, this.Width / 4 - 50, this.Height);
                    pnn.X = this.Width / 4 - pnn.img.Width-50;
                    pnn.Y = 0;

                    lrec.Add(pnn);


                    pnn = new CActor();
                    pnn.img = new Bitmap("tree1.png");
                    pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                    //pnn.rcSrc = new Rectangle(0, 0, pnn.img.Width, pnn.img.Height);
                    //pnn.rcDst = new Rectangle(0, 0, this.Width / 4 - 50, this.Height);
                    pnn.X = this.Width / 4 - pnn.img.Width - 50-200;
                    pnn.Y =-100;

                    lrec.Add(pnn);


                    pnn = new CActor();
                    pnn.img = new Bitmap("tree2.png");
                    pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                    //pnn.rcSrc = new Rectangle(0, 0, pnn.img.Width, pnn.img.Height);
                    //pnn.rcDst = new Rectangle(0, 0, this.Width / 4 - 50, this.Height);
                    pnn.X = this.Width / 4 * 3 + 50 + 10;
                    pnn.Y = 0;

                    lrec.Add(pnn);

                    pnn = new CActor();
                    pnn.img = new Bitmap("tree3.png");
                    pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                    //pnn.rcSrc = new Rectangle(0, 0, pnn.img.Width, pnn.img.Height);
                    //pnn.rcDst = new Rectangle(0, 0, this.Width / 4 - 50, this.Height);
                    pnn.X = this.Width / 4 * 3 + 50 + 10+150;
                    pnn.Y = -100;

                    lrec.Add(pnn);
                }
               /* if(counttick%70==0)
                {
                    pnn = new CActor();
                    pnn.X = rr.Next(this.Width / 4, this.Width / 4 * 3);
                    pnn.Y = 0;
                    pnn.img = new Bitmap("image_1.bmp");
                    pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                    lenm.Add(pnn);
                }*/
                counttick++;
                DrawDubb(this.CreateGraphics());
            }
        }
        int y=0;
        private void Form1_Load(object sender, EventArgs e)
        {
            unSeen = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            CActor pnn;
            for(; ; )
            {
                 pnn = new CActor();
                pnn.X = this.ClientSize.Width / 2;
                pnn.Y = y;
                pnn.w = 5;
                pnn.h = 30;
                Line.Add(pnn);
                  y += 50;
                if(y>this.Height)
                { break;
                }
            }
            pnn = new CActor();
            pnn.img = new Bitmap("car.jpg");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            pnn.X = this.Width / 2 +50;
            pnn.Y = this.Height - pnn.img.Height-50;
            limg.Add(pnn);
            y = 0;

          
           

            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Paint1(object sender, PaintEventArgs e)
        {
            DrawDubb(this.CreateGraphics());
        }

        

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
            for (int i=0;i<Line.Count;i++)
            { g.FillRectangle(bb, Line[i].X, Line[i].Y, Line[i].w, Line[i].h);
            }
            g.FillRectangle(bb, this.Width / 4-50, 0, 10, this.Height);
            g.FillRectangle(bb, this.Width / 4*3+50, 0, 10, this.Height);
            g.DrawImage(limg[0].img,
                            limg[0].X,
                            limg[0].Y);
            for(int i=0;i<lrec.Count;i++)
            { //g.DrawImage(lrec[i].img, lrec[i].rcDst, lrec[i].rcSrc, GraphicsUnit.Pixel);
                g.DrawImage(lrec[i].img, lrec[i].X, lrec[i].Y);
            }
            if (flage1 == 1)
            {
                g.DrawLine(Pens.Yellow, Line1[0].X, Line1[0].Y, Line1[0].w, Line1[0].h);
                flage1 = 0;
                Line1.Clear();
            }
            for (int i = 0; i < lenm.Count; i++)
            {
                g.DrawImage(lenm[i].img, lenm[i].X, lenm[i].Y);
            }
            
          
            string drawString = "score:"+ ct;
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x = 450.0F;
            float y = 50.0F;
           StringFormat drawFormat = new StringFormat();
            g.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
            drawString = "kills:" + ct2;
            x = 750.0F;
            g.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);

            drawFont.Dispose();
            drawBrush.Dispose();

           
            


        }
    }
}
