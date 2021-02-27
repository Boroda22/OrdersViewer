using OrdersViewer.View;
using OrdersViewer.ViewModel;

using System.Windows;

namespace OrdersViewer.Service
{
    class ChildWindowDialogManager
    {
		public static void Show(object typeClient, bool is_modal, Window parentWindow)
		{
			if (typeClient != null)
			{
				if (typeClient.GetType() == typeof(MainWindowViewModel))
				{
					MainWindow mainWindow = new MainWindow();
					mainWindow.DataContext = typeClient;
					mainWindow.Show();
				}
				else if(typeClient.GetType() == typeof(EmployeeWindowViewModel))
                {
					EmployeeWindow employeeWindow = new EmployeeWindow((EmployeeWindowViewModel)typeClient);
					employeeWindow.Owner = parentWindow;
                    if (is_modal)
                    {
						employeeWindow.ShowDialog();
                    }
                    else
                    {
						employeeWindow.Show();
                    }
                }
				else if (typeClient.GetType() == typeof(SubdivisionWindowViewModel))
				{
					SubdivisionWindow subdivisionWindow = new SubdivisionWindow((SubdivisionWindowViewModel)typeClient);
					subdivisionWindow.Owner = parentWindow;
					if (is_modal)
					{
						subdivisionWindow.ShowDialog();
					}
					else
					{
						subdivisionWindow.Show();
					}
				}
				else if(typeClient.GetType() == typeof(OrderWindowViewModel))
                {
					OrderWindow orderWindow = new OrderWindow((OrderWindowViewModel)typeClient);
					orderWindow.Owner = parentWindow;
                    if (is_modal)
                    {
						orderWindow.ShowDialog();
                    }
                    else
                    {
						orderWindow.Show();
                    }
                }
			}
		}
	}
}
