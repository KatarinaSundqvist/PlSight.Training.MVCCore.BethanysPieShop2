using System.Collections.Generic;

namespace BethanysPieShop2.Models {
    public interface ICategoryRepository {
        IEnumerable<Category> AllCategories { get; }
    }
}
