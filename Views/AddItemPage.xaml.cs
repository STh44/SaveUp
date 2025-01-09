using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveUp.ViewModels;



namespace SaveUp.Views
{
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();
            BindingContext = new AddItemViewModel();
        }
    }
}
