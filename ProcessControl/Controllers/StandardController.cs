using ProcessControl.Abstractions;

namespace ProcessControl.Controllers;

/// <summary>«Стандартный» микроконтроллер (atm + °C).</summary>
public class StandardController : IController
{
    public void Set(double pressureAtm, double tempC) =>
        Console.WriteLine($"[Standard] P={pressureAtm:0.###} atm, T={tempC:0.#} °C");
}
