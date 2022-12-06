namespace WCNFParser.Clauses;

public class BaseClause
{
   public int[] Ints { get; set; }

   public override string ToString()
   {
      return string.Join(' ', Ints);
   }
}
