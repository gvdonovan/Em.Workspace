using Infragistics.Controls.Menus;
using Microsoft.Practices.Prism.Interactivity;
using Microsoft.Practices.Prism.Commands;
using System;

namespace Em.Workspace.Infrastructure.Prism
{
    public class XamDataTreeCommandBehavior : CommandBehaviorBase<XamDataTree>
    {
        public XamDataTreeCommandBehavior(XamDataTree tree)
            : base(tree)
        {
            tree.ActiveNodeChanged += OnNodeChanged;     
        }

        private void OnNodeChanged(object sender, ActiveNodeChangedEventArgs e)
        {
            var parameter = e.NewActiveTreeNode.Data as INavigationItem;
            var commandParameter = String.Empty;
            
            if (parameter != null)
                CommandParameter = parameter.NavigationPath;
            else
                CommandParameter = String.Empty;

            ExecuteCommand(CommandParameter);
        }
    }
}
