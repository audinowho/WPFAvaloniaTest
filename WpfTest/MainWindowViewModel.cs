using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfTest
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> TestItems { get; set; }
        public MainWindowViewModel()
        {
            TestItems = new ObservableCollection<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
