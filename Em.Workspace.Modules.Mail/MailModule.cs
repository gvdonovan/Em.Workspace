using Biff.Services.Contracts;
using Em.Workspace.Infrastructure;
using Em.Workspace.Infrastructure.Prism;
using Em.Workspace.Modules.Mail.ViewModels;
using Em.Workspace.Modules.Mail.Views;
using Em.Workspace.Services;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em.Workspace.Modules.Mail
{
    public class MailModule : ModuleBase
    {
        public MailModule(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager) { }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<DefaultView>();
            Container.RegisterTypeForNavigation<Em.Workspace.Modules.Mail.Views.Mail>();
            Container.RegisterType<IMailViewModel, MailViewModel>();
            Container.RegisterType<IBiffService, BiffService>();
        }

        protected override void ResolveOutlookGroups()
        {
            RegionManager.Regions[RegionNames.OutlookBarRegion].Add(Container.Resolve<MailGroup>());
        }
    }
}
