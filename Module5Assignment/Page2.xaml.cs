namespace Module5Assignment;

public partial class Page2 : ContentPage
{
	string recommendation = string.Empty;
    public Page2()
	{
		InitializeComponent();
	}

	public Page2(double bmi, string category, string recommendations) : this()
	{
		BmiLabel.Text = $"Your BMI is: {bmi:F1} {category}";
        CategoryLabel.Text = $"This means that you are {category}.";
        recommendation = recommendations;
    }
    private async void OnBackToPage1Clicked(object sender, EventArgs e)
	{
		await Navigation.PopToRootAsync();
    }
    private async void OnGoToPage3Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Page3(recommendation));

    }
}