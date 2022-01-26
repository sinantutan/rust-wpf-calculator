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

            InitializeComponent();

            
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
    }
}
