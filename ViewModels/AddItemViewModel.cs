using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SaveUp.Models;
using SaveUp.Utils;

namespace SaveUp.ViewModels
{
    public class AddItemViewModel : BaseViewModel
    {
        private string description;
        private decimal price;

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public decimal Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public ICommand SaveCommand { get; }

        public AddItemViewModel()
        {
            SaveCommand = new Command(OnSave);
        }

        private async void OnSave()
        {
            var newItem = new SavedItem
            {
                Description = Description,
                Price = Price,
                DateSaved = DateTime.Now
            };

            var items = await JsonStorage.LoadItemsAsync();
            items.Add(newItem);
            await JsonStorage.SaveItemsAsync(items);

            await Shell.Current.GoToAsync("..");
        }
    }
}
