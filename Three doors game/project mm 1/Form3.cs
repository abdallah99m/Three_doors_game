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
    public class CActor1
    {
        public int X, Y, W, H,ca;
        public List<Bitmap> im;
        public int j;
        public Rectangle rcSrc;
        public Rectangle rcDst;

    }
    public partial class Form3 : Form
    {
        Timer tt = new Timer();
        List<CActor1> L = new List<CActor1>();
        List<CActor1> Line = new List<CActor1>();
        List<CActor1> lbul = new List<CActor1>();
        List<CActor1> lenm = new List<CActor1>();
        List<CActor1> lenmbul = new List<CActor1>();
        List<CActor1> lgra = new List<CActor1>();
        List<CActor1> lcoin = new List<CActor1>();
        List<CActor1> lheart = new List<CActor1>();
        Bitmap unSeen;
        bool stop = false;
        int count = 0;
        int flage = 0;
        int flage0 = 0;
        int flage1=0;
        int flage2 = 0;
        int flage3 = 0;
        int flage4 = 0;
        int ct = 0;
        public Form3()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Form3_Paint;
            this.Load += Form3_Load;
            this.KeyDown += Form3_KeyDown;
            tt.Tick += Tt_Tick;
            tt.Start();
        }

        private void Tt_Tick(object sender, EventArgs e)
        {

            /////gravity//////
            if (Line[4].W == 0)
            {
                for (int i = Line.Count - 2; i >= 0; i--)
                {
                    if (L[0].Y + L[0].im[L[0].j].Height >= Line[i].rcDst.Top - 20 && L[0].Y + L[0].im[L[0].j].Height <= Line[i].rcDst.Top && L[0].X >= Line[i].rcDst.Left && L[0].X <= Line[i].rcDst.Left + Line[i].rcDst.Width)
                    {
                        flage = 1;
                        break;
                    }
                    else { flage = 0; }
                }
                if (flage == 0)
                {
                    for (int i = Line.Count - 2; i >= 0; i--)
                    {
                        if (L[0].Y + L[0].im[L[0].j].Height <= Line[i].rcDst.Top - 10)
                        {
                            L[0].Y += 5;
                            break;
                        }
                    }
                }
            }

            ///move enemy bulet///
            for (int i = 0; i < lenmbul.Count; i++)
            { lenmbul[i].X -= 15; }
            ///move hero bulet///
            for (int i = 0; i < lbul.Count; i++)
            { lbul[i].X += 15;
            }

            ////elevator///
            if (L[0].X > Line[4].rcDst.Left && L[0].X < Line[4].rcDst.Left + 100 && L[0].Y > Line[4].rcDst.Top- L[0].im[L[0].j].Height-15 )
            { Line[4].W = 1;
            }
            else { Line[4].W = 0;
            }


            if (Line[4].W == 1)
            {
                int a = Line[4].rcDst.Top + Line[4].H * 5;
                Line[4].rcDst = new Rectangle(
                                                  Line[4].rcDst.Left,
                                                  a,
                                                  Line[4].rcDst.Width,
                                                  Line[4].rcDst.Height);
                L[0].Y += Line[4].H * 5;
                if (a <= 100)
                { Line[4].H = 1;
                }
                if (a >= this.Height - 60 - 10)
                { Line[4].H = -1; }

            }
            else {
                Line[4].rcDst = new Rectangle(
                                               Line[4].rcDst.Left,
                                               this.Height - 60 - 10,
                                               Line[4].rcDst.Width,
                                               Line[4].rcDst.Height);
            }


            ///move enemy 1 and 2////

            if (count % 3 == 0)
            { if (flage0 == 0)
                {
                    if (lenm[0].X < 1000 - 50 && lenm[0].H == 0)
                    {
                        lenm[0].X += lenm[0].W * 15;
                        lenm[0].j++;
                        if (lenm[0].j >= 4)
                        {
                            lenm[0].j = 0;
                        }
                    }
                    else
                    {
                        lenm[0].H = 1;
                        lenm[0].W = -1;


                    }
                    if (lenm[0].X > 400 && lenm[0].H == 1)
                    {
                        lenm[0].X += lenm[0].W * 15;
                        lenm[0].j++;
                        if (lenm[0].j >= 8)
                        {
                            lenm[0].j = 4;
                        }
                    }
                    else
                    {
                        lenm[0].H = 0;
                        lenm[0].W = 1;

                    }
                    if (L[0].X + L[0].im[L[0].j].Width > lenm[0].X && L[0].X + L[0].im[L[0].j].Width < lenm[0].X + lenm[0].im[lenm[0].j].Width && L[0].Y > lenm[0].Y - 150 && L[0].Y < lenm[0].im[lenm[0].j].Width + lenm[0].Y)
                    {
                        this.Hide();
                        Form2 obj = new Form2();
                        obj.Show();
                    }

                }
                if (flage1 == 0)
                {
                    if (lenm[1].X < this.Width - 50 && lenm[1].H == 0)
                    {
                        lenm[1].X += lenm[1].W * 10;
                        lenm[1].j++;
                        if (lenm[1].j >= 4)
                        {
                            lenm[1].j = 0;
                        }
                    }
                    else
                    {
                        lenm[1].H = 1;
                        lenm[1].W = -1;


                    }
                    if (lenm[1].X > 400 && lenm[1].H == 1 && flage1 == 0)
                    {
                        lenm[1].X += lenm[1].W * 10;
                        lenm[1].j++;
                        if (lenm[1].j >= 8)
                        {
                            lenm[1].j = 4;
                        }
                    }
                    else
                    {
                        lenm[1].H = 0;
                        lenm[1].W = 1;

                    }

                }
            }


            ///check hero bulet////
            for (int i = 0; i < lbul.Count; i++)
            {
                for (int j = 0; j < lenm.Count; j++)
                {
                    if (lbul[i].X + lbul[i].im[0].Width > lenm[j].X && lbul[i].X + lbul[i].im[0].Width < lenm[j].X + lenm[j].im[lenm[j].j].Width && lbul[i].Y > lenm[j].Y && lbul[i].Y < lenm[j].Y + lenm[j].im[lenm[j].j].Height)
                    { if (lenm[j].ca == 0)
                        { flage0 = 1;
                        }
                        if (lenm[j].ca == 1)
                        {
                            flage1 = 1;
                        }
                        if (lenm[j].ca == 2)
                        {
                            flage2 = 1;
                        }
                        if (lenm[j].ca == 3)
                        {
                            flage3 = 1;
                        }
                        lbul.RemoveAt(i);
                        lenm.RemoveAt(j);
                        break;

                    }
                }

            }
            ////check hero bulet with enemy bulet//

            for (int i = 0; i < lbul.Count; i++)
            {
                for (int j = 0; j < lenmbul.Count; j++)
                {
                    if (lbul[i].X + lbul[i].im[0].Width > lenmbul[j].X && lbul[i].X + lbul[i].im[0].Width < lenmbul[j].X + lenmbul[j].im[lenmbul[j].j].Width && lbul[i].Y > lenmbul[j].Y && lbul[i].Y < lenmbul[j].Y + lenmbul[j].im[lenmbul[j].j].Height)
                    {
                        lbul.RemoveAt(i);
                        lenmbul.RemoveAt(j); j--;
                        i--;
                    }
                }

            }
            ///check enemy bulet////
            for (int i = 0; i < lenmbul.Count; i++)
            {
                if (lenmbul[i].X >= L[0].X && lenmbul[i].X <= L[0].X + L[0].im[L[0].j].Width && lenmbul[i].Y >= L[0].Y && lenmbul[i].Y <= L[0].Y + L[0].im[L[0].j].Height)
                { L[0].H++;
                    lenmbul.RemoveAt(i);
                    lheart.RemoveAt(lheart.Count - 1);
                }
            }



            ////delete hero bulet///
            for (int i = 0; i < lbul.Count; i++)
            { if (lbul[i].X > this.Width)
                {
                    lbul.RemoveAt(i);
                }
            }
            //// enemy bulet create//

            if (count % 50 == 0)
            {
                if (flage3 != 1)
                {
                    pnn = new CActor1();
                    pnn.im = new List<Bitmap>();

                    pnm = new Bitmap("bul" + ".jpg");
                    pnm.MakeTransparent(pnm.GetPixel(0, 0));
                    pnn.im.Add(pnm);

                    pnn.X = this.Width - 150;
                    pnn.Y = 450 - 80;
                    pnn.j = 0;
                    pnn.W = -1;
                    pnn.H = 0;
                    lenmbul.Add(pnn);

                }
                if (flage2 != 1)
                {
                    pnn = new CActor1();
                    pnn.im = new List<Bitmap>();

                    pnm = new Bitmap("bul" + ".jpg");
                    pnm.MakeTransparent(pnm.GetPixel(0, 0));
                    pnn.im.Add(pnm);

                    pnn.X = this.Width - 150;
                    pnn.Y = 300 - 80;
                    pnn.j = 0;
                    pnn.W = -1;
                    pnn.H = 0;
                    lenmbul.Add(pnn);
                }
            }

            ///check the key////
            if (L[0].X >= lgra[0].X && L[0].X <= lgra[0].X + lgra[0].im[0].Width && L[0].Y <= 450 && L[0].Y >= 300)
            {
                flage4 = 1;
                lgra.RemoveAt(0);
            }
            ///move the door///
            if (flage4 == 1)
            {
                lgra[0].rcSrc = new Rectangle(
                                                lgra[0].rcSrc.Left,
                                                lgra[0].rcSrc.Top + 5,
                                                lgra[0].rcSrc.Width,
                                                lgra[0].rcSrc.Height);
            }
            ///move coin///
            for (int i = 0; i < lcoin.Count; i++)
            { lcoin[i].j++;
                if (lcoin[i].j == -1)
                { lcoin[i].j = 5;
                }
                if (lcoin[i].j == 6)
                {
                    lcoin[i].j = 0;
                }

            }
            ///take coins///
            for (int i = 0; i < lcoin.Count; i++)
            {
                if (L[0].X + L[0].im[L[0].j].Width-20 > lcoin[i].X && L[0].X + L[0].im[L[0].j].Width-20 < lcoin[i].X + lcoin[i].im[lcoin[i].j].Width && L[0].Y > lcoin[i].Y - 150 && L[0].Y < lcoin[i].Y + lcoin[i].im[lcoin[i].j].Height)
                { lcoin.RemoveAt(i);
                    ct++;
                }
            }
            ////////////////check////////////
            if (L[0].X >= this.Width - 20)
            {
                this.Hide();
                Form2 obj = new Form2();
                obj.Show();
                tt.Stop();
            }
            if (flage1 == 0)
            {
                if (L[0].X + L[0].im[L[0].j].Width > lenm[1].X && L[0].X + L[0].im[L[0].j].Width < lenm[1].X + lenm[1].im[lenm[1].j].Width && L[0].Y > lenm[1].Y - 150 && L[0].Y < lenm[1].im[lenm[1].j].Width + lenm[1].Y)
                {

                    this.Hide();
                    Form2 obj = new Form2();
                    obj.Show();
                    tt.Stop();
                }
            }
            if (flage0 == 0)
            {
                if (L[0].X + L[0].im[L[0].j].Width > lenm[0].X && L[0].X + L[0].im[L[0].j].Width < lenm[0].X + lenm[0].im[lenm[0].j].Width && L[0].Y > lenm[0].Y - 150 && L[0].Y < lenm[0].im[lenm[0].j].Width + lenm[0].Y)
                {
                    this.Hide();
                    Form2 obj = new Form2();
                    obj.Show();
                    tt.Stop();
                }

            }
            if (L[0].H >= 3)
            {
                this.Hide();
                Form2 obj = new Form2();
                obj.Show();
                tt.Stop();
            }

            count++;
            DrawDubb(this.CreateGraphics());
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < L.Count; i++)
                {
                    L[i].X += 10;
                    L[i].j++;
                    if (L[i].j >= L[i].im.Count-1)
                    {
                        L[i].j = 0;
                    }

                }
              
            }
            if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < L.Count; i++)
                {
                    L[i].X -= 10;
                    L[i].j--;
                    if (L[i].j <= 0)
                    {
                        L[i].j = 5;
                    }

                }
               
            }
            if(e.KeyCode==Keys.Escape)
            {
                this.Hide();
                Form2 obj = new Form2();
                obj.Show();
            }

            if (e.KeyCode == Keys.Space)
            {
                for (int i = 0; i < L.Count; i++)
                {
                    
                    L[i].j=6;
                    pnn = new CActor1();

                    pnn.X = L[i].im[6].Width+L[i].X;

                    pnn.im = new List<Bitmap>();
                   
                        Bitmap pnm = new Bitmap(8 + ".jpg");
                        pnm.MakeTransparent(pnm.GetPixel(0, 0));
                        pnn.im.Add(pnm);
                    
                    pnn.Y = L[i].im[L[i].j].Height/2 + L[i].Y-30;
                    pnn.j = 0;
                    lbul.Add(pnn);



                }

            }
        }
        CActor1 pnn;
        Bitmap pnm;
        private void Form3_Load(object sender, EventArgs e)
        {
            unSeen = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            /////hero///
             pnn = new CActor1();

            pnn.X = 10;
          
            pnn.im = new List<Bitmap>();
            for (int k = 0; k < 7; k++)
            {
                 pnm = new Bitmap( (k + 1) + ".jpg");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.Y = this.Height - pnn.im[0].Height-60;
            pnn.j = 0;
            pnn.H = 0;
            L.Add(pnn);

            /////line/////
            pnn = new CActor1();
            pnn.im = new List<Bitmap>();
            pnm = new Bitmap("ladder.jpg");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            pnn.j = 0;
            pnn.rcSrc = new Rectangle(0, 0, pnn.im[0].Width, pnn.im[0].Height);
            pnn.rcDst = new Rectangle(0, this.Height - 60, this.Width, 20);
            Line.Add(pnn);




            pnn = new CActor1();
            pnn.im = new List<Bitmap>();
            pnm = new Bitmap("ladder" + ".jpg");
            pnm.MakeTransparent(pnm.GetPixel(0, 0));
            pnn.im.Add(pnm);
            pnn.j = 0;
            pnn.rcSrc = new Rectangle(0, 0, pnn.im[0].Width, pnn.im[0].Height);
            pnn.rcDst = new Rectangle(400, 150, 600, 20);
            Line.Add(pnn);




            pnn = new CActor1();
            pnn.im = new List<Bitmap>();
            pnm = new Bitmap("ladder" + ".jpg");
            pnm.MakeTransparent(pnm.GetPixel(0, 0));
            pnn.im.Add(pnm);
            pnn.j = 0;
            pnn.rcSrc = new Rectangle(0, 0, pnn.im[0].Width, pnn.im[0].Height);
            pnn.rcDst = new Rectangle(1000, 300, 600, 20);
            Line.Add(pnn);


            pnn = new CActor1();
            pnn.im = new List<Bitmap>();
            pnm = new Bitmap("ladder" + ".jpg");
            pnm.MakeTransparent(pnm.GetPixel(0, 0));
            pnn.im.Add(pnm);
            pnn.j = 0;
            pnn.rcSrc = new Rectangle(0, 0, pnn.im[0].Width, pnn.im[0].Height);
            pnn.rcDst = new Rectangle(800, 450, 600, 20);
            Line.Add(pnn);


            pnn = new CActor1();
            pnn.im = new List<Bitmap>();
            pnm = new Bitmap("ladder" + ".jpg");
            pnm.MakeTransparent(pnm.GetPixel(0, 0));
            pnn.im.Add(pnm);
            pnn.j = 0;
            pnn.rcSrc = new Rectangle(0, 0, pnn.im[0].Width, pnn.im[0].Height);
            pnn.rcDst = new Rectangle(300, this.Height - 60-10, 100, 20);
            pnn.H = -1;
            pnn.W = 0;
            Line.Add(pnn);



            ///enemy//////
           pnn = new CActor1();
             pnn.im = new List<Bitmap>();
            for (int i = 0; i < 8; i++)
            {
                pnm = new Bitmap("e" + (i+1) + ".jpg");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.X = 450;
             pnn.Y = 150-pnn.im[0].Height ;
             pnn.j = 0;
            pnn.W = 1;
            pnn.H = 0;
            pnn.ca = 0;
             lenm.Add(pnn);

            pnn = new CActor1();
            pnn.im = new List<Bitmap>();
            for (int i = 0; i < 8; i++)
            {
                pnm = new Bitmap("ek" + (i + 1) + ".jpg");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.X = 400;
            pnn.Y = this.Height-60 - pnn.im[0].Height;
            pnn.j = 0;
            pnn.W = 1;
            pnn.H = 0;
            pnn.ca = 1;
            lenm.Add(pnn);

            pnn = new CActor1();
            pnn.im = new List<Bitmap>();
            for (int i = 0; i < 1; i++)
            {
                pnm = new Bitmap("el" + (i + 1) + ".jpg");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.X = this.Width - pnn.im[0].Width ;
            pnn.Y = 300 - pnn.im[0].Height;
            pnn.j = 0;
            pnn.W = 1;
            pnn.H = 0;
            pnn.ca = 2;
            lenm.Add(pnn);

            pnn = new CActor1();
            pnn.im = new List<Bitmap>();
            for (int i = 0; i < 1; i++)
            {
                pnm = new Bitmap("el" + (i + 1) + ".jpg");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.X = this.Width - pnn.im[0].Width;
            pnn.Y = 450 - pnn.im[0].Height;
            pnn.j = 0;
            pnn.W = 1;
            pnn.H = 0;
            pnn.ca = 3;
            lenm.Add(pnn);
            ///door and key and heart///
            pnn = new CActor1();
            pnn.im = new List<Bitmap>();
            for (int i = 0; i < 1; i++)
            {
                pnm = new Bitmap("key"  + ".jpg");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im.Add(pnm);
            }
            pnn.X = this.Width - 250;
            pnn.Y = 450 - pnn.im[0].Height;
            pnn.j = 0;
            pnn.W = 1;
            pnn.H = 1;
            lgra.Add(pnn);

            pnn = new CActor1();
            pnn.im = new List<Bitmap>();
            pnm = new Bitmap("doorl" + ".jpg");
            pnm.MakeTransparent(pnm.GetPixel(0, 0));
            pnn.im.Add(pnm);
            pnn.j = 0;
            pnn.H = 0;
            pnn.rcSrc = new Rectangle(0, 0, pnn.im[0].Width, pnn.im[0].Height);
            pnn.rcDst = new Rectangle(this.Width-40, 450, 30, this.Height-450);
            lgra.Add(pnn);


            ////coinssss///////
            int a = 420;
            for (int i = 0; i < 10; i++)
            {
                pnn = new CActor1();
                pnn.X = a;
                pnn.im = new List<Bitmap>();
                for (int k = 0; k < 6; k++)
                {
                    pnm = new Bitmap("coin" + (k + 1) + ".jpg");
                    pnm.MakeTransparent(pnm.GetPixel(0, 0));
                    pnn.im.Add(pnm);
                }

                pnn.Y = this.Height - pnn.im[0].Height - 60;
                pnn.j = 0;
                pnn.H = 0;
                lcoin.Add(pnn);
                a += 80;
            }
            a = this.Height - pnn.im[0].Height - 60-20;
            for (int i = 0; i < 6; i++)
            {
                pnn = new CActor1();
                pnn.X = 310;
                pnn.im = new List<Bitmap>();
                for (int k = 0; k < 6; k++)
                {
                    pnm = new Bitmap("coin" + (k + 1) + ".jpg");
                    pnm.MakeTransparent(pnm.GetPixel(0, 0));
                    pnn.im.Add(pnm);
                }

                pnn.Y = a;
                pnn.j = 0;
                pnn.H = 0;
                lcoin.Add(pnn);
                a -= 80;
            }
            a -= 80;
            a -= 80;
            int b = 480;
            for (int i = 0; i < 5; i++)
            {
                pnn = new CActor1();
                pnn.X = b;
                pnn.im = new List<Bitmap>();
                for (int k = 0; k < 6; k++)
                {
                    pnm = new Bitmap("coin" + (k + 1) + ".jpg");
                    pnm.MakeTransparent(pnm.GetPixel(0, 0));
                    pnn.im.Add(pnm);
                }

                pnn.Y = a+100;
                pnn.j = 0;
                pnn.H = 0;
                lcoin.Add(pnn);
                b += 80;
                
            }

            //heart//
            a = 20;
            for (int i = 0; i < 4; i++)
            {
                pnn = new CActor1();
                pnn.im = new List<Bitmap>();
              
                
                    pnm = new Bitmap("heart" +  ".jpg");
                    pnm.MakeTransparent(pnm.GetPixel(0, 0));
                    pnn.im.Add(pnm);
                
                pnn.X = a;
                pnn.Y = 10;
                pnn.j = 0;
                pnn.W = 1;
                pnn.H = 0;
                pnn.ca = 3;
                lheart.Add(pnn);
                a += 50;
            }





        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(CreateGraphics());
        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(unSeen);
            DrawScene(g2);
            g.DrawImage(unSeen, 0, 0);
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);

            for (int i = 0; i < lcoin.Count; i++)
            {
                g.DrawImage(lcoin[i].im[lcoin[i].j], lcoin[i].X, lcoin[i].Y);
            }
            for (int i = 0; i < lheart.Count; i++)
            {
                g.DrawImage(lheart[i].im[lheart[i].j], lheart[i].X, lheart[i].Y);
            }
            for (int i = 0; i < lbul.Count; i++)
            {
                g.DrawImage(lbul[i].im[lbul[i].j], lbul[i].X, lbul[i].Y);
            }
            for (int i = 0; i < lenm.Count; i++)
            {
                g.DrawImage(lenm[i].im[lenm[i].j], lenm[i].X, lenm[i].Y);
            }
            

            SolidBrush bb = new SolidBrush(Color.Gray);
            for (int i = 0; i < Line.Count; i++)
            {
                g.DrawImage(Line[i].im[Line[i].j], Line[i].rcDst, Line[i].rcSrc, GraphicsUnit.Pixel);
            }

            for (int i = 0; i < lenmbul.Count; i++)
            {
                g.DrawImage(lenmbul[i].im[lenmbul[i].j], lenmbul[i].X, lenmbul[i].Y);
            }
            for (int i = 0; i < lgra.Count; i++)
            {
                if(lgra[i].H==0)
                { g.DrawImage(lgra[i].im[lgra[i].j], lgra[i].rcDst, lgra[i].rcSrc, GraphicsUnit.Pixel); }
                else { g.DrawImage(lgra[i].im[lgra[i].j], lgra[i].X, lgra[i].Y); }

            }
            for (int i = 0; i < L.Count; i++)
            {
                g.DrawImage(L[i].im[L[i].j], L[i].X, L[i].Y);
            }
            string drawString = "coins:" + ct;
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.White);
            float x = 1100.0F;
            float y = 50.0F;
            StringFormat drawFormat = new StringFormat();
            g.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
          
     
            

            drawFont.Dispose();
            drawBrush.Dispose();


        }
    }
}
