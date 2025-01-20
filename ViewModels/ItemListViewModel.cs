using System.Collections.ObjectModel;
using System.Linq;
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
        public ICommand DeleteItemCommand { get; }
        public ICommand RefreshCommand { get; }

        public ItemListViewModel()
        {
            AddItemCommand = new Command(OnAddItem);
            DeleteItemCommand = new Command<SavedItem>(OnDeleteItem);
            RefreshCommand = new Command(OnRefresh);
            LoadItems();
        }

        private async void LoadItems()
        {
            var items = await JsonStorage.LoadItemsAsync();
            Items.Clear();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        private async void OnAddItem()
        {
            await Shell.Current.GoToAsync(nameof(AddItemPage));
        }

        private async void OnDeleteItem(SavedItem item)
        {
            if (item != null)
            {
                Items.Remove(item);
                await JsonStorage.DeleteItemAsync(item);
            }
        }

        private void OnRefresh()
        {
            LoadItems();
        }
    }
}
