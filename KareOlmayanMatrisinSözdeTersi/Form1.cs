using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KareOlmayanMatrisinSözdeTersi
{
    public partial class Form1 : Form
    {
        private int flowPanelSizeX;
        private int flowPanelSizeY;

        private int textBoxSizeX;
        private int textBoxSizeY;

        private int colCount = 1;
        private int rowCount = 1;

        private int pageLimitMinX;
        private int pageLimitMinY;

        private int pageSizeX;
        private int pageSizeY;

        private TextBox[,] textboxArray;
        private double[,]  textboxValueArray;

        // TODO: textboxArray içindeki değerler textboxValueArraye aktarılacak
        // bu sırada dönüşüm kontrol yapılacak
        private void textboxArray2valueArray()
        {
           
        }

        public static double DET(double[,] a)
        {
            int i, j, k;
            double det = 0;
            int n = a.GetLength(0);
            for (i = 0; i < n - 1; i++)
            {
                for (j = i + 1; j < n ; j++)
                {
                    det = (a[j, i] == 0)? 0 : a[j, i] / a[i, i];
                    
                    for (k = i; k < n; k++)
                        a[j, k] = a[j, k] - det * a[i, k]; // Here's exception
                }
            }
            det = 1;
            for (i = 0; i < n; i++)
            {
                det *= a[i, i];
              //  Console.WriteLine(det);
            }
           // Console.WriteLine(det);
            return det;
        }

        public Form1()
        {
            setEnvironments();

            Matrix r = new Matrix();


            double[,] asil = new double[,] { 
                    {-1 , 0 ,  1,  2 },
                    {-1 , 1 ,  0, -1}, 
                    { 0 ,-1 ,  1,  3 }, 
                    { 0 , 1 , -1, -3 }, 
                    { 1 ,-1 ,  0,  1 },
                    { 1 , 0 , -1, -2 }
            };

            double[,] first = new double[,] { {-1 ,-3 , 3 , 8 },
                                              { 7 , 3 ,-9 , 1 },
                                              { 1 , 3 , 1 ,-1 },
                                              { 2 ,-3 , 3 ,-3 },
                                              {-1 ,-3 , 1 , 3 }, };

            double[,] first1 = new double[,] { {2 , 5  },
                                              { 3 , 9  },
                                              { 8 , 4  },
                                              { 3 , 5  } };

            double[,] second = new double[,] { { 2, 4 },
                                               { 3, 6 } };
            double[,] result;

           // Matrix f = new Matrix(first1);
            Matrix s = new Matrix(second);

            Matrix.ShowArray(first1);



            // Console.WriteLine($"\n{DET(s.Values)}");
             Console.WriteLine("----transpoze-------");
            s.Values = Matrix.Transpose(first1);
            Matrix.ShowArray(s.Values);

            //Matrix.ShowArray(first);
            //Matrix.ShowArray(second);
             Console.WriteLine("----result-------");
            double[,] res1 = Matrix.MultiplyMatrix(first1,s.Values);
            Matrix.ShowArray(res1);
            double d = Matrix.determinant(res1,res1.GetLength(0));
            Console.WriteLine($"Determinant : {d}");
            // f.MultiplyMatrix(s);
            double[,] res = Matrix.calculatePseudoInverse(first1);
            if (res == null)
                Console.WriteLine("null");
            else
                Matrix.ShowArray(res);
            /*
            double[,] res = f.MultiplyMatrix(s);
            Matrix.ShowArray(res);

            double d = Matrix.determinant(res, res.GetLength(0));

            Console.WriteLine($"Determinant : {d}");
            Console.WriteLine($"{d}");

            Matrix.cofactor(res, res.GetLength(0));
            */
            // Console.WriteLine($"{DET(f.MultiplyMatrix(s))}");
            // Console.WriteLine($"{Matrix.MatrixDeterminant(f.MultiplyMatrix(s))}");

            InitializeComponent();
        }

        private void setEnvironments()
        {
            pageLimitMinX = 200;
            pageLimitMinY = 76;

            textBoxSizeX = 34;
            textBoxSizeY = 20;
        }

        private void initializeTextBoxArrays() {
            textboxArray = new TextBox[rowCount, colCount];
            textboxValueArray = new double[rowCount, colCount];
            
        }

        private void setMatrixEdgeSize(int _rowCount, int _colCount)
        {
            rowCount = _rowCount;
            colCount = _colCount;
        }

        private void setFlowPanelSize()
        {
            flowPanelSizeX = (textBoxSizeX * colCount) + (colCount - 1) * 7 + 5;
            flowPanelSizeY = (textBoxSizeY * rowCount) + (rowCount - 1) * 7 + 5;
        }

        private void setPageSize() {
            pageSizeX = 2 * this.textboxflowPanel.Location.X +
                textboxflowPanel.Size.Width +
                2 * this.textboxflowPanel.Padding.Size.Width +
                2 * this.textboxflowPanel.Margin.Size.Width;

            pageSizeY = this.textboxflowPanel.Location.Y +
                textboxflowPanel.Size.Height +
                2 * this.textboxflowPanel.Padding.Size.Height +
                2 * this.textboxflowPanel.Margin.Size.Height +
                30;

            controlPageLimits();
            this.Size = new Size(pageSizeX, pageSizeY);
        }

        private void controlPageLimits()
        {
            if (pageSizeX < pageLimitMinX)
            {
                pageSizeX = pageLimitMinX;
            }

            if (pageSizeY < pageLimitMinY)
            {
                pageSizeY = pageLimitMinY;
            }           
        }

        private void makeFlowPanelElements()
        {
            initializeTextBoxArrays();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    TextBox t = new TextBox();
                    t.KeyPress += textBoxFloatControlKeyPressEvent;
                    t.Leave += textBoxFloatControlLeaveEvent;
                    textboxflowPanel.Controls.Add(t);
                    t.Size = new System.Drawing.Size(textBoxSizeX, textBoxSizeY);

                    textboxArray[i, j] = t;
                }
            }
        }

        private void freshButton_Click(object sender, EventArgs e)
        {
            textboxflowPanel.Controls.Clear();
            setMatrixEdgeSize(Convert.ToInt32(textBoxRowCount.Text.ToString()), Convert.ToInt32(textBoxColCount.Text.ToString()));
            textboxflowPanel.Visible = true;
            setFlowPanelSize();

            textboxflowPanel.Size = new System.Drawing.Size(flowPanelSizeX, flowPanelSizeY);
            setPageSize();

            makeFlowPanelElements();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private Boolean textBoxMatrixEdgeControl(char c)
        {
            Boolean isDefinable = false;
            
            if (Regex.Match(c.ToString(), "[^1-5\b]").Success)
            {
                MessageBox.Show("Sayı 1 ile 5 arasında girilmeli!");
                isDefinable = true;
            }
            return isDefinable;
        }

        private Boolean textBoxFloatControl(char c)
        {
            Boolean isDefinable = false;

            if (Regex.Match(c.ToString(), "[^0-9\b,]").Success)
            {
                MessageBox.Show("Sayı 1 ile 9 arasında girilmeli!");
                isDefinable = true;
            }
            return isDefinable;
        }

        private void textBoxFloatControlLeaveEvent(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            String text = t.Text.ToString();
            int length = text.Length;
            t.BackColor = (length == 1 || length == 3) ? Color.White : Color.Red;

            if ((length > 0 && text[0] == ',') || (length > 1 && text[1] != ',') || (length > 2 && text[2] == ',')) {
                t.BackColor = Color.DarkRed;
            }

            if (! t.BackColor.Equals(Color.White))
            {
                MessageBox.Show("Girilen sayı geçersiz!");
                t.Clear();
                t.BackColor = Color.White;
                t.Focus();
            }
        }

        private void textBoxFloatControlKeyPressEvent(object sender, KeyPressEventArgs e)
        {
            e.Handled = textBoxFloatControl(e.KeyChar);
        }

        private void textBoxColCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = textBoxMatrixEdgeControl(e.KeyChar);
        }

        private void textBoxRowCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = textBoxMatrixEdgeControl(e.KeyChar);
        }

        private void textBoxRowCount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
