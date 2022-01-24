using System.Windows;
using calc_ui_wpf.ViewModels;

namespace calc_ui_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var calcViewModel = new CalculatorViewModel();
            double newNum = calcViewModel.AddNumbers(40.0, 60.0);
            InitializeComponent();

            addNum.Content = newNum.ToString();
        }
    }
}
