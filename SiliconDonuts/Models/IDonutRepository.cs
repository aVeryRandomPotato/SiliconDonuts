using System;
using System.Collections.Generic;
using System.Linq;

namespace SiliconDonuts.Models
{
    public interface IDonutRepository
    {
        IEnumerable<Donut> AllDonuts { get; }
        IEnumerable<Donut> DonutOfTheDay { get; }

        Donut getDonutById(int num);
    }
}
