using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Point = CalcAircraft.Data.Point;

namespace CalcAircraft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Calculation
        /// <summary>
        /// Calculate the position of the aircraft
        /// </summary>
        /// <returns>The position of the aircraft</returns>
        static double[] CalcAircraft(Point a, Point b)
        {
            double[] retVal = new double[2];

            retVal[0] = ((a.D - b.D) / (a.K - b.K)) * -1;
            retVal[1] = retVal[0] * a.K + a.D;

            return retVal;
        }
        #endregion

        #region Event´s
        /// <summary>
        /// Ok click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            //string[] aircraftData = LoadFile();

            if (FxTextBox.Text.Equals(string.Empty) || FyTextBox.Text.Equals(string.Empty) || FdegreeTextBox.Text.Equals(string.Empty) ||
                SxTextBox.Text.Equals(string.Empty) || SyTextBox.Text.Equals(string.Empty) || SdegreeTextBox.Text.Equals(string.Empty))
            {
                Log("Invalid input at the coordinates!");
            }
            else
            {
                Point a = new Point(Convert.ToDouble(FxTextBox.Text), Convert.ToDouble(FyTextBox.Text), Convert.ToDouble(FdegreeTextBox.Text));
                Point b = new Point(Convert.ToDouble(SxTextBox.Text), Convert.ToDouble(SyTextBox.Text), Convert.ToDouble(SdegreeTextBox.Text));

                double[] aircraftCor = CalcAircraft(a, b);

                PositionOutput.Text = "Poistion: \n(" + Math.Round(aircraftCor[0], 2) + "/" + Math.Round(aircraftCor[1], 2) + ")";
            }
        }
        #endregion

        #region Output

        /// <summary>
        /// Simple logging function
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="caption"></param>
        private void Log(string msg, string caption = "Info") =>
            MessageBox.Show("[" + DateTime.Now + "] " + msg, caption);

        #endregion
    }
}
