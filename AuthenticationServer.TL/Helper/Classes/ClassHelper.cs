using System;

namespace AuthenticationServer.TL.Helper.Classes
{
   public static class ClassHelper
   {
      public static bool CheckValidDate(DateTime dateTime)
      {
         return DateTime.Now.CompareTo(dateTime) == -1;
      }
   }
}
