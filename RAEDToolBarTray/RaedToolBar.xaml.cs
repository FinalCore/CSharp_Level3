using System.Windows;
using System.Windows.Controls;


namespace RAEDToolBar
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
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
