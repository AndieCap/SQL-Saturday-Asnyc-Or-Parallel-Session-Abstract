using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleParallelExamples
{
  class Program
  {
    static void Main(string[] args)
    {
      ParallelIsNotAlwaysBetter.RunParallelThatIsSlower();
    }

    public static class ParallelIsNotAlwaysBetter
    {
      public static void RunParallelThatIsSlower()
      {
        
        Console.Read();
      }

      public static void RunParallelThatIsFaster()
      {
       
        Console.Read();
      }
    }
  }
}
