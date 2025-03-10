using NewsAppAPIApp.Models;

namespace NewsAppAPIApp.Pages;

public partial class NewsDetailPage : ContentPage
{
    private Article _article;

    public NewsDetailPage(Article article)
	{
		InitializeComponent();
        _article = article;

        lblTitle.Text = _article.Title;
        imgArticleImg.Source = ImageSource.FromUri(new Uri(_article.Image));
        lblArticleText.Text = _article.Content;
        lblUrl.Text = _article.Url;
	}

    private void OpenUrl(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(_article.Url))
        {
            Launcher.OpenAsync(new Uri(_article.Url));
        }
    }
}