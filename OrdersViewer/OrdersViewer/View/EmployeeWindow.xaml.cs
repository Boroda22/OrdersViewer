using OrdersViewer.ViewModel;

using System.Windows;

namespace OrdersViewer.View
{
    public partial class EmployeeWindow : Window
    {
        private EmployeeWindowViewModel emplViewModel;

        public EmployeeWindow(EmployeeWindowViewModel employeeWindowView)
        {
            InitializeComponent();

            emplViewModel = employeeWindowView;
            DataContext = emplViewModel;

            employeeWindowView.PropertyChanged += EmployeeWindowView_PropertyChanged;
        }

        private void EmployeeWindowView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "CanClose")
                Close();
        }
    }
}
