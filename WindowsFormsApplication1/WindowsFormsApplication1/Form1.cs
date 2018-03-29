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


        public Form1()
        {
            InitializeComponent();
            
        }

        public string FileTxt() //считывание
        {
            string line;            
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\asustud\Desktop\small-test.in.txt");
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
                outStr += "Case #" + i + "\r\n";
                outStr += strTest + "\r\n";
                temp = 0; strTest = "";
            }
            textBox2.Text = outStr;
        }

        //public Array MakeMatrix(int max)
        //{
        //    int[,] matr = new int[max * 2, max * 2];
        //    //int[] arrOut = new int[2];
        //    //for (int i = 0; i < max * 2; i++)
        //    //{ 
        //    //    //start point = [0,max]
        //    //}
        //    return matr;
        //}

        //public Array MakeMatrix(string str, Array matr, int max)
        //{
        //    int[] arrOut = new int[2];
        //    for (int i = 0; i < max * 2; i++)//start point = [0,max]
        //    {
        //        for (int j = 1; j < str.Length; j++)
        //        {
        //            if (str[j].ToString() != str[j - 1].ToString())
        //            {
        //                //меняем направление
        //            }
        //            else
        //            {
        //                //идем прямо
        //            }

        //        }
        //    }
        //    return arrOut;
        //}

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
