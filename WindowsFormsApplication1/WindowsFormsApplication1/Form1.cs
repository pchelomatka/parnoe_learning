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
        public Form1()
        {
            InitializeComponent();
        }

        public void IndexOfTextBox(){
            char a ;            
            a = textBox1.Text[0];
            textBox2.Text = a.ToString();
        }

        public void FromStringToColumn()
        {
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                textBox2.Text += textBox1.Text[i].ToString() +"\r\n";
            }
        }        
            
            
        

        public void test()
        {          
            char W = 'W';
            char R = 'R';
            char L = 'L';
            int North = 1;
            int South = 0;
            int West = 0;
            int East = 0;

            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if ( i > 0 && i< textBox1.Text.Length)
                {
                    if(textBox1.Text[i] == W)
                    {
                        if(North==1 ^ South==1)
                        {
                            textBox2.Text += 3;
                        }

                        else if (West == 1 ^ East == 1)
                        {
                            textBox2.Text += "c";
                        }
                    }

                    if (textBox1.Text[i - 1] == W && textBox1.Text[i] == R && textBox1.Text[i + 1] == W)
                    {
                        if (North == 1)
                        {
                            textBox2.Text += 5;
                            North = 0;
                            East = 1;
                            i = i + 1;
                        }
                        else if (South == 1)
                        {
                            textBox2.Text += "a";
                            South = 0;
                            West = 1;
                            i = i + 1;
                        }
                        else if (West == 1)
                        {
                            textBox2.Text += 6;
                            West = 0;
                            North = 1;
                            i = i + 1;
                        }
                        else if (East == 1)
                        {
                            textBox2.Text += 9;
                            East = 0;
                            South = 1;
                            i = i + 1;
                        }
                    }

                    if (textBox1.Text[i - 1] == W && textBox1.Text[i] == L && textBox1.Text[i + 1] == W)
                    {
                        if (North == 1)
                        {
                            textBox2.Text += 9;
                            North = 0;
                            West = 1;
                            i = i + 1;
                        }
                        else if (South == 1)
                        {
                            textBox2.Text += 6;
                            South = 0;
                            East = 1;
                            i = i + 1;
                        }
                        else if (West == 1)
                        {
                            textBox2.Text += 5;
                            West = 0;
                            South = 1;
                            i = i + 1;
                        }
                        else if (East == 1)
                        {
                            textBox2.Text += "a";
                            East = 0;
                            North = 1;
                            i = i + 1;
                        }
                    }
                }               
            }                
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            //IndexOfTextBox();
            //FromStringToColumn();
            test();
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
