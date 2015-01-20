using Em.Workspace.Infrastructure;
using Em.Workspace.Modules.MarketMaker.ViewModels;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;

namespace Em.Workspace.Modules.MarketMaker.Views
{
    [RibbonTab(typeof(HomeTab))]
    public partial class Home
    {
        public Home(IHomeViewModel viewModel, IRegionManager regionManager, IEventAggregator eventAggregator)
            : base(viewModel, regionManager, eventAggregator)
        {
            InitializeComponent();
        }
    }
}
