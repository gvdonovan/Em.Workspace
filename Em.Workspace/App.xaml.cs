using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Em.Workspace
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            

            //var b = new Biff();
            //var dialogResult = b.ShowDialog();


            var bs = new Bootstrapper();
            bs.Run();
        }
    }
}
