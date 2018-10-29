using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8
{
    public class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector(float a, float b, float c)
        {
            X = a;
            Y = b;
            Z = c;
        }
        public static void showVector(Vector vec) => Console.WriteLine(vec.X + "; " + vec.Y + "; " + vec.Z);
        public static float GetSum(Vector vec) => vec.X + vec.Y + vec.Z;


        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);


        public static bool operator >(Vector a, Vector b) => (a.X > b.X && a.Y > b.Y && a.Z > b.Z) ? true : false;
        public static bool operator <(Vector a, Vector b) => (a.X < b.X && a.Y < b.Y && a.Z < b.Z) ? true : false;

        public static Vector operator ==(Vector a, Vector b) => a = b;
        public static Vector operator !=(Vector a, Vector b) => b = a;


        public static bool operator true(Vector a) => ((a.X != 0) || (a.Y != 0) || (a.Z != 0));
        public static bool operator false(Vector a) => ((a.X == 0) && (a.Y == 0) && (a.Z == 0));
    }
}
