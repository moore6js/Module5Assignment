namespace Module5Assignment
{
    public partial class MainPage : ContentPage
    {
        string GenderSelector = string.Empty;
        
        public MainPage()
        {
            InitializeComponent();
            WeightLabel.Text = $"{Math.Round(WeightSlider.Value)} lbs";
            HeightLabel.Text = $"{Math.Round(HeightSlider.Value)} in";
        }

        private void Weight_Changed(object sender, ValueChangedEventArgs e)
        {
            WeightLabel.Text = $"{Math.Round(e.NewValue)} lbs";
        }

        private void Height_Changed(object sender, ValueChangedEventArgs e)
        {
            HeightLabel.Text = $"{Math.Round(e.NewValue)} in";
        }
        void OnTappedMan(object sender, TappedEventArgs args)
        {
            GenderSelector = "Man";
            WomanBorder.Stroke = Brush.Transparent;
            ManBorder.Stroke = Brush.LightGray;

        }
        void OnTappedWoman(object sender, TappedEventArgs args)
        {
            GenderSelector = "Woman";
            WomanBorder.Stroke = Brush.LightGray;
            ManBorder.Stroke = Brush.Transparent;
        }

        private async void Calculate_Clicked(object sender, EventArgs e)
        {
            double weight = WeightSlider.Value;
            double height = HeightSlider.Value;

            if (height == 0 || weight == 0 || string.IsNullOrEmpty(GenderSelector))
            {
                await DisplayAlertAsync("Invalid input", "Please set weight, height and select a gender.", "OK");
                return;
            }

            double bmi = Math.Round((weight * 703) / (height * height), 1);

            string category = string.Empty;
            string recommendations = string.Empty;
            string msg = string.Empty;

            if (GenderSelector == "Man")
            {
                switch (bmi)
                {
                    case < 18.5:
                        category = "Underweight";
                        recommendations = "Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains). Incorporate strength training to build muscle mass. Consult a nutritionist if needed.";
                        break;
                    case < 25:
                        category = "Normal weight";
                        recommendations = "Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health";
                        break;
                    case < 30:
                        category = "Overweight";
                        recommendations = "Reduce processed foods and focus on portion control. Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training. Drink plenty of water and track your progres.";
                        break;
                    default:
                        category = "Obese";
                        recommendations = "Consult a doctor for personalized guidance. Start with low-impact exercises (e.g., walking, cycling). Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. Avoid sugary drinks and maintain a consistent sleep schedule.";
                        break;
                }

                msg = $"Gender: {GenderSelector}.\nBMI: {bmi}.\nHealth Status: {category}.\nRecommendations: {recommendations}";
            }
            else if (GenderSelector == "Woman")
            {
                switch (bmi)
                {
                    case < 18:
                        category = "Underweight";
                        recommendations = "Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains). Incorporate strength training to build muscle mass. Consult a nutritionist if needed.";
                        break;
                    case < 24:
                        category = "Normal weight";
                        recommendations = "Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health";
                        break;
                    case < 29:
                        category = "Overweight";
                        recommendations = "Reduce processed foods and focus on portion control. Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training. Drink plenty of water and track your progres.";
                        break;
                    default:
                        category = "Obese";
                        recommendations = "Consult a doctor for personalized guidance. Start with low-impact exercises (e.g., walking, cycling). Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. Avoid sugary drinks and maintain a consistent sleep schedule.";
                        break;
                }

                msg = $"Gender: {GenderSelector}.\nBMI: {bmi}.\nHealth Status: {category}.\nRecommendations: {recommendations}";
            }


            await Navigation.PushAsync(new Page2(bmi,category, recommendations));
        }
    }
}
