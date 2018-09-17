using System;

namespace CalcAircraft.Data
{
    class Point
    {
        #region var´s
        public double X { get; set; }
        public double Degree { get; set; }
        public double Y { get; set; }
        public double D { get; set; }
        public double K { get; set; }
        #endregion

        public Point(double x, double y, double degree)
        {
            X = x;
            Y = y;
            Degree = degree;
            K = Math.Tan((Math.PI / 180) * degree);
            D = CalcD();
        }

        /// <summary>
        /// Calculates the d of the point
        /// </summary>
        public double CalcD() => -X * K + Y;
    }
}