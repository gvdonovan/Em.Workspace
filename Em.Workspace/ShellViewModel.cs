using Em.Workspace.Infrastructure;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em.Workspace
{
    public class ShellViewModel : ViewModelBase
    {
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;

        private string _status;
        public string Status
        {
            get { return this._status; }
            set
            {
                _status = value; 
                OnPropertyChanged("Status");
            }
        }

        public DelegateCommand<String> NavigateCommand { get; set; }

        public ShellViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

            NavigateCommand = new DelegateCommand<String>(Navigate);
            Commands.NavigateCommand.RegisterCommand(NavigateCommand);

            Status = "Ready";

            _eventAggregator.GetEvent<ViewActivateEvent>().Subscribe(UpdateStatus, ThreadOption.UIThread);
            
        }

        private void UpdateStatus(string obj)
        {
            Status = obj;
        }

        private void Navigate(string navigationPath)
        {
            if (string.IsNullOrWhiteSpace(navigationPath))
                return;

            if (!String.IsNullOrWhiteSpace(navigationPath))
                _regionManager.RequestNavigate(RegionNames.ContentRegion, navigationPath);
        }
    }
}
