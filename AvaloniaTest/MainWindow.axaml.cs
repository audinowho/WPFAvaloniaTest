using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaTest
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void OneTime_Click(object sender, RoutedEventArgs e)
        {
            curVal++;
            Console.WriteLine(curVal);
        }

        int curVal;
        public void InvokeAsyncRecursive_Click(object sender, RoutedEventArgs e)
        {
            curVal++;
            Console.WriteLine(curVal);
            Dispatcher.UIThread.InvokeAsync(() => { TestMethod(curVal); }, DispatcherPriority.SystemIdle);
        }
        public void InvokeAsyncLoopYield_Click(object sender, RoutedEventArgs e)
        {
            curVal++;
            Console.WriteLine(curVal);
            Dispatcher.UIThread.InvokeAsync(() => { AsyncTestMethod(curVal); }, DispatcherPriority.SystemIdle);
        }
        public async void TaskRunLoopYield_Click(object sender, RoutedEventArgs e)
        {
            curVal++;
            Console.WriteLine(curVal);
            await Task.Run(()=> { AsyncTestMethod(curVal); });
        }

        public void TestMethod(int val)
        {
            Console.WriteLine("Tick {0} from Thread {1}", val, Thread.CurrentThread.ManagedThreadId);
            Dispatcher.UIThread.InvokeAsync(() => { TestMethod(curVal); }, DispatcherPriority.SystemIdle);
        }

        public async void AsyncTestMethod(int val)
        {
            while (true)
            {
                Console.WriteLine("Tick {0} from Thread {1}", val, Thread.CurrentThread.ManagedThreadId);
                await Task.Run(AsyncTestIter);
            }
        }

        public async void AsyncTestIter()
        {
            await Task.Run(AsyncTestIter2);
        }
        public async void AsyncTestIter2()
        {
            await Task.Delay(15);
        }


        public void AddTons_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel vm = (MainWindowViewModel)DataContext;
            for (int ii = 0; ii < 3000; ii++)
                vm.TestItems.Add(vm.TestItems.Count.ToString("D4"));
        }

        public async void ModalDialog_Open(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            bool result = await window.ShowDialog<bool>(this);
            Console.WriteLine("Dialog Complete");
        }
    }
}
