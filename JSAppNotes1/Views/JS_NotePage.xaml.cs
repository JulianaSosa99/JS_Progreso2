
namespace JSAppNotes1.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class JS_NotePage : ContentPage
{
   string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
    public JS_NotePage()
	{
		InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
// MIRAR SI ES QUE HAY QUE BORRAR

       // if (File.Exists(_fileName))
         
        //TextEditor.Text = File.ReadAllText(_fileName);
        
    }
    
     
    private void LoadNote(string fileName)
    {
        Models.JS_Note noteModel = new Models.JS_Note();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.JSText = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
    public string ItemId
    {
        set { LoadNote(value); }
    }

     

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.JS_Note note)
            File.WriteAllText(note.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.JS_Note note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }
}