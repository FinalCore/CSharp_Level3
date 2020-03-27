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

namespace RAEDToolBar
{
    public partial class RAEDToolBarControl : UserControl
    {
        public event RoutedEventHandler Add;
        public event RoutedEventHandler Edit;
        public event RoutedEventHandler Delete;

        public RAEDToolBarControl()
        {
            InitializeComponent();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e) => Add?.Invoke(this, new RoutedEventArgs());
        private void EditButtonClick(object sender, RoutedEventArgs e) => Edit?.Invoke(this, new RoutedEventArgs());
        private void DeleteButtonClick(object sender, RoutedEventArgs e) => Delete?.Invoke(this, new RoutedEventArgs());
    }
}
