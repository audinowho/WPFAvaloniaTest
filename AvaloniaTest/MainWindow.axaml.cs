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
                //await Task.Yield();
                await Task.Delay(1000);
            }
        }

    }
}
