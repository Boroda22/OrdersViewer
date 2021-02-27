using OrdersViewer.ViewModel;

using System.Windows;

namespace OrdersViewer.View
{
    public partial class OrderWindow : Window
    {
        private OrderWindowViewModel orderWindowViewModel;
        
        public OrderWindow(OrderWindowViewModel viewModel)
        {
            InitializeComponent();

            orderWindowViewModel = viewModel;
            DataContext = orderWindowViewModel;

            orderWindowViewModel.PropertyChanged += OrderWindowViewModel_PropertyChanged;
        }

        private void OrderWindowViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "CanClose")
                Close();
        }
    }
}
