using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using TreeView_Remove.Core.Models;
using TreeView_Remove.Core.Services;
using TreeView_Remove.Helpers;
using Windows.UI.Xaml;
using WinUI = Microsoft.UI.Xaml.Controls;

namespace TreeView_Remove.ViewModels
{
    public class TreeViewViewModel : Observable
    {
        private ICommand _itemInvokedCommand;
        private object _selectedItem;
        private ICommand _delCommand;

        public object SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        public ObservableCollection<SampleCompany> SampleItems { get; } = new ObservableCollection<SampleCompany>();

        public ICommand ItemInvokedCommand => _itemInvokedCommand ?? (_itemInvokedCommand = new RelayCommand<WinUI.TreeViewItemInvokedEventArgs>(OnItemInvoked));
        public ICommand DelCommand => _delCommand ?? (_delCommand = new RelayCommand<RoutedEventArgs>(OnDelClick));

        private void OnDelClick(RoutedEventArgs obj)
        {

            SampleItems.RemoveAt(0);
            SampleItems[0].IsSelected = true;
        }

        public TreeViewViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            var data = await SampleDataService.GetTreeViewDataAsync();
            foreach (var item in data)
            {
                SampleItems.Add(item);
            }
                                  
        }

        private void OnItemInvoked(WinUI.TreeViewItemInvokedEventArgs args)
            => SelectedItem = args.InvokedItem;
    }
}
