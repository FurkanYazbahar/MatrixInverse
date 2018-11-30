using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareOlmayanMatrisinSözdeTersi
{
    class Matrix
    {

        private double[,] matrixValues;
        public double[,] Values { set { matrixValues = value; } get { return matrixValues; } }

        public Matrix()
        {

        }

        public Matrix(double[,] arr)
        {
            matrixValues = arr;
        }


        public double[,] MultiplyMatrix(double[,] rightMatrix)
        {
            if (matrixValues.GetLength(0) != rightMatrix.GetLength(1))
            {
                Console.WriteLine("\n Number of columns in First Matrix should be equal to Number of rows in Second Matrix.");
                Console.WriteLine("\n Please re-enter correct dimensions.");
                return null;
            }

            double[,] resultMatrixValues = new double[matrixValues.GetLength(0), rightMatrix.GetLength(1)];

            for (int i = 0; i < resultMatrixValues.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrixValues.GetLength(1); j++)
                {
                    resultMatrixValues[i, j] = 0;
                    for (int k = 0; k < matrixValues.GetLength(1); k++)
                    {
                        resultMatrixValues[i, j] += matrixValues[i, k] * rightMatrix[k, j];
                    }
                }
            }

            return resultMatrixValues;
        }
        public static double[,] MultiplyMatrix(double[,] leftMatrix, double[,] rightMatrix)
        {
            if (leftMatrix.GetLength(0) != rightMatrix.GetLength(1))
            {
                Console.WriteLine("\n Number of columns in First Matrix should be equal to Number of rows in Second Matrix.");
                Console.WriteLine("\n Please re-enter correct dimensions.");
                return null;
            }

            double[,] resultMatrixValues = new double[leftMatrix.GetLength(0), rightMatrix.GetLength(1)];

            for (int i = 0; i < resultMatrixValues.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrixValues.GetLength(1); j++)
                {
                    resultMatrixValues[i, j] = 0;
                    for (int k = 0; k < leftMatrix.GetLength(1); k++)
                    {
                        resultMatrixValues[i, j] += leftMatrix[i, k] * rightMatrix[k, j];
                    }
                }
            }

            return resultMatrixValues;
        }
        public static double[,] Transpose(double[,] matrix)
        {
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            double[,] result = new double[colCount, rowCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }

        public static double[,] calculatePseudoInverse(double[,] matrix)
        {
            int matrixRowCount = matrix.GetLength(0);
            int matrixColCount = matrix.GetLength(1);


            if (matrixRowCount == matrixColCount)
            {
                return matrix;
            }
            int rank = rankOfMatrix(matrix);
            Console.WriteLine($"Rank : {rank}");

            if (rank == matrixColCount )
            {
                if (determinant(Matrix.MultiplyMatrix(Matrix.Transpose(matrix), matrix), matrixColCount) == 0 ||
                    determinant(Matrix.MultiplyMatrix(matrix, Matrix.Transpose(matrix)), matrixRowCount) == 0)
                {
                    Console.WriteLine("Determinant sıfır. Matrisin tersi hesaplanamaz!");
                    return null;
                }

                return Matrix.MultiplyMatrix(cofactor(Matrix.MultiplyMatrix(Matrix.Transpose(matrix), matrix)), Matrix.Transpose(matrix));
            }
            else if(rank == matrixRowCount)
            {
                if (determinant(Matrix.MultiplyMatrix(Matrix.Transpose(matrix), matrix), matrixColCount) == 0 ||
    determinant(Matrix.MultiplyMatrix(matrix, Matrix.Transpose(matrix)), matrixRowCount) == 0)
                {
                    Console.WriteLine("Determinant sıfır. Matrisin tersi hesaplanamaz!");
                    return null;
                }

                return Matrix.MultiplyMatrix(Transpose(matrix) , cofactor(Matrix.MultiplyMatrix(matrix, Transpose(matrix))));
            }
            return null;
        }

        public static void ShowArray(double[,] mat)
        {
            for (int row = 0; row < mat.GetLength(0); row++)
            {
                for (int col = 0; col < mat.GetLength(1); col++)
                {
                    Console.Write($"{string.Format("{0:0.0} ", mat[row, col])}");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /*For calculating Determinant of the Matrix . this function is recursive*/
        public static double determinant(double[,] matrix, int size)
        {
            double s = 1, det = 0;
            double[,] m_minor;
            m_minor = new double[size,size];
            int i, j, m, n, c;
            if (size==1)
            {
                return (matrix[0,0]);
            }
            else
            {
                det=0;
                for (c=0;c<size;c++)
                {
                    m=0;
                    n=0;
                    for (i=0;i<size;i++)
                    {
                        for (j=0;j<size;j++)
                        {
                            m_minor[i,j]=0;
                            if (i != 0 && j != c)
                            {
                               m_minor[m,n]=matrix[i,j];
                               if (n<(size-2))
                                  n++;
                               else
                               {
                                   n=0;
                                   m++;
                               }
                            }
                        }
                    }
                    det = det + s* (matrix[0,c] * determinant(m_minor, size-1));
                    s=-1 * s;
                }
            }
             return (det);
        }
 
            /*calculate cofactor of matrix*/
         public static double[,] cofactor(double[,] matrix)
          {
              int size = matrix.GetLength(0);
              double[,] m_cofactor,matrix_cofactor;
              m_cofactor = new double[size, size];
              matrix_cofactor = new double[size, size];
              int p, q, m, n, i, j;
              for (q=0;q<size;q++)
              {
                  for (p=0;p<size;p++)
                  {
                      m=0;
                      n=0;
                      for (i=0;i<size;i++)
                      {
                          for (j=0;j<size;j++)
                          {
                              if (i != q && j != p)
                               {
                                 m_cofactor[m,n]=matrix[i,j];
                                 if (n<(size-2))
                                    n++;
                                 else
                                 {
                                     n=0;
                                     m++;
                                 }
                              }
                          }
                      }
                      matrix_cofactor[q,p]=Math.Pow(-1, q + p) * determinant(m_cofactor, size-1);

                  }
              }
              return transpose(matrix, matrix_cofactor, size);
         }

           /*Finding transpose of cofactor of matrix*/ 
          public static double[,] transpose(double[,] matrix, double[,] matrix_cofactor, int size)
           {
               int i, j;
               double d;
               double[,] m_transpose = new double[size, size];
               double[,] m_inverse = new double[size, size];    
            
                for (i=0;i<size;i++)
                {
                    for (j=0;j<size;j++)
                    {
                        m_transpose[i,j]=matrix_cofactor[j,i];
                    }
                }
                d=determinant(matrix, size);
                for (i=0;i<size;i++)
                {
                    for (j=0;j<size;j++)
                    {
                        m_inverse[i,j]=m_transpose[i,j] / d;
                    }
                }
            return m_inverse;
                Console.Write("\n\n\t* * * * * * * * * * * * * * * * * * * * * * * \n\n\tThe inverse of matrix is : \n\n");

                 ShowArray(m_inverse);
                //for (i=0;i<size;i++)
                //{
                //    for (j=0;j<size;j++)
                //    {
                //       Console.Write("\t%3.2f", m_inverse[i,j]);
                //    }
                //   Console.Write("\n\n");
                //}
               Console.Write("\n\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
               Console.Write("\n* * * * * * * * * * * * * * * * * THE END * * * * * * * * * * * * * * * * * * *");
               Console.Write("\n* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
           }

        public static int rankOfMatrix(double[,] mat)
        {
            int R = mat.GetLength(0);
            int C = mat.GetLength(1);
            int rank = C;

            for (int row = 0; row < rank; row++)
            {

                // Before we visit current row  
                // 'row', we make sure that  
                // mat[row][0],....mat[row][row-1] 
                // are 0. 

                // Diagonal element is not zero 
                if (mat[row, row] != 0)
                {
                    for (int col = 0; col < R; col++)
                    {
                        if (col != row)
                        {
                            // This makes all entries  
                            // of current column  
                            // as 0 except entry  
                            // 'mat[row][row]' 
                            double mult =
                                        mat[col, row] /
                                        mat[row, row];

                            for (int i = 0; i < rank; i++)

                                mat[col, i] -= mult
                                         * mat[row, i];
                        }
                    }
                }

                // Diagonal element is already zero.  
                // Two cases arise: 
                // 1) If there is a row below it  
                // with non-zero entry, then swap  
                // this row with that row and process  
                // that row 
                // 2) If all elements in current  
                // column below mat[r][row] are 0,  
                // then remvoe this column by  
                // swapping it with last column and 
                // reducing number of columns by 1. 
                else
                {
                    bool reduce = true;

                    // Find the non-zero element  
                    // in current column  
                    for (int i = row + 1; i < R; i++)
                    {
                        // Swap the row with non-zero  
                        // element with this row. 
                        if (mat[i, row] != 0)
                        {
                            swap(mat, row, i, rank);
                            reduce = false;
                            break;
                        }
                    }

                    // If we did not find any row with  
                    // non-zero element in current  
                    // columnm, then all values in  
                    // this column are 0. 
                    if (reduce)
                    {
                        // Reduce number of columns 
                        rank--;

                        // Copy the last column here 
                        for (int i = 0; i < R; i++)
                            mat[i, row] = mat[i, rank];
                    }

                    // Process this row again 
                    row--;
                }

                // Uncomment these lines to see  
                // intermediate results display(mat, R, C); 
                // printf("\n"); 
            }

            return rank;
        }

       public static void swap(double[,] mat,
          int row1, int row2, int col)
        {
            for (int i = 0; i < col; i++)
            {
                double temp = mat[row1, i];
                mat[row1, i] = mat[row2, i];
                mat[row2, i] = temp;
            }
        }
    }
}

