using Em.Workspace.Infrastructure;
using Em.Workspace.Modules.Mail.ViewModels;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;

namespace Em.Workspace.Modules.Mail.Views
{
    [RibbonTab(typeof(HomeTab))]
    [RibbonTab(typeof(HomeTab))]
    [RibbonTab(typeof(HomeTab))]
    [RibbonTab(typeof(HomeTab))]    
    public partial class Mail 
    {
         public Mail(IMailViewModel viewModel, IRegionManager regionManager, IEventAggregator eventAggregator)
            : base(viewModel, regionManager, eventAggregator)
        {
            InitializeComponent();
        }
    }
}
