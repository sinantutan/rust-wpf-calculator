using System;
using System.IO;
using System.Windows;
using calc_ui_wpf.ViewModels;

namespace calc_ui_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalculatorViewModel _calcViewModel = new CalculatorViewModel();

        public MainWindow()
        {
            


            InitializeComponent();



            
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TopBarGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                DragMove();
            }
        }


        private void exitRustCalcButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void minimizeRustCalcButton_Click(object sender, RoutedEventArgs e)
        {
            
            this.WindowState = WindowState.Minimized;
        }

        private void oneButton_Click(object sender, RoutedEventArgs e)
        {
            _calcViewModel.Num1 = _calcViewModel.Num1 * 10 + 1;
            inputLabel.Content = _calcViewModel.Num1.ToString();
        }

        private void plusCalcButton_Click(object sender, RoutedEventArgs e)
        {
            if (memoryLabel.Content is null)
            {
                _calcViewModel.Num1 = _calcViewModel
                                        .AddNumbers(Convert.ToDouble(inputLabel.Content), 0);
            }
            else if(memoryLabel.Content.ToString() == ""){
                _calcViewModel.Num1 = _calcViewModel
                                        .AddNumbers(Convert.ToDouble(inputLabel.Content), 0);
            }
            else {
                _calcViewModel.Num1 = _calcViewModel.AddNumbers(Convert.ToDouble(inputLabel.Content), 
                                                                Convert.ToDouble(memoryLabel.Content));
            }
            memoryLabel.Content = "+" + _calcViewModel.Num1.ToString();
            inputLabel.Content = "";
            _calcViewModel.Num1 = 0;
            _calcViewModel.IsAdd = true;
            _calcViewModel.IsSub = false;
            _calcViewModel.IsMulti = false;
            _calcViewModel.IsDiv = false;
        }

        private void enterCalcButton_Click(object sender, RoutedEventArgs e)
        {            
            if (_calcViewModel.IsAdd)
            {
                var xOrVar = _calcViewModel.AddNumbers(Convert.ToDouble(memoryLabel.Content), 
                                                       Convert.ToDouble(inputLabel.Content));
                inputLabel.Content = xOrVar.ToString();
                memoryLabel.Content = "";
                _calcViewModel.Num1 = xOrVar;
                _calcViewModel.IsAdd = false;
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            inputLabel.Content = "";
            memoryLabel.Content = "";
            _calcViewModel.Num1 = 0;
            _calcViewModel.IsAdd = false;
            _calcViewModel.IsSub = false;
            _calcViewModel.IsMulti = false;
            _calcViewModel.IsDiv = false;
        }

        private void twoButton_Click(object sender, RoutedEventArgs e)
        {
            _calcViewModel.Num1 = _calcViewModel.Num1 * 10 + 2;
            inputLabel.Content = _calcViewModel.Num1.ToString();
        }

        private void threeButton_Click(object sender, RoutedEventArgs e)
        {
            _calcViewModel.Num1 = _calcViewModel.Num1 * 10 + 3;
            inputLabel.Content = _calcViewModel.Num1.ToString();
        }

        private void zeroButton_Click(object sender, RoutedEventArgs e)
        {
            _calcViewModel.Num1 = _calcViewModel.Num1 * 10 + 0;
            inputLabel.Content = _calcViewModel.Num1.ToString();
        }

        private void decimalPointButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void negateButton_Click(object sender, RoutedEventArgs e)
        {
            //_calcViewModel.Num1 = _calcViewModel.Num1 * (-1);
            //inputLabel.Content = _calcViewModel.Num1.ToString();
        }
    }
}
