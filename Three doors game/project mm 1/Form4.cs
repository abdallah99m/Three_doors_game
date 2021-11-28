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
   
    public partial class Form4 : Form
    {   List<CActor> Line = new List<CActor>();
        List<CActor1> L = new List<CActor1>();
        List<CActor1> Ltree = new List<CActor1>();
        List<CActor1> Lcloud = new List<CActor1>();
        Timer tt = new Timer();
        Bitmap unSeen;
        CActor pnn;
        CActor1 pnn1;
        Bitmap pnm;
        int ct = 0;
        int count = 0;
        Random rr = new Random();
        public Form4()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form4_Load;
            this.KeyDown += Form4_KeyDown;
            tt.Tick += Tt_Tick; ;
            tt.Start();
        }

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
          if(e.KeyCode==Keys.Space)
            { L[0].Y -= 150;
                L[0].j = 0;
                flage1 = 1;
            }
        }
        int flage = 0;
        int flage1 = 0;
        int by = 3;
        private void Tt_Tick(object sender, EventArgs e)
        {if(ct%1000==0)
            { by += 3; }
            ct += by ;
            if(flage==0)
            { L[0].X +=30;

                flage = 1;
            }
            ///////////gravity//////////

            if (L[0].Y + L[0].im[L[0].j].Height <= Line[0].Y)

            { L[0].Y += 5; }
            else { flage1 = 0; }
            ///////////move hero/////////////
            if (flage1 == 0)
            {
                if (count % 1 == 0)
                {
                    L[0].j++;
                    if (L[0].j >= 4)
                    { L[0].j = 0; }
                }
            }



            //////////////move treee//////////
            for(int i=0;i<Ltree.Count;i++)
            { Ltree[i].X += -1 * 25; }

            if (count % 50 == 0)
            {////////////////create tree//////////
                pnn1 = new CActor1();
                pnn1.X = this.Width + 100;
                pnn1.im = new List<Bitmap>();
                for (int k = 0; k < 3; k++)
                {
                    pnm = new Bitmap("n" + (k + 1) + ".png");
                    pnm.MakeTransparent(pnm.GetPixel(0, 0));
                    pnn1.im.Add(pnm);
                }
                pnn1.Y = this.Height / 2 - pnn1.im[0].Height + 100;

                pnn1.j = rr.Next(0, 3);
                pnn1.H = 0;
                Ltree.Add(pnn1);

            }
            ////////////////create cloud///////////////////////
            if (count % 20 == 0)
            {
                pnn1 = new CActor1();
                pnn1.X = this.Width + 100;
                pnn1.im = new List<Bitmap>();
                
                    pnm = new Bitmap("cloud.png");
                    pnm.MakeTransparent(pnm.GetPixel(0, 0));
                    pnn1.im.Add(pnm);
                
                pnn1.Y = rr.Next(100,200);

                pnn1.j = 0;
                pnn1.H = 0;
                Lcloud.Add(pnn1);

            }
            //////////////////move cloud//////////////
            for (int i = 0; i < Lcloud.Count; i++)
            { Lcloud[i].X += -1 * 20; }
            ///////check////////////
            for(int i=0;i<Ltree.Count;i++)
            { if (L[0].X + L[0].im[L[0].j].Width-20 >= Ltree[i].X && L[0].X + L[0].im[L[0].j].Width - 20 <= Ltree[i].X+Ltree[i].im[Ltree[0].j].Width && L[0].Y + L[0].im[L[0].j].Height - 20 <= Ltree[i].Y + Ltree[i].im[Ltree[0].j].Height&& L[0].Y + L[0].im[L[0].j].Height - 20 >= Ltree[i].Y)
                { this.Hide();
                    Form2 f2 = new Form2();
                    f2.Show();
                    tt.Stop();
                }
            }


            count++;
            DrawDubb(this.CreateGraphics());
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            unSeen = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            pnn = new CActor();
            pnn.X = 0;
            pnn.Y = this.Height/2+100;
            pnn.w = this.Width;
            pnn.h = this.Height / 2 + 100;
            Line.Add(pnn);

            pnn1 = new CActor1();

            pnn1.X = 10;

            pnn1.im = new List<Bitmap>();
            for (int k = 0; k < 4; k++)
            {
                pnm = new Bitmap("t"+(k + 1) + ".png");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn1.im.Add(pnm);
            }
            pnn1.Y = this.Height/2 - pnn1.im[0].Height+100 ;
            pnn1.j = 0;
            pnn1.H = 0;
            L.Add(pnn1);
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
            g.Clear(Color.White);
            SolidBrush bb = new SolidBrush(Color.Black);
            for (int i = 0; i < Line.Count; i++)
            {
                g.FillRectangle(bb, Line[i].X, Line[i].Y, Line[i].w, Line[i].h);
            }
            for (int i = 0; i < Ltree.Count; i++)
            {
                g.DrawImage(Ltree[i].im[Ltree[i].j], Ltree[i].X, Ltree[i].Y);
            }
            for (int i = 0; i < Lcloud.Count; i++)
            {
                g.DrawImage(Lcloud[i].im[Lcloud[i].j], Lcloud[i].X, Lcloud[i].Y);
            }
            for (int i = 0; i < L.Count; i++)
            {
                g.DrawImage(L[i].im[L[i].j], L[i].X, L[i].Y);
            }
            string drawString = "score:" + ct;
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x = 900.0F;
            float y = 50.0F;
            StringFormat drawFormat = new StringFormat();
            g.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
           

            drawFont.Dispose();
            drawBrush.Dispose();





        }
    }
}
