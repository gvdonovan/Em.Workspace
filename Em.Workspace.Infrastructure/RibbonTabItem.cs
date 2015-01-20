using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em.Workspace.Infrastructure
{
    public class RibbonTabItem : Infragistics.Windows.Ribbon.RibbonTabItem, IRibbonTabItem
    {

        public RibbonTabItem()
        {
            this.SetResourceReference(StyleProperty, typeof(Infragistics.Windows.Ribbon.RibbonTabItem));
        }

        public IViewModel ViewModel
        {
            get
            {
                return (IViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }  
}
