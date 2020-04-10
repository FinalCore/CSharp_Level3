using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RAEDToolBar
{
    public partial class RAEDToolBarControl : UserControl
    {
        public event RoutedEventHandler Add;
        public event RoutedEventHandler Edit;
        public event RoutedEventHandler Delete;

        ////Определяем DependencyProperty для доступа к комбобоксу пользовательского контрола RAEDToolbar из разметки главноого окна
        public static readonly DependencyProperty CbUserControlContentProperty;

        static RAEDToolBarControl()
        {
            CbUserControlContentProperty = DependencyProperty.Register("cbContent", typeof(List<string>), typeof(RAEDToolBarControl));
        }

        public RAEDToolBarControl()
        {
            InitializeComponent();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e) => Add?.Invoke(this, new RoutedEventArgs());
        private void EditButtonClick(object sender, RoutedEventArgs e) => Edit?.Invoke(this, new RoutedEventArgs());
        private void DeleteButtonClick(object sender, RoutedEventArgs e) => Delete?.Invoke(this, new RoutedEventArgs());
    }
}
