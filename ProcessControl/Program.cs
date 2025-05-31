using ProcessControl.Abstractions;
using ProcessControl.Adapters;
using ProcessControl.Controllers;
using ProcessControl.Utils;

namespace ProcessControl;

class Program
{
    static void Main()
    {
        double atm = Input.ReadDouble("Давление (atm): ", v => v >= 0);
        double c = Input.ReadDouble("Температура (°C): ");

        Console.WriteLine("\n=== Стандартный контроллер ===");
        IController standard = new StandardController();
        standard.Set(atm, c);

        Console.WriteLine("\n=== Контроллер Vendor B через адаптер ===");
        IController vendorB = new VendorBAdapter();
        vendorB.Set(atm, c);
    }
}
