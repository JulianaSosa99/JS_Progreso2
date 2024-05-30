namespace JSAppNotes1.Views;

public partial class JS_AllNotesPage : ContentPage
{
	public JS_AllNotesPage()
	{
		InitializeComponent();
        BindingContext = new Models.JS_AllNotes();
    }
    protected override void OnAppearing()
    {
        ((Models.JS_AllNotes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(JS_NotePage));
    }
    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.JS_Note)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(JS_NotePage)}?{nameof(JS_NotePage.ItemId)}={note.JS_Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }

}