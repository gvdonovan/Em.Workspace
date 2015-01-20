using Em.Workspace.Infrastructure;
using Em.Workspace.Modules.MarketMaker.Views;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em.Workspace.Modules.MarketMaker.ViewModels
{
    public class MarketMakerGroupViewModel: ViewModelBase
    {
        private ObservableCollection<NavigationItem> _items;
        public ObservableCollection<NavigationItem> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public MarketMakerGroupViewModel()
        {
            GenerateMenu();
        }

        private void GenerateMenu()
        {
            Items = new ObservableCollection<NavigationItem>();

            var root = new NavigationItem() { Caption = "Home", NavigationPath = typeof(Home).FullName };
            root.Items.Add(new NavigationItem() { Caption = "Trades", NavigationPath = CreateNavigationPath(MenuFolders.Trades) });
            root.Items.Add(new NavigationItem() { Caption = "Dashboards", NavigationPath = CreateNavigationPath(MenuFolders.Dashboards) });
            
            Items.Add(root);
        }

        private string CreateNavigationPath(string folder)
        {
            var query = new NavigationParameters();
            query.Add(MenuFolders.FolderKey, folder);
            return typeof(Em.Workspace.Modules.MarketMaker.Views.Home).FullName + query;            
        }
    }
}
