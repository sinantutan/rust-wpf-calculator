using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace calc_ui_wpf.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged, ICommand
    {
        [DllImport("rust_calc.dll")]
        private static extern double add_f64(double number1, double number2);

        [DllImport("rust_calc.dll")]
        private static extern double sub_f64(double number1, double number2);

        [DllImport("rust_calc.dll")]
        private static extern double multi_f64(double number1, double number2);

        [DllImport("rust_calc.dll")]
        private static extern double div_f64(double number1, double number2);

        [DllImport("rust_calc.dll")]
        private static extern double pow2_f64(double baseNum);

        private double _num1;
        private double _num2;

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler? CanExecuteChanged;

        public double Num1 { get; set; }
        public double Num2 { get; set; }

        public double AddNumbers(double num1, double num2)
        {
            return add_f64(num1, num2);
        }

        public double SubNumbers(double num1, double num2)
        {
            return sub_f64(num1, num2);
        }

        public double MultiplyNumbers(double num1, double num2)
        {
            return multi_f64(num1, num2);
        }

        public double DivideNumbers(double num1, double num2)
        {
            // catch error in UI..
            return div_f64(num1, num2); 
        }

        public double SquareNum(double baseNum)
        {
            return pow2_f64(baseNum);
        }

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
