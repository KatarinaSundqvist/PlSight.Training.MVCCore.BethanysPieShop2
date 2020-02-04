using System.Collections.Generic;

namespace BethanysPieShop2.Models {
    public interface IPieRepository {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie GetPieById(int pieId);

    }
}
