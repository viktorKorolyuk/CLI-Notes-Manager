namespace Attributes
{
  [System.AttributeUsage(System.AttributeTargets.Method, AllowMultiple = true)]
  public class CommandAttribute : System.Attribute
  {
    public string Command { get; }
    public CommandAttribute(string command)
    {
      Command = command;
    }
  }
}