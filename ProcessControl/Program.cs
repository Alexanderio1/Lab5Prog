using Controller;

namespace Thermometer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var controller = new ProcessControlController();
            controller.Run();
        }
    }
}
