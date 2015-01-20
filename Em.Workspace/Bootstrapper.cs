using Em.Workspace.Infrastructure.Prism;
using Em.Workspace.Modules.Mail;
using Em.Workspace.Modules.MarketMaker;
using Infragistics.Windows.OutlookBar;
using Infragistics.Windows.Ribbon;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using System.Windows;

namespace Em.Workspace
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            
        }

        protected override Microsoft.Practices.Prism.Modularity.IModuleCatalog CreateModuleCatalog()
        {
            //return base.CreateModuleCatalog();

            var catalog = new ModuleCatalog();
            catalog.AddModule(typeof(MailModule));
            catalog.AddModule(typeof(MarketMakerModule));
            return catalog;
        }

        protected override Microsoft.Practices.Prism.Regions.RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(XamOutlookBar), Container.TryResolve<XamOutlookBarRegionAdapter>());
            mappings.RegisterMapping(typeof(XamRibbon), Container.TryResolve<XamRibbonRegionAdapter>());
            return mappings;
        }

        protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            var behaviors = base.ConfigureDefaultRegionBehaviors();
            behaviors.AddIfMissing(XamRibbonRegionBehavior.BehaviorKey, typeof(XamRibbonRegionBehavior));
            return behaviors;
        }
        
    }

    public interface IAuthenticationService
    {
        
    }
}
