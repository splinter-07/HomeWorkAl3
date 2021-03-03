using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace HomeWorkAl3
{

    public class PointClass
    {
        public int X;
        public int Y;
    }

    public struct PointStruct
    {
        public int X;
        public int Y;
    }

    class Program
    {
        public static PointClass[] pointCl = new PointClass[2];
        public static PointStruct[] pointSt = new PointStruct[2];
        static void Main(string[] args)
        {
            
            pointCl[0] = new PointClass { X = 1, Y = 2 };
            pointCl[1] = new PointClass { X = 2, Y = 3 };

            pointSt[0] = new PointStruct { X = 1, Y = 2 };
            pointSt[1] = new PointStruct { X = 2, Y = 3 };
           
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }


    public class BechmarkClass
    {

        public static float PointDistanceReferenceTypes(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static float PointDistanceValueTypesFloat(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static double PointDistanceValueTypesDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public static float PointDistanceValueTypesWithoutSqrt(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        [Benchmark]
        public void TestPointDistanceReferenceTypes()
        {
            var point1 = new PointClass { X = 1, Y = 2 };
            var point2 = new PointClass { X = 1, Y = 2 };
            PointDistanceReferenceTypes(point1, point2);
            //PointDistanceReferenceTypes(Program.pointCl[0], Program.pointCl[1]);
        }
        [Benchmark]
        public void TestPointDistanceValueTypesFloat()
        {
            PointDistanceValueTypesFloat(Program.pointSt[0], Program.pointSt[1]);
        }
        [Benchmark]
        public void TestPointDistanceValueTypesDouble()
        {
            PointDistanceValueTypesDouble(Program.pointSt[0], Program.pointSt[1]);
        }
        [Benchmark]
        public void TestPointDistanceValueTypesWithoutSqrt()
        {
            PointDistanceValueTypesWithoutSqrt(Program.pointSt[0], Program.pointSt[1]);
        }
    }
}