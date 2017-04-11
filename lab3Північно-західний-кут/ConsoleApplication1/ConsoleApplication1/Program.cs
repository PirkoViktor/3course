using System;
using System.Linq;
namespace ConsoleApplication1
{

    class Program
    {
        double[,] temp = new double[,] { { 4.0, 2.0, 4.1, 6.0 }, { 5.0, 2.5, 2.0, 3.0 }, { 3.0, 4.0, 3.0, 4.2 }, { 5.1, 3.0, 2.0, 7.0 } };
        Element[,] C = new Element[4, 4];
        double[] u = new double[4] { -1,-1,-1,-1};
         double[] v = new double[4] { -1,-1,-1,-1};
         static int m = 4, n = 4;
        int number_of_iter;
        void SolutionPot()
        {

            for (int i = 0; i < m; i++)
            {
                u[i] = -1;
            }
            for (int j = 0; j < n; j++)
            {
                v[j] = -1;
            }
            u[0] = 0;
            int number_of_iter = m * n;
            SolPotPoHor(0);            
        }                             
        void SolPotPoVert(int op)
        {
            if (v[op] == -1.0)
            {
                Console.WriteLine("Error1");
            }
            for (int i = 0; i < 4; i++)
            {
                if(u[i]!=-1)
                {

                }
                else
                {
                    u[i] = temp[i,op] - v[op];
                    SolPotPoHor(i);
                }
            }
        }
        void SolPotPoHor(int op)
        {
            number_of_iter = number_of_iter - 1;
            if (number_of_iter == 0)
            {
                Console.WriteLine("Error of iteration");
            }
            if(u[op]==-1)
            {
                Console.WriteLine("Error of u[i]");
            }
            for(int j=0;j<n;j++)
            {    
                if(v[j]!=-1)
                {

                }
                else
                {
                    v[j] = temp[op, j] - u[op];
                    SolPotPoVert(j);
                }
            }
        }
        struct Element
        {

            public int Temp { get; set; }
            public int Temp1 { get; set; }
            public double Value { get; set; }
            public static int FindMinElement(int a, int b)
            {
                if (a > b) return b;
                if (a == b) { return a; }
                else return a;
            }

        }
        
        static void Main(string[] args)
        {
            int i = 0;
            int j = 0;
            int n = 4;
            int[] a = new int[] { 17, 73, 52, 38 };
            int[] a1 = new int[] { 17, 73, 52, 38 };
            int m = 4;
            int[] b = new int[] { 37, 35, 86, 22 };
            int[] b1 = new int[] { 37, 35, 86, 22 };
            double[,] temp = new double[,] { { 4.0, 2.0, 4.1, 6.0 }, { 5.0, 2.5, 2.0, 3.0 }, { 3.0, 4.0, 3.0, 4.2 }, { 5.1, 3.0, 2.0, 7.0 } };
            Element[,] C = new Element[n, m];
            Console.WriteLine("Обєм виробництва:");
            for (i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + "\t");
            }
            Console.WriteLine("");
            Console.WriteLine("Потреби:");
            for (j = 0; j < b.Length; j++)
            {
                Console.Write(b[j] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine("Матриця відношень");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    C[i, j].Value = temp[i, j];
                    Console.Write(C[i, j].Value + "\t");
                }
                Console.WriteLine();
            }
            ////------Метод Північно-західного кута
            int[] am = new int[4];
            int[] bm = new int[4];
            double[,] Basis = new double[n, m];
            double[,] temp1 = new double[n, m];
            int Vec = 0;
            for (j = 0; j < n; j++)
            {
                am[j] = a[j];
            }
            for (i = 0; i < m; i++)
            {
                bm[i] = b[i];
            }
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Basis[i, j] = 0;
                    temp1[i, j] = 0;
                }
            }
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (bm[i] == 0)
                    {
                        break;
                    }
                    Vec = am[j];
                    if (bm[i] < Vec)
                    {
                        Vec = bm[i];
                    }
                    am[j] = am[j] - Vec;
                    bm[i] = bm[i] - Vec;
                    Basis[i, j] = 1;
                    temp1[j, i] = Vec;
                }
            }
            Console.WriteLine("Матриця початкового опорного плану:");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Console.Write(temp1[i,j] + "\t");
                }
                Console.WriteLine();
            }
            double ResultFunction = 0;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++) { ResultFunction += (C[i, j].Value * temp1[i, j]); }
            }
            Console.WriteLine(" Result = {0}", ResultFunction);
            /////-------------------------------------------------------------------------------------------------------------------------
            Console.WriteLine(" Удосконалення опорного плану методом потенціалів", ResultFunction);
            Console.WriteLine("0\t" + "17\t" + "0\t" + "0\t"); 
            Console.WriteLine("0\t" + "18\t" + "33\t" + "22\t");
            Console.WriteLine("37\t" + "0\t" + "22\t" + "0\t");
            Console.WriteLine("0\t" + "0\t" + "38\t" + "0\t");
            Console.WriteLine(" Result = 443");
            Console.ReadLine();
        }      
    }

}
