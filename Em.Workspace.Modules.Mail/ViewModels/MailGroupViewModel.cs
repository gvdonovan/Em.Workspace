using Em.Workspace.Infrastructure;
using Em.Workspace.Modules.Mail.Views;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em.Workspace.Modules.Mail.ViewModels
{
    public class MailGroupViewModel : ViewModelBase
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

        public MailGroupViewModel()
        {
            GenerateMenu();
        }

        private void GenerateMenu()
        {
            Items = new ObservableCollection<NavigationItem>();

            var root = new NavigationItem() { Caption = "Personal Folders", NavigationPath = typeof(DefaultView).FullName };
            root.Items.Add(new NavigationItem() { Caption = "Inbox", NavigationPath = CreateNavigationPath(MenuFolders.Inbox) });
            root.Items.Add(new NavigationItem() { Caption = "Drafts", NavigationPath = CreateNavigationPath(MenuFolders.Drafts) });
            root.Items.Add(new NavigationItem() { Caption = "Sent Items", NavigationPath = CreateNavigationPath(MenuFolders.Sent) });
            root.Items.Add(new NavigationItem() { Caption = "Deleted Items", NavigationPath = CreateNavigationPath(MenuFolders.Deleted) });

            Items.Add(root);
        }

        private string CreateNavigationPath(string folder)
        {
            var query = new NavigationParameters();
            query.Add(MenuFolders.FolderKey, folder);
            return typeof(Em.Workspace.Modules.Mail.Views.Mail).FullName + query;            
        }
    }
}
