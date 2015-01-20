using Em.Workspace.Infrastructure;
using Em.Workspace.Infrastructure.Prism;
using Em.Workspace.Modules.MarketMaker.ViewModels;
using Em.Workspace.Modules.MarketMaker.Views;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em.Workspace.Modules.MarketMaker
{
    public class MarketMakerModule : ModuleBase
    {
        public MarketMakerModule(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager) { }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<Home>();            
            Container.RegisterType<IHomeViewModel, HomeViewModel>();
        }

        protected override void ResolveOutlookGroups()
        {
            RegionManager.Regions[RegionNames.OutlookBarRegion].Add(Container.Resolve<MarketMakerGroup>());
        }
    }
}
