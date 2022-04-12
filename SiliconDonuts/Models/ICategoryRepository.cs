using System;
using System.Collections.Generic;
using System.Linq;

namespace SiliconDonuts.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories{ get; }
    }
}
