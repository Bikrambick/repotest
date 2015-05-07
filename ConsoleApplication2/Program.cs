using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        public struct ratioanlNum
        {
            public long a;
            public long b;
            public long k;
            public bool isInf;

        }

        public long commonDivisor(long a, long b){
            if (a == 0 || b == 0) return a > b ? a : b;
            return commonDivisor(b, a % b);
        }
        public long multiplier(long a, long b)
        {
            return a * b / commonDivisor(a, b);
        }
        public void simplify(ref ratioanlNum a){
            //ratioanlNum r = new ratioanlNum();
            if (a.b == 0)
            {
                a.isInf = true;
                return;
            }
            a.k = a.a / a.b;
            a.a = a.a - a.b * a.k;
            if (a.k < 0 && a.a < 0)
            {
                a.a = -a.a;
            }
            long gDvsr = commonDivisor(Math.Abs(a.a), Math.Abs(a.b));
            a.a /= gDvsr;
            a.b /= gDvsr;
    }
        public void printRelational(ref ratioanlNum a)
        {
            if (a.isInf == true)
            {
                Console.Write("Inf");
                return;
            }
            if (a.a == 0 && a.k == 0)
            {
                Console.Write("0");
                return;
            }
            if (a.k < 0 || a.a < 0)
            {
                Console.Write("(");
            }
            if (a.k != 0)
            {
                Console.Write(a.k);
            }
            if (a.b != 1)
            {
                if (a.k != 0)
                {
                    Console.Write(" ");
                }
               Console.Write(a.a + "/"+ a.b);
            }
            if (a.k < 0 || a.a < 0)
            {
                Console.Write(")");
            }
        }
        void add(ratioanlNum a, ratioanlNum b)
        {
            ratioanlNum final = new ratioanlNum();
            printRelational(ref a);
            Console.Write("+");
            printRelational(ref b);
            a.a += a.b * Math.Abs(a.k);
            b.a += b.b * Math.Abs(b.k);
            if (a.k < 0) a.a = -a.a;
            if (b.k < 0) b.a = -b.a;
            long lcmNum = multiplier(a.b, b.b);
            a.a *= (lcmNum / a.b);
            b.a *= (lcmNum / b.b);
            final.a = a.a + b.a;
            final.b = lcmNum;
            simplify(ref final);
            Console.Write(" = ");
            printRelational(ref final);
            Console.WriteLine();
        }
        void sub(ratioanlNum a, ratioanlNum b)
        {
            ratioanlNum final = new ratioanlNum();
            printRelational(ref a);
            Console.Write("-");
            printRelational(ref b);
            a.a += a.b * Math.Abs(a.k);
            b.a += b.b * Math.Abs(b.k);
            if (a.k < 0) a.a = -a.a;
            if (b.k < 0) b.a = -b.a;
            long lcmNum = multiplier(a.b, b.b);
            a.a *= (lcmNum / a.b);
            b.a *= (lcmNum / b.b);
            final.a = a.a - b.a;
            final.b = lcmNum;
            simplify(ref final);
            Console.Write(" = ");
            printRelational(ref final);
            Console.WriteLine();
        }
        void mul(ratioanlNum a, ratioanlNum b)
        {
            ratioanlNum final = new ratioanlNum();
            printRelational(ref a);
            Console.Write("*");
            printRelational(ref b);
            a.a += a.b * Math.Abs(a.k);
            b.a += b.b * Math.Abs(b.k);
            if (a.k < 0) a.a = -a.a;
            if (b.k < 0) b.a = -b.a;
            final.a = a.a * b.a;
            final.b = a.b * b.b;
            simplify(ref final);
            Console.Write(" = ");
            printRelational(ref final);
            Console.WriteLine();
        }
        void div(ratioanlNum a, ratioanlNum b)
        {
            ratioanlNum final = new ratioanlNum();
            printRelational(ref a);
            Console.Write("*");
            printRelational(ref b);
            a.a += a.b * Math.Abs(a.k);
            b.a += b.b * Math.Abs(b.k);
            if (a.k < 0) a.a = -a.a;
            if (b.k < 0) b.a = -b.a;
            long temp = b.a;
            b.a = b.b;
            b.b = temp;
            if (b.b < 0)
            {
                b.b = -b.b;
                b.a = -b.a;
            }
            final.a = a.a * b.a;
            final.b = a.b * b.b;
            simplify(ref final);
            Console.Write(" = ");
            printRelational(ref final);
            Console.WriteLine();
        }
        
        static void Main(string[] args)
        {
            Program p = new Program();
            string s1, s2;
            long a1, a2, b1, b2;
            Console.WriteLine("Enter first numner ");
            s1 = Console.ReadLine();
            Console.WriteLine("Enter second numner ");
            s2 = Console.ReadLine();
            string t1 = s1.Substring(0, s1.IndexOf("/"));
            a1 = Convert.ToInt64(t1);
            t1 = s1.Substring(s1.IndexOf("/")+1,1);
            b1 = Convert.ToInt64(t1);
            //Console.WriteLine(a1 + " " + b1 + " "+ a2 + " " +b2);
            string t2 = s2.Substring(0,s2.IndexOf("/"));
            a2 = Convert.ToInt64(t2);
            t2 = s2.Substring(s2.IndexOf("/")+1, 1);
            b2 = Convert.ToInt64(t2);
            ratioanlNum r = new ratioanlNum();
            ratioanlNum r1 = new ratioanlNum();
            r.a = a1;
            r.b = b1;
            r1.a = a2;
            r1.b = b2;
            p.simplify(ref r);
            p.simplify(ref r1);
            p.add(r,r1);
            p.sub(r, r1);
            p.mul(r, r1);
            p.div(r, r1);
            Console.ReadKey();
            //num = Convert.ToInt32(Console.ReadLine());

        }
    }
}
