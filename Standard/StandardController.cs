using System;
using Abstractions;

namespace Standard
{
    /// <summary>
    /// «Стандартный» микроконтроллер, работает в привычных единицах (atm, °C).
    /// </summary>
    public class StandardController : IController
    {
        public void Set(double pressureAtm, double tempC)
        {
            Console.WriteLine($"[Standard] P={pressureAtm:0.###} atm, T={tempC:0.#} °C");
        }
    }
}
