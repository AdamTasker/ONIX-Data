using System;
using System.Collections.Generic;
using System.Text;

namespace OnixData
{
  public class SerializationHelper
  {
    public static T[] CreateEnumArray<T>(T shortEnum, T longEnum, int count) where T : Enum
    {
      T choice = SerializationSettings.UseShortTags ? shortEnum : longEnum;
      T[] result = new T[count];
      for (int i = 0; i < count; i++) result[i] = choice;
      return result;
    }
  }
}
