using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SaveUp.Models;
using System.Windows.Input;

namespace SaveUp.ViewModels
{
    public class AddItemViewModel : BaseViewModel
    {
        private string name;
        private string description;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public ICommand SaveCommand { get; }

        public AddItemViewModel()
        {
            SaveCommand = new Command(OnSave);
        }

        private async void OnSave()
        {
            var newItem = new Item { Name = Name, Description = Description };
            MessagingCenter.Send(this, "AddItem", newItem);
            await Shell.Current.GoToAsync("..");
        }
    }
}

