using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SiliconDonuts.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories{ get; }
    }
}
