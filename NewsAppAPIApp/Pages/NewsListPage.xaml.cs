using NewsAppAPIApp.Services;
using NewsAppAPIApp.Models;
namespace NewsAppAPIApp.Pages;

public partial class NewsListPage : ContentPage
{
    public List<Article> ArticleList;
    private Category _category;
	public NewsListPage(Category item)
	{
		InitializeComponent();
        _category = item;
        Title = _category.Name;
        lblCategoryName.Text = _category.Name + " News";
        ArticleList = new List<Article>();
        GetBreakingNews();
    }

    private async Task GetBreakingNews()
    {
        var apiService = new APIService();
        var newsResult = await apiService.GetNews(_category.Name);
        foreach (var item in newsResult.Articles)
        {
            ArticleList.Add(item);
        }
        CvCategoryNews.ItemsSource = ArticleList;
    }

    private void CvCategoryNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Article;
        if (selectedItem == null) return;
        Navigation.PushAsync(new NewsDetailPage(selectedItem));
        ((CollectionView)sender).SelectedItem = null;
    }
}