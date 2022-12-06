namespace WCNFParser.Clauses;

public class HardClause : BaseClause
{
   public HardClause() { }

   public HardClause(int[] ints)
   {
      Ints = ints;
   }

   public override string ToString()
   {
      return $"h {base.ToString()}";
   }
}
