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
using WpfBookShop.Model;
using WpfBookShop.ViewModel;

namespace WpfBookShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int SelectedIndex;
        public static ListView ListBookView;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewDataManager();
            ListBookView = listbookview;
        }
    }
}
