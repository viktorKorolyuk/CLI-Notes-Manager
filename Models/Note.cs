using System;
namespace Models
{
  public class Note
  {
    public DateTime Timestamp { get; set; }
    public string Message { get; private set; }
    public Note(string message)
    {
      Timestamp = DateTime.Now;
      Message = message;
    }

    public void setMessage(string message)
    {
      Message = message;        // Update the message
      Timestamp = DateTime.Now; // Update the modification time
    }
  }
}