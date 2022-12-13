namespace WCNFParser.Clauses;

public class SoftClause : BaseClause
{
   public SoftClause() { }

   public SoftClause(int weight, int[] ints)
   {
      Weight = weight;
      Ints = ints;
   }

   public int Weight { get; set; }

   public override string ToString()
   {
      return $"{Weight} {base.ToString()}";
   }
}
