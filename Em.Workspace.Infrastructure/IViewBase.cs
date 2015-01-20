using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em.Workspace.Infrastructure
{
    public interface IViewBase
    {
        IViewModel ViewModel { get; set; }
        IList<IRibbonTabItem> RibbonTabs { get; }
    }
}
