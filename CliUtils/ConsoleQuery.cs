using System.Collections.Generic;
using Extensions;
using System;

namespace CliUtils
{
  /// <summary>
  /// This class contains reusable methods and helpers to assist in requesting
  /// information from the user within the CLI. 
  /// </summary>
  public static class Querying
  {
    /// <summary>
    /// Prompt the user for a input.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="newline"></param>
    /// <returns></returns>
    public static string Prompt(string query, bool newline = true)
    {
      if (newline)
        Console.WriteLine(query);
      else Console.Write(query);
      return Console.ReadLine();
    }

    /// <summary>
    /// Prompts the user for a number. If an invalid or empty number is given, the prompt is asked again
    /// until an exit signal is detected.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public static int Prompt_Number(string query)
    {
      var message = "";
      while (true)
      {
        message = Querying.Prompt(query, false);
        if (!message.IsNumeric())
          Console.WriteLine(Constants.Errors.ERR_INVALID_NUMBER);
        else
          break;
      }

      return Int32.Parse(message);
    }

    /// <summary>
    /// Print a non-interactible menu for the user.
    /// Use case: When you want a menu printed and are handling input elsewhere.
    /// </summary>
    /// <param name="options"></param>
    public static void Prompt_Menu(IEnumerable<MenuOption> options)
    {
      foreach (var option in options)
      {
        Console.WriteLine($"{option.Key})\t{option.Name}");
      }
      Console.WriteLine();
    }

    /// <summary>
    /// Similar to `Prompt_Menu(IEnumerable<MenuOption> options)`.
    /// This will prompt the user for input. No validation is done on the input.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    public static string Prompt_Menu(IEnumerable<MenuOption> options, string query)
    {
      foreach (var option in options)
      {
        Console.WriteLine($"{option.Key})\t{option.Name}");
      }
      Console.WriteLine();
      return Prompt(query, false);
    }
  }

  public struct MenuOption
  {
    public string Key;
    public string Name;
    public string Description;
  }
}