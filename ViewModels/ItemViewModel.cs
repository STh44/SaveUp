using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using SaveUp.Models;
using SaveUp.Utils;

namespace SaveUp.ViewModels
{
    public class ItemViewModel : BaseViewModel
    {
        public ObservableCollection<SavedItem> Items { get; set; } = new ObservableCollection<SavedItem>();

        public string Description { get; set; }
        public string Price { get; set; }

        public ICommand AddItemCommand { get; }
        public ICommand LoadItemsCommand { get; }
        public ICommand DeleteItemCommand { get; }

        public ItemViewModel()
        {
            AddItemCommand = new Command(async () => await AddItemAsync());
            LoadItemsCommand = new Command(async () => await LoadItemsAsync());
            DeleteItemCommand = new Command<SavedItem>(async (item) => await DeleteItemAsync(item));
        }

        private async Task AddItemAsync()
        {
            if (decimal.TryParse(Price, out decimal price))
            {
                var newItem = new SavedItem
                {
                    Description = Description,
                    Price = price,
                    DateSaved = DateTime.Now
                };

                Items.Add(newItem);
                await JsonStorage.SaveItemsAsync(new List<SavedItem>(Items));
                ClearInputs();
            }
        }

        private async Task LoadItemsAsync()
        {
            var loadedItems = await JsonStorage.LoadItemsAsync();
            Items.Clear();
            foreach (var item in loadedItems)
                Items.Add(item);
        }

        private async Task DeleteItemAsync(SavedItem item)
        {
            if (item != null)
            {
                Items.Remove(item);
                await JsonStorage.SaveItemsAsync(new List<SavedItem>(Items));
            }
        }

        private void ClearInputs()
        {
            Description = string.Empty;
            Price = string.Empty;
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(Price));
        }
    }
}
