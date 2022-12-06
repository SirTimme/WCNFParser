using WCNFParser.Clauses;

namespace WNCFParser;

public class Program
{
   public static void Main(string[] args)
   {
      var clauses = new List<BaseClause>();
      var lines = File.ReadLines("C:\\Users\\timpi\\Downloads\\log.8.wcsp.log.wcnf");

      foreach (var line in lines)
      {
         if (line.StartsWith("c"))
         {
            continue;
         }
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

            clauses.Add(new SoftClause(numbers));
         }
      }

      OutputClausesToFile(clauses);
   }

   private static void OutputClausesToFile(List<BaseClause> clauses)
   {
      File.WriteAllLines("C:\\Users\\timpi\\Downloads\\test2.wncf", clauses.Select(clause => clause.ToString()));
   }
}
