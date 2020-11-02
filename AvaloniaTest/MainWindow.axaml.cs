using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System;

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


        public void TestMethod(int val)
        {
            Console.Write(val);
            Dispatcher.UIThread.InvokeAsync(() => { TestMethod(curVal); }, DispatcherPriority.SystemIdle);
        }

        int curVal;
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            curVal++;
            Console.WriteLine(curVal);
            Dispatcher.UIThread.InvokeAsync(() => { TestMethod(curVal); }, DispatcherPriority.SystemIdle);
        }
    }
}
