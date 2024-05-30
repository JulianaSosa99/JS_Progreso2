


namespace JSAppNotes1.Views;

public partial class JS_AboutPage : ContentPage
{
	public JS_AboutPage()
	{
		InitializeComponent();
	}




    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.JS_About about)
        {
            // Navigate to the specified URL in the system browser.
            await Launcher.Default.OpenAsync(about.MoreInfoUrl);

        }
    }
}