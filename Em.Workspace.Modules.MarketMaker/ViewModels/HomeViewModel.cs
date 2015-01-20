using Em.Workspace.Infrastructure;
using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em.Workspace.Modules.MarketMaker.ViewModels
{
    public interface IHomeViewModel : IViewModel
    {
    }

    public class HomeViewModel : NavigationAwareViewModelBase, IHomeViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        private ObservableCollection<SpotPrice> _spotPrices;
        public ObservableCollection<SpotPrice> SpotPrices
        {
            get { return _spotPrices; }
            set
            {
                _spotPrices = value;
                OnPropertyChanged("SpotPrices");
            }
        }

        public HomeViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _spotPrices = new ObservableCollection<SpotPrice>();
            _spotPrices.Add(new SpotPrice { MetalId = 1, Symbol = "Au", Name = "Gold", Current = 1233.44M, Low = 1220.10M, High = 1235.84M });
            _spotPrices.Add(new SpotPrice { MetalId = 2, Symbol = "Ag", Name = "Silver", Current = 17.14M, Low = 16.99M, High = 17.50M, IsUp = true });
            _spotPrices.Add(new SpotPrice { MetalId = 3, Symbol = "Pt", Name = "Platinum", Current = 1257.44M, Low = 1250.10M, High = 1265.84M });
            _spotPrices.Add(new SpotPrice { MetalId = 4, Symbol = "Pd", Name = "Palladium", Current = 755.44M, Low = 750.10M, High = 759.84M, IsUp = true });
        }

        public override void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            Title = String.Format("{0}", navigationContext.Parameters[MenuFolders.FolderKey]);
            base.OnNavigatedTo(navigationContext);

            _eventAggregator.GetEvent<ViewActivateEvent>().Publish(Title);
        }
    }

    public class SpotPrice
    {
        public int MetalId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public bool IsUp { get; set; }
        public decimal Current { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
    }
}
