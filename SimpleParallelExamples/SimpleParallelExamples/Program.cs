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
        List<string> fruits = new List<string>();
        fruits.Add("Apple");
        fruits.Add("Banana");
        fruits.Add("Bilberry");
        fruits.Add("Blackberry");
        fruits.Add("Blackcurrant");
        fruits.Add("Blueberry");
        fruits.Add("Cherry");
        fruits.Add("Coconut");
        fruits.Add("Cranberry");
        fruits.Add("Date");
        fruits.Add("Fig");
        fruits.Add("Grape");
        fruits.Add("Guava");
        fruits.Add("Jack-fruit");
        fruits.Add("Kiwi fruit");
        fruits.Add("Lemon");
        fruits.Add("Lime");
        fruits.Add("Lychee");
        fruits.Add("Mango");
        fruits.Add("Melon");
        fruits.Add("Olive");
        fruits.Add("Orange");
        fruits.Add("Papaya");
        fruits.Add("Plum");
        fruits.Add("Pineapple");
        fruits.Add("Pomegranate");


        Console.WriteLine("Printing list using Parallel.ForEach");


        var stopWatch = Stopwatch.StartNew();

        Parallel.ForEach(fruits, fruit =>
            {
            Console.WriteLine("Fruit Name: {0}, Thread Id= {1}", fruit, Thread.CurrentThread.ManagedThreadId);

            }
        );
        Console.WriteLine("Parallel.ForEach() execution time = {0} seconds", stopWatch.Elapsed.TotalSeconds);

         stopWatch = Stopwatch.StartNew();
        fruits.AsParallel().ForAll(x => Console.WriteLine($"Fruit Name: {x}, Thread Id= {Thread.CurrentThread.ManagedThreadId}"));

        Console.WriteLine("fruits.AsParallel().ForAll execution time = {0} seconds", stopWatch.Elapsed.TotalSeconds);

        Console.WriteLine("Printing list using foreach loop\n");
        stopWatch = Stopwatch.StartNew();

        foreach (string fruit in fruits)
          {
          Console.WriteLine("Fruit Name: {0}, Thread Id= {1}", fruit, Thread.CurrentThread.ManagedThreadId);
          }
        Console.WriteLine("foreach loop execution time = {0} seconds\n", stopWatch.Elapsed.TotalSeconds);
        Console.Read();
      }

      public static void RunParallelThatIsFaster()
      {
        var stopWatch = Stopwatch.StartNew();
        PointF firstLocation = new PointF(10, 10);
        PointF secondLocation = new PointF(10, 50 );
        foreach (string file in Directory.GetFiles(@"c:\temp\Images"))
          {
          Bitmap bitmap = (Bitmap) System.Drawing.Image.FromFile(file);
          using (Graphics graphics = Graphics.FromImage(bitmap))
            {
            using (Font arialFont = new Font("Arial", 10))
              {
              graphics.DrawString("Hello", arialFont, Brushes.Blue, firstLocation);
              graphics.DrawString("World", arialFont, Brushes.Red, secondLocation);
              }
            }
          bitmap.Save(Path.GetDirectoryName(file) + "\\Foreachloop" + "\\" + Path.GetFileNameWithoutExtension(file) + Guid.NewGuid()
                        .ToString() + ".jpg");
          }
        Console.WriteLine("foreach loop execution time = {0} seconds\n", stopWatch.Elapsed.TotalSeconds);

         stopWatch = Stopwatch.StartNew();
      
        Parallel.ForEach(Directory.GetFiles(@"C:\temp\Images"), file =>
          {
          Bitmap bitmap = (Bitmap)Image.FromFile(file);
          using (Graphics graphics = Graphics.FromImage(bitmap))
            {
            using (Font arialFont = new Font("Arial", 10))
              {
              graphics.DrawString("Hello", arialFont, Brushes.Blue, firstLocation);
              graphics.DrawString("World", arialFont, Brushes.Red, secondLocation);
              }
            }
          bitmap.Save(Path.GetDirectoryName(file) + "\\Parallel" + "\\" + Path.GetFileNameWithoutExtension(file) + Guid.NewGuid()
                        .ToString() + ".jpg");
          });
        Console.WriteLine("Parallel.ForEach() execution time = {0} seconds", stopWatch.Elapsed.TotalSeconds);
        Console.Read();
      }
    }
  }
}
