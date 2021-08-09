using System;
using Models;
using Database;
using Extensions;
using CliUtils;
using Attributes;

namespace Commands
{
  public class UpdateNote : ICommand
  {
    [Command("update")]
    [Command("up")]
    public void Update(string[] command, NoteStorage store)
    {
      Console.WriteLine("Editing a note.");

      int id;

      if (command.Length > 1 && command[1].IsNumeric())
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
        return; // Exit early
      }

      Console.Write(note.Message);                                        // Write the last message
      Console.SetCursorPosition(0, Console.GetCursorPosition().Top);      // Reset the cursor to the first column
      Console.SetCursorPosition(0, Console.GetCursorPosition().Top - 1);  // Move back one row to print the instructions
      var message = Querying.Prompt("Enter message. CTRL + S to save. CTRL + D to discard");

      note.setMessage(message); // Update the message
      Console.WriteLine("Saved.");
    }
  }
}