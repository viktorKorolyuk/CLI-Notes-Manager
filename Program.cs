using System;
using Commands;
using CliUtils;

namespace NoteTaker
{
  class Program
  {
    static void Main(string[] args)
    {
      using (var store = new Database.NoteStorage())
      {
        var commandDistpatcher = new CommandDispatcher(store);
        commandDistpatcher.Start();
      }
    }
  }
}
