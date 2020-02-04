using BethanysPieShop2.Models;
using System.Collections.Generic;

namespace BethanysPieShop2.ViewModels {
    public class HomeViewModel {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }
    }
}
