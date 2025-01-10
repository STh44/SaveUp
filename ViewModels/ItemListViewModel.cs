using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using SaveUp.Models;
using SaveUp.Utils;
using SaveUp.Views;

namespace SaveUp.ViewModels
{
    public class ItemListViewModel : BaseViewModel
    {
        public ObservableCollection<SavedItem> Items { get; } = new ObservableCollection<SavedItem>();

        public ICommand AddItemCommand { get; }

        public ItemListViewModel()
        {
            AddItemCommand = new Command(OnAddItem);
            LoadItems();
        }

        private async void LoadItems()
        {
            var items = await JsonStorage.LoadItemsAsync();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        private async void OnAddItem()
        {
            await Shell.Current.GoToAsync(nameof(AddItemPage));
        }
    }
}
