using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string[] ways = new string[4] { "S", "E", "N", "W" };
        int[] arrayHW = new int[6];
        List<string> prohod = new List<string>();
        List<string> prohodOut = new List<string>();
        public void MakeTable()
        {
            prohod.Add("1000"); prohod.Add("0100"); prohod.Add("1100"); prohod.Add("0010");
            prohod.Add("1010"); prohod.Add("0110"); prohod.Add("1110"); prohod.Add("0001");
            prohod.Add("1001"); prohod.Add("0101"); prohod.Add("1101"); prohod.Add("0011");
            prohod.Add("1011"); prohod.Add("0111"); prohod.Add("1111");
        }
        private static bool NorthNo(String s)
        {
            return s.ToLower()[0] == '0';
        }
        private static bool SouthNo(String s)
        {
            return s.ToLower()[1] == '0';
        }
        private static bool WesthNo(String s)
        {
            return s.ToLower()[2] == '0';
        }
        private static bool EasthNo(String s)
        {
            return s.ToLower()[3] == '0';
        }

        public int PointOut(string inStr, int prevInt) 
        {
            int outWay;
            if (inStr == "W")
                outWay = prevInt;
            else if (inStr == "R")
                outWay = prevInt - 1;
            else if (inStr == "L")
                outWay = prevInt + 1;
            else
                outWay = 10;
            if (outWay == -1)
                outWay = 3;
            else if (outWay == 4)
                outWay = 0;
            return outWay;
        }

        public void HeightWidth(string strIn)
        {
            int vector = 0;
            int heightCurrent = 0; int heightMax = 0;
            int widthCurrent = 0; int widthMax = 0; int widthMin = 0;
            for (int i = 0; i < strIn.Length; i++)
            {
                vector = PointOut(strIn[i].ToString(), vector);
                if (strIn[i].ToString() == "W")
                {
                    switch (vector)
                    {
                    case 0:
                            heightCurrent++;
                            if (heightCurrent > heightMax)
                                heightMax = heightCurrent;
                            if (i == strIn.Length - 1)
                                arrayHW[5] = 0; //выход на южной стороне
                            break;
                    case 3:
                            widthCurrent--;
                            if (widthCurrent < widthMin)
                                widthMin = widthCurrent;
                            if (i == strIn.Length - 1)
                                arrayHW[5] = 3; //выход на задной стороне
                            break;
                    case 2:
                            heightCurrent--;
                            if (i == strIn.Length - 1)
                                arrayHW[5] = 2; //выход на северной стороне
                            break;
                        case 1:
                            widthCurrent++;
                            if (widthCurrent > widthMax)
                                widthMax = widthCurrent;
                            if (i == strIn.Length - 1)
                                arrayHW[5] = 1; //выход на восточной стороне
                            break;
                    }
                }
            }
            int widthMain = Math.Abs(widthMin) + widthMax;
            int pointIn = widthMain - widthMax;
            arrayHW[0] = heightMax; //высота
            arrayHW[1] = widthMain; //ширина
            arrayHW[2] = pointIn; //точка входа (начиная с 1)
            arrayHW[3] = heightCurrent; //точка выхода (высота)
            arrayHW[4] = widthCurrent; //точка выхода (ширина, относительно входа (вход.ширина == 0))
        }

        public void Solving(string strIn)
        {
            int vector = 0;
            string temp = "XXXX";
            StringBuilder tempStr = new StringBuilder(temp);
            for (int i = 1; i < strIn.Length; i++)
            {
                vector = PointOut(strIn[i].ToString(), vector);
                if (strIn[i].ToString() == "W")
                {
                    switch (vector)
                    {
                        case 0:
                            prohodOut.RemoveAll(SouthNo);
                            break;
                        case 1:
                            prohodOut.RemoveAll(EasthNo);
                            break;
                        case 2:
                            //prohodOut.RemoveAll(NorthNo);

                            break;
                        case 3:
                            //prohodOut.RemoveAll(WesthNo);
                            tempStr[2] = '1';
                            break;
                    }
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            MakeTable();
            prohodOut = prohod;
        }

        public string FileTxt() //считывание
        {
            string line;            
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\User\Desktop\small-test.in.txt");
            string inText = "";
            while ((line = file.ReadLine()) != null)
            {
                inText += line + "\n"; 
                //textBox2.Text += line + "\r\n";                
            }

            file.Close();
            return inText;
        }
        

        //public void test()
        //{          
        //    char W = 'W';
        //    char R = 'R';                                                                                                                 
        //    char L = 'L';
        //    int North = 1;
        //    int South = 0;
        //    int West = 0;
        //    int East = 0;

        //    for (int i = 0; i < textBox1.Text.Length; i++)
        //    {
        //        if ( i > 0 && i< textBox1.Text.Length)
        //        {
        //            if(textBox1.Text[i] == W)
        //            {
        //                if(North==1 ^ South==1)
        //                {
        //                    textBox2.Text += 3;
        //                }

        //                else if (West == 1 ^ East == 1)
        //                {
        //                    textBox2.Text += "c";
        //                }
        //            }

        //            if (textBox1.Text[i - 1] == W && textBox1.Text[i] == R && textBox1.Text[i + 1] == W)
        //            {
        //                if (North == 1)
        //                {
        //                    textBox2.Text += 5;
        //                    North = 0;
        //                    East = 1;
        //                    i = i + 1;
        //                }
        //                else if (South == 1)
        //                {
        //                    textBox2.Text += "a";
        //                    South = 0;
        //                    West = 1;
        //                    i = i + 1;
        //                }
        //                else if (West == 1)
        //                {
        //                    textBox2.Text += 6;
        //                    West = 0;
        //                    North = 1;
        //                    i = i + 1;
        //                }
        //                else if (East == 1)
        //                {
        //                    textBox2.Text += 9;
        //                    East = 0;
        //                    South = 1;
        //                    i = i + 1;
        //                }
        //            }

        //            if (textBox1.Text[i - 1] == W && textBox1.Text[i] == L && textBox1.Text[i + 1] == W)
        //            {
        //                if (North == 1)
        //                {
        //                    textBox2.Text += 9;
        //                    North = 0;
        //                    West = 1;
        //                    i = i + 1;
        //                }
        //                else if (South == 1)
        //                {
        //                    textBox2.Text += 6;
        //                    South = 0;
        //                    East = 1;
        //                    i = i + 1;
        //                }
        //                else if (West == 1)
        //                {
        //                    textBox2.Text += 5;
        //                    West = 0;
        //                    South = 1;
        //                    i = i + 1;
        //                }
        //                else if (East == 1)
        //                {
        //                    textBox2.Text += "a";
        //                    East = 0;
        //                    North = 1;
        //                    i = i + 1;
        //                }
        //            }
        //        }               
        //    }                
            
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //IndexOfTextBox();
            //FromStringToColumn();
            //test();
            string inText = FileTxt();
            int strCount = int.Parse(inText.Split('\n')[0].ToString());
            //MessageBox.Show(strCount.ToString());
            string subStr1, subStr2;
            string strTest = ""; int temp = 0; int max;
            string outStr = "";
            for (int i = 1; i <= strCount; i++)
            {
                subStr1 = inText.Split('\n')[i].ToString().Split(' ')[0].ToString();
                subStr2 = inText.Split('\n')[i].ToString().Split(' ')[1].ToString();
                max = Math.Max(subStr1.Length, subStr2.Length);
                //вызывать решение лабиринта, передавая ему значение subStr1, subStr2
                for (int j = 1; j < subStr1.Length; j++)
                {
                    temp = PointOut(subStr1[j].ToString(), temp);
                    strTest += temp.ToString();
                }
                HeightWidth(subStr1);
                Solving(subStr1);
                outStr += "Case #" + i + "\r\n";
                outStr += strTest + " " + arrayHW[4].ToString() + "\r\n";
                temp = 0; strTest = "";
            }
            textBox2.Text = outStr + "\r\n";
            for (int i = 0; i < prohodOut.Count; i++)
            {
                textBox2.Text += prohodOut[i];
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
