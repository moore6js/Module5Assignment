using Microsoft.Maui;

namespace Module5Assignment;

public partial class Page3 : ContentPage
{
	public Page3()
	{
		InitializeComponent();
	}
    public Page3(string recommendation) : this()
    {
        RecommendationLabel.Text = recommendation;
    }

    private async void Page1(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
    private async void Page2(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    
}