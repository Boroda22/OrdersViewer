using OrdersViewer.Model;
using OrdersViewer.Service;
using OrdersViewer.ViewModel;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OrdersViewer
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        ChildWindowDialogManager dialogManager;
        public App()
        {
            MainModel model = new MainModel();
            MainWindowViewModel viewModel = new MainWindowViewModel(model);

            ChildWindowDialogManager.Show(viewModel, false, null);
        }
    }
}
