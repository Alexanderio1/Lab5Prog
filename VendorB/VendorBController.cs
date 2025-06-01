using System;

namespace VendorB
{
    /// <summary>
    /// «Чужой» микроконтроллер Vendor B, который мы не можем менять.
    /// Требует ПАСКАЛИ и ФАРЕНГЕЙТЫ.
    /// </summary>
    public class VendorBController
    {
        /// <summary>
        /// Установка параметров: давление (Па) и температура (°F).
        /// </summary>
        public void SetParameters(double pressurePa, double tempF)
        {
            Console.WriteLine($"[Vendor B] P={pressurePa:N0} Pa, T={tempF:0.#} °F");
        }
    }
}
