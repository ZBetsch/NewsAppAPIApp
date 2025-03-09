using NewsAppAPIApp.Services;
using NewsAppAPIApp.Models;
namespace NewsAppAPIApp.Pages;

public partial class NewsHomepage : ContentPage
{
	public List<Article> ArticleList;
    public List<Category> CategoryList = new List<Category>()
    {
        new Category(){Name = "World", ImageUrl = "world.png"},
        new Category(){Name = "Nation" , ImageUrl="nation.png"},
        new Category(){Name = "Business" , ImageUrl="business.png"},
        new Category(){Name = "Technology" , ImageUrl="technology.png"},
        new Category(){Name = "Entertainment", ImageUrl = "entertainment.png"},
        new Category(){Name = "Sports" , ImageUrl="sports.png"},
        new Category(){Name = "Science", ImageUrl= "science.png"},
        new Category(){Name = "Health", ImageUrl="health.png"},
    };
    public NewsHomepage()
	{
		InitializeComponent();
		GetBreakingNews();
		ArticleList = new List<Article>();
        CvCategories.ItemsSource = CategoryList;
    }
    private async Task GetBreakingNews()
	{
		var apiService = new APIService();
		var newsResult = await apiService.GetNews("general");
		foreach (var item in newsResult.Articles) 
		{
			ArticleList.Add(item);		
		}
		CvNews.ItemsSource = ArticleList;
	}

    private void CvNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Contact;
        if (selectedItem == null) return;
        Navigation.PushAsync(new NewsDetailPage());
        ((CollectionView)sender).SelectedItem = null;
    }

    //private void ColContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    var selectedItem = e.CurrentSelection.FirstOrDefault() as Contact;
    //    if (selectedItem == null) return;
    //    Navigation.PushAsync(new ContactDescription(selectedItem));
    //    ((CollectionView)sender).SelectedItem = null;
    //}
}