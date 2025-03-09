using NewsAppAPIApp.Pages;

namespace NewsAppAPIApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new NewsHomepage());
        }
    }
}
