using OrdersViewer.ViewModel;

using System.Windows;

namespace OrdersViewer.View
{
    public partial class SubdivisionWindow : Window
    {
        private SubdivisionWindowViewModel subdivWievModel;

        public SubdivisionWindow(SubdivisionWindowViewModel viewModel)
        {
            InitializeComponent();

            subdivWievModel = viewModel;
            DataContext = subdivWievModel;

            viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CanClose")
                Close();
        }
    }
}
