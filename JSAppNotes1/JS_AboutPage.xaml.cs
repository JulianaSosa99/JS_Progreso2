

namespace JSAppNotes1;

public partial class JS_AboutPage : ContentPage
{
	public JS_AboutPage()
	{
		InitializeComponent();
	}

 
    private async Task LearnMore_ClickedAsync(object sender, EventArgs e)
    {

        await Launcher.Default.OpenAsync("https://educacionvirtual.udla.edu.ec/");
    }
}