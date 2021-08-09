using System.Collections.Generic;
using Attributes;
using System;
using CliUtils;
using Database;

namespace Commands
{
  public class HelpCommand : ICommand
  {
    private IEnumerable<MenuOption> Options;
    public HelpCommand(IEnumerable<MenuOption> Options)
    {
      this.Options = Options;
    }

    [Command("help")]
    public void Help(string message, NoteStorage storage)
    {
      PrintCommands(this.Options);
    }

    public static void PrintCommands(IEnumerable<MenuOption> options)
    {
      Console.WriteLine("Options:");
      CliUtils.Querying.Prompt_Menu(options);
    }
  }
}