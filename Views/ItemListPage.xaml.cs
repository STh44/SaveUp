using SaveUp.ViewModels;

namespace SaveUp.Views
{
    public partial class ItemListPage : ContentPage
    {
        public ItemListPage()
        {
            InitializeComponent();
            BindingContext = new ItemListViewModel();
        }
    }
}

