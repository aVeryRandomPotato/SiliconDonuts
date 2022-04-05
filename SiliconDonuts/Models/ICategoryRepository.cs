using System;
using System.Collections.Generic;
using System.Linq;

namespace SiliconDonuts.Models
{
    public class ICategoryRepository
    {
        IEnumerable<Category> AllCategories{ get; }
    }
}
