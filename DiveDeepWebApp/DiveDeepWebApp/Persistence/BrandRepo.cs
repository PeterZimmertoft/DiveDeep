using DiveDeepWebApp.Models;

namespace DiveDeepWebApp.Persistence
{
    public class BrandRepo
    {
        private List<Brand> brands = new List<Brand>();

        public BrandRepo()
        {
            brands.Add(new Brand { Name = "Scubapro", Description = "Scubapro er et ikonisk dykkerbrand kendt for innovativt, pålideligt og holdbart udstyr til både hobby- og pro-dykkere." });
            brands.Add(new Brand { Name = "Seac", Description = "Seac er et italiensk dykkerbrand kendt for design, innovation og pålideligt udstyr til dykning, snorkling og UV‑jagt." });
            brands.Add(new Brand { Name = "Waterproof", Description = "Waterproof er et svensk dykkerbrand kendt for premium kvalitet, avanceret design og robuste dragter, skabt til krævende dyk under kolde forhold." });
            brands.Add(new Brand { Name = "Fourth Element", Description = "Fourth Element er et britisk dykkerbrand kendt for bæredygtige materialer, høj komfort og teknisk avanceret udstyr til både koldtvands- og varmvandsdykning." });
            brands.Add(new Brand { Name = "Santi", Description = "Santi er et polsk dykkerbrand kendt for højkvalitets tørdragter, avanceret termisk beskyttelse og teknisk udstyr til krævende dyk under alle forhold." });
            brands.Add(new Brand { Name = "Tusa", Description = "Tusa er et japansk dykkerbrand kendt for komfort, kvalitet og brugervenligt design i masker, finner og snorkeludstyr." });
        }
    }
}
