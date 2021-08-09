using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;
using Database;
using Attributes;

namespace Commands
{
  public abstract class ICommand
  {
    delegate void Delegate_Execute(string[] command, NoteStorage store);
    private Dictionary<string, Delegate_Execute> Commands = new Dictionary<string, Delegate_Execute>();

    protected ICommand()
    {
      // Get all methods within the current class which have the CommandAttribute
      var commandAttributeMethods = this.GetType().GetMethods()
        .Where(attr => attr.GetCustomAttributes<CommandAttribute>()
        .FirstOrDefault() != null);

      // Load the command-method pairs into a hashmap
      foreach (var method in commandAttributeMethods)
      {
        var attrs = method.GetCustomAttributes<CommandAttribute>();
        foreach (var attr in attrs)
        {
          Delegate_Execute fn = (command, store) => { method.Invoke(this, new object[] { command, store }); };
          Commands[attr.Command] = fn; // Save a delegate for a simple API when invoking the original method
        }
      }
    }

    /// <summary>
    /// A sample function on which all other command-accepting functions must follow.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="store"></param>
    private void CommandTemplate(string command, NoteStorage store) { }
    public void Execute(object source, CommandDispatchEvent e)
    {
      // If it matches the command, execute
      if (Commands.ContainsKey(e.Message[0]))
      {
        var command = Commands[e.Message[0]];
        try
        {
          command.Invoke(e.Message, e.Storage);
        }
        catch (TargetParameterCountException error)
        {
          Console.Error.WriteLine($"Error: {error.Message} Printing stack trace:");
          Console.Error.WriteLine(error.StackTrace);
        }
      }
    }
  }
}