using Microsoft.Maui.Controls;
using SaveUp.Views;

namespace SaveUp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnItemListPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemListPage());
        }

        private async void OnAddItemPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage());
        }
    }
}
