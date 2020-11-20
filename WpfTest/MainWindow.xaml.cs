using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
        private void AddTons_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel vm = (MainWindowViewModel)DataContext;
            for (int ii = 0; ii < 10000; ii++)
                vm.TestItems.Add(vm.TestItems.Count.ToString("D5"));
        }


        public void TestMethod(int val)
        {
            Console.Write(val);
            this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.SystemIdle, new TestMethodDelegate(() => { TestMethod(val); }));
        }

        public delegate void TestMethodDelegate();

        int curVal;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            curVal++;
            Console.WriteLine(curVal);
            this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.SystemIdle, new TestMethodDelegate(() => { TestMethod(curVal); }));
        }
    }
}
