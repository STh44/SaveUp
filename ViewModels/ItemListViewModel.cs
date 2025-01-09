using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SaveUp.Models;
using System.Collections.ObjectModel;

namespace SaveUp.ViewModels
{
    public class ItemListViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; }

        public ItemListViewModel()
        {
            Items = new ObservableCollection<Item>();
            MessagingCenter.Subscribe<AddItemViewModel, Item>(this, "AddItem", (sender, item) =>
            {
                Items.Add(item);
            });
        }
    }
}

