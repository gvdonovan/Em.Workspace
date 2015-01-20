using Biff.Model;
using Biff.Services.Contracts;
using Em.Workspace.Infrastructure;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em.Workspace.Modules.Mail.ViewModels
{
    public interface IMailViewModel : IViewModel
    {
    }

    public class MailViewModel : NavigationAwareViewModelBase, IMailViewModel
    {
        private readonly IBiffService _biff;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;

        private List<BiffObject> _items;
        public List<BiffObject> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged("Items"); }
        } 

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public MailViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IBiffService biff)
        {
            _biff = biff;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            NavigateCommand = new DelegateCommand<string>(Navigate);

            GetBiff();

        }

        private async void GetBiff()
        {
            var results = await _biff.GetAsync();
            Items = results.ToList(); 
        }

        private void Navigate(string obj)
        {
            var parameters = new NavigationParameters();
            parameters.Add("Folder", obj);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, new Uri("Mail", UriKind.Relative), parameters);
        }

        public override void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            Title = String.Format("Mail - {0}", navigationContext.Parameters[MenuFolders.FolderKey]);
            base.OnNavigatedTo(navigationContext);

            _eventAggregator.GetEvent<ViewActivateEvent>().Publish(Title);
        }
    }    
}
