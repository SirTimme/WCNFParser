using WCNFParser.Clauses;

namespace WNCFParser;

public class Program
{
   /// <summary>
   /// Main entry point of the program
   /// </summary>
   /// <param name="args">Additional arguments</param>
   public static void Main(string[] args)
   {
      var clauses = new List<BaseClause>();

      // first cmd line arg is filepath
      var lines = File.ReadLines(args[0]);

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

      OutputClausesToConsole(clauses);
   }

   /// <summary>
   /// Outputs the passed clauses to console
   /// </summary>
   /// <param name="clauses">The clauses to be output</param>
   private static void OutputClausesToConsole(List<BaseClause> clauses)
   {
      foreach (var clause in clauses)
      {
         Console.WriteLine(clause.ToString());
      }
   }
}