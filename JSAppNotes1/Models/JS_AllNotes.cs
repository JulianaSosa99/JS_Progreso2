using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Provider.ContactsContract.CommonDataKinds;

namespace JSAppNotes1.Models;

internal class JS_AllNotes
{
    public ObservableCollection<JS_Note> Notes{ get; set; } = new ObservableCollection<JS_Note>();

    public JS_AllNotes() =>
        LoadNotes();

    public void LoadNotes()
    {
        Notes.Clear();

        // Get the folder where the notes are stored.
        string appDataPath = FileSystem.AppDataDirectory;

        // Use Linq extensions to load the *.notes.txt files.
        IEnumerable<JS_Note> notes = Directory

                                    // Select the file names from the directory
                                    .EnumerateFiles(appDataPath, "*.notes.txt")

                                    // Each file name is used to create a new Note
                                    .Select(filename => new JS_Note()
                                    {
                                        JS_Filename = filename,
                                        JS_Text = File.ReadAllText(filename),
                                        Date = File.GetLastWriteTime(filename)
                                    })

                                    // With the final collection of notes, order them by date
                                    .OrderBy(note => note.Date);

        // Add each note into the ObservableCollection
        foreach (JS_Note note in notes)
            Notes.Add(note);
    }
    }