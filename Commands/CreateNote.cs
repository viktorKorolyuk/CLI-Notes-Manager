using Models;
using Database;
using CliUtils;
using System;
using Attributes;

namespace Commands {
  public class CreateNote : ICommand
  {
    [Command("create")]
    [Command("cr")]
    public void Create(string[] command, NoteStorage store)
    {
      var message = "";
      if(command.Length > 1)
      {
        message = command[1].Trim();
      }
      else
      {
        message = Querying.Prompt("Enter message. CTRL + S to save. CTRL + D to discard");
      }
      
      var note = new Note(message);
      store.Add(note);

      Console.WriteLine("Saved.");
    }
  }
}