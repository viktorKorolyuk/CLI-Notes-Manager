using Commands;
using CliUtils;
using System;

namespace NoteTaker
{
  public class Startup
  {
    static readonly MenuOption[] Options = {
            new MenuOption{
              Key="create",
              Name="Create a note",
            },
            new MenuOption{
              Key="list",
              Name="List all notes"
            },
            new MenuOption{
              Key="read",
              Name="Read a note"
            },
            new MenuOption{
              Key="update",
              Name="Update a note"
            },
            new MenuOption{
              Key="delete",
              Name="Delete a note"
            },
            new MenuOption{
              Key="help",
              Name="Print this menu"
            },
            new MenuOption{
              Key="quit",
              Name="Exit the application"
            }
          };

    public void Setup(CommandDispatcher dispatcher)
    {
      dispatcher.eventHandler += new CreateNote().Execute;
      dispatcher.eventHandler += new UpdateNote().Execute;
      dispatcher.eventHandler += new ReadNotes().Execute;
      dispatcher.eventHandler += new DeleteNote().Execute;
      dispatcher.eventHandler += new HelpCommand(Options).Execute;

      Console.WriteLine("C# CLI Notes");
      HelpCommand.PrintCommands(Options);
      while (true)
      {
        var result = Querying.Prompt("Prompt > ", false);
        if(result.Equals("quit")){
          Console.WriteLine("Exiting.");
          return; // Exit to Program.cs for a graceful shutdown
        }
        dispatcher.Dispatch(result);
      }
    }
  }
}