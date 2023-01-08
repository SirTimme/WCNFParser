using WCNFParser.Clauses;

namespace WNCFParser;

public class Program
{
   /// <summary>
   /// Main entry point of the program
   /// </summary>
   /// <param name="args">Additional arguments</param>
   public static int Main(string[] args)
   {
      var clauses = new List<BaseClause>();
      var lines = File.ReadLines(args[0]);

      try
      {
         foreach (var line in lines)
         {
            // ignore comments
            if (line.StartsWith("c"))
            {
               continue;
            }
            // hard clauses
            else if (line.StartsWith("h"))
            {
               var numbers = line
                  .Split(' ')
                  .SkipWhile(entry => entry == string.Empty || entry == "h")
                  .Select(int.Parse)
                  .ToArray();

               clauses.Add(new HardClause(numbers));
            }
            // weightened clauses
            else
            {
               var numbers = line
                  .Split(' ')
                  .SkipWhile(entry => entry == string.Empty)
                  .Select(int.Parse)
                  .ToArray();

               clauses.Add(new SoftClause(numbers[0], numbers.Skip(1).ToArray()));
            }
         }
      } 
      catch
      {
         return 1;
      }

      // OutputClausesToConsole(clauses);

      return 0;
   }

   /// <summary>
   /// Outputs the passed clauses to console
   /// </summary>
   /// <param name="clauses">The clauses to be output</param>
   private static void OutputClausesToConsole(List<BaseClause> clauses)
   {
      clauses.ForEach(clause => Console.WriteLine(clause.ToString()));
   }
}