namespace ProcessControl.Abstractions;

/// <summary>Контракт, к которому «привязан» диспетчер.</summary>
public interface IController
{
    void Set(double pressureAtm, double tempC);
}
