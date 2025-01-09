using SaveUp.Views;
using SaveUp.ViewModels;

namespace SaveUp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddItemPage), typeof(AddItemPage));
            Routing.RegisterRoute(nameof(ItemListPage), typeof(ItemListPage));
        }
    }
}
