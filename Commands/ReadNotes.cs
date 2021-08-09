using System;
using Database;
using Models;
using Extensions;
using CliUtils;
using Attributes;

namespace Commands
{
  public class ReadNotes : ICommand
  {
    /// <summary>
    /// List all the stored notes within the database.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="store"></param>
    [Command("list")]
    [Command("ls")]
    public void ListAllNotes(string[] command, NoteStorage store)
    {
      var notes = store.GetNotes();
      for (int i = 0; i < notes.Count; i++)
      {
        PrintNote(notes[i], i);
      }
    }

    /// <summary>
    /// List a note given an integer ID
    /// </summary>
    /// <param name="command"></param>
    /// <param name="store"></param>
    [Command("read")]
    [Command("rd")]
    public void ListNote(string[] command, NoteStorage store)
    {
      int id;

      if (command.Length > 1 && command[1].IsNumeric()) // If the argument is available and if it is a number
        id = Int32.Parse(command[1]);
      else
        id = Querying.Prompt_Number("Enter note ID: ");

      Note note;

      try
      {
        note = store.Read(id);
      }
      catch (ArgumentOutOfRangeException)
      {
        Console.WriteLine(Constants.Errors.ERR_OUT_OF_RANGE);
        return;
      }

      PrintNote(note, id);
    }

    private static void PrintNote(Note note) => Console.WriteLine($"{note.Message} -- {note.Timestamp}");
    public static void PrintNote(Note note, int id) => Console.WriteLine($"{id}) {note.Message} -- {note.Timestamp}");
  }
}