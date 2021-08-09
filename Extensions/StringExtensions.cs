using System;

namespace Extensions
{
  public static class StringExtensions
  {
    public static bool IsNumeric(this string str) => Int32.TryParse(str, out _);
  }
}