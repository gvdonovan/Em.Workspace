using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Em.Workspace.Infrastructure
{
    public class ViewBase : UserControl, IViewBase, INavigationAware
    {
        protected IRegionManager RegionManager { get; private set; }
        protected IEventAggregator EventAggregator { get; private set; }
        public IList<IRibbonTabItem> RibbonTabs { get; private set; }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }

        public ViewBase()
        {
            RibbonTabs = new List<IRibbonTabItem>();
        }

        public ViewBase(IViewModel viewModel)
            : this()
        {
            ViewModel = viewModel;
        }

        public ViewBase(IRegionManager regionManager)
            : this()
        {
            RegionManager = regionManager;
        }

        public ViewBase(IViewModel viewModel, IRegionManager regionManager)
            : this(viewModel)
        {
            RegionManager = regionManager;
        }

        public ViewBase(IViewModel viewModel, IEventAggregator eventAggregator)
            : this(viewModel)
        {
            EventAggregator = eventAggregator;
        }

        public ViewBase(IViewModel viewModel, IRegionManager regionManager, IEventAggregator eventAggregator)
            : this(viewModel, regionManager)
        {
            EventAggregator = eventAggregator;
        }

        #region INavigationAware Members
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            if (RegionManager != null)
            {
                var tabRegion = RegionManager.Regions[RegionNames.RibbonTabRegion];
                RibbonTabs.ToList().ForEach(tabRegion.Remove);
            }
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (RegionManager != null)
            {
                var tabRegion = RegionManager.Regions[RegionNames.RibbonTabRegion];
                RibbonTabs.ToList().ForEach(tab => tabRegion.Add(tab));
            }

            if (EventAggregator != null)
                EventAggregator.GetEvent<ViewActivateEvent>().Publish(ViewModel.Title);
        }
        #endregion

    }
}
