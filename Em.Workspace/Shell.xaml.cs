using Em.Workspace.Infrastructure;
using Infragistics.Windows.Ribbon;
using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Em.Workspace
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : XamRibbonWindow
    {        
        public Shell(ShellViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
                       
        }

        private void OnOutlookBarGroupChanging(object sender, Infragistics.Windows.OutlookBar.Events.SelectedGroupChangingEventArgs e)
        {
            var group = e.NewSelectedOutlookBarGroup as IOutlookBarGroup;
            if (group != null)
            {
                Commands.NavigateCommand.Execute(group.DefaultNavigationPath);
            }
        }
    }
}
