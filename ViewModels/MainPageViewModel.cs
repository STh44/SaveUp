using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using SaveUp.Views;

namespace SaveUp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand NavigateToAddItemCommand { get; }
        public ICommand NavigateToItemListCommand { get; }

        public MainPageViewModel()
        {
            NavigateToAddItemCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(AddItemPage)));
            NavigateToItemListCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(ItemListPage)));
        }
    }
}

