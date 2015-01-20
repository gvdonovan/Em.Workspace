using Em.Workspace.Infrastructure;
using Em.Workspace.Modules.Mail.ViewModels;
using Infragistics.Controls.Menus;
using Infragistics.Windows.OutlookBar;

namespace Em.Workspace.Modules.Mail.Views
{
    public partial class MailGroup : OutlookBarGroup, IOutlookBarGroup
    {
        public MailGroup(MailGroupViewModel viewModel)
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
                    return ((INavigationItem) item.Data).NavigationPath;
                }
                else
                {
                    return typeof(Em.Workspace.Modules.Mail.Views.DefaultView).FullName;
                }
            }
        }
    }
}
