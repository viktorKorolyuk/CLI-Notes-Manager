using System;
using CliUtils;
using Extensions;
using Models;
using Database;
using Attributes;

namespace Commands
{
  public class DeleteNote : ICommand
  {

    [Command("delete")]
    [Command("del")]
    public void Delete(string[] command, NoteStorage store)
    {
      int id;
      if (command.Length > 1 && command[1].IsNumeric())
        id = Int32.Parse(command[1]);
      else
        id = Querying.Prompt_Number("Enter note id: ");

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

      ReadNotes.PrintNote(note, id);
      Console.Write("\n"); // Blank line

      var message = Querying.Prompt("Are you sure you would like to delete this note (yes/n)?");
      if (message.Equals("yes"))
      {
        store.Delete(id);
        Console.WriteLine($"Successfully deleted note {id}. Subsequent notes have been re-indexed.");
      }
      else
      {
        Console.WriteLine("Operation cancelled.");
      }

    }
  }
}