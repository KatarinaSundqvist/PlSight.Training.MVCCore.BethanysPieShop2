using BethanysPieShop2.Models;
using System.Collections.Generic;

namespace BethanysPieShop2.ViewModels {
    public class PiesListViewModel {
        public IEnumerable<Pie> Pies { get; set; }
        public string CurrentCategory { get; set; }
    }
}
