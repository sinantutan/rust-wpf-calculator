using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace calc_ui_wpf.ViewModels
{
    public class CalculatorViewModel 
    {
        [DllImport("rust_calc.dll")]
        public static extern double add_f64(double number1, double number2);
        private double _num1;
        private double _num2;

        public double AddNumbers(double num1, double num2)
        {
            return add_f64(num1, num2);
        }
    }
}
