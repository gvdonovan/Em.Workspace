using Em.Workspace.Infrastructure;
using Em.Workspace.Modules.MarketMaker.ViewModels;
using Infragistics.Controls.Menus;
using Infragistics.Windows.OutlookBar;

namespace Em.Workspace.Modules.MarketMaker.Views
{
    public partial class MarketMakerGroup : OutlookBarGroup, IOutlookBarGroup
    {
        public MarketMakerGroup(MarketMakerGroupViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public string DefaultNavigationPath
        {
            get
            {

                var item = treeView.SelectionSettings.SelectedNodes[0] as XamDataTreeNode;

                if (item != null)
                {
                    return ((INavigationItem)item.Data).NavigationPath;
                }
                else
                {
                    return typeof(Em.Workspace.Modules.MarketMaker.Views.Home).FullName;
                }
            }
        }
    }
}
