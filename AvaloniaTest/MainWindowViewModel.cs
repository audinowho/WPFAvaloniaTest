using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using ReactiveUI;
using Avalonia.Threading;

namespace AvaloniaTest
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<string> TestItems { get; }

        public MainWindowViewModel()
        {
            TestItems = new ObservableCollection<string>();
        }
    }
}
