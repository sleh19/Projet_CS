namespace projet.Models
{
    public class Repository
    {
        private static List<Achat> achats = new List<Achat>();
        public static IEnumerable<Achat> GetAchats()
        {
            return achats;
        }
        public static void AddAchat(Achat achat)
        {
            achats.Add(achat);
        }
    }
}
