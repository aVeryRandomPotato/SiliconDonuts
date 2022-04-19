using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SiliconDonuts.Models
{
    public class DonutRepository : IDonutRepository
    {
        private readonly ApplicationDbContext _db;

        public DonutRepository(ApplicationDbContext db)
        {
            _db = db;

        }
        public IEnumerable<Donut> AllDonuts
        {
            get
            {
                return _db.Donuts.Include(c => c.Category);
            }
        }
        public IEnumerable<Donut> DonutOfTheDay
        {
            get
            {
                return _db.Donuts.Include(c => c.Category).Where(d => d.DonutOfTheDay);
            }
        }
        public Donut getDonutById(int donutId)
        {
            return _db.Donuts.FirstOrDefault(d => d.DonutId == donutId);
        }

    }
}
