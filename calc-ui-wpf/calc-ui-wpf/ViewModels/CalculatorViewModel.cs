using System.Runtime.InteropServices;

namespace calc_ui_wpf.ViewModels
{
    public class CalculatorViewModel 
    {
        [DllImport("rust_calc.dll")]
        public static extern double add_f64(double number1, double number2);

        [DllImport("rust_calc.dll")]
        public static extern double sub_f64(double number1, double number2);

        [DllImport("rust_calc.dll")]
        public static extern double multi_f64(double number1, double number2);

        [DllImport("rust_calc.dll")]
        public static extern double div_f64(double number1, double number2);

        private double _num1;
        private double _num2;

        public double Num1 { get; set; }
        public double Num2 { get; set; }

        public double AddNumbers(double num1, double num2)
        {
            return add_f64(num1, num2);
        }
    }
}
