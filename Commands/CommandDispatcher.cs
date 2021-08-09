using System;
using Database;
using NoteTaker;

namespace Commands
{
  public class CommandDispatcher
  {
    public EventHandler<CommandDispatchEvent> eventHandler;
    private NoteStorage Storage;
    private Startup StartupService;
    public CommandDispatcher(NoteStorage storage)
    {
      Storage = storage;
      StartupService = new Startup();
    }

    public void Start()
    {
      StartupService.Setup(this);
    }

    public void AddHandler(params ICommand[] handlers)
    {
      foreach (var handler in handlers)
        eventHandler += handler.Execute;
    }

    public void Dispatch(string command)
    {
      // According to https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-publish-events-that-conform-to-net-framework-guidelines#example
      // This creates a copy of the eventHandler to avoid race conditions if the last subscriber unsubscribes.
      var raiseEvent = eventHandler;

      if (raiseEvent != null)
      {
        var message = command.Split(" ");
        var args = new CommandDispatchEvent { Message = command.Split(" "), Storage = Storage };
        raiseEvent(this, args);
      }
    }
  }

  public class CommandDispatchEvent : EventArgs
  {
    public string[] Message;
    public NoteStorage Storage;
  }
}