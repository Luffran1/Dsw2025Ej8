namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    public string _numero { get; }
    public decimal _saldo { get; protected set; }
    public Estado _estado { get; set; }
    public string[] _titulares { get; }

    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _estado = Estado.Activa;
        _titulares = titulares;
    }
    public virtual void Depositar(decimal monto)
    {
    }
    public virtual void Retirar(decimal monto)
    {
    }
    public virtual void AplicarInteres()
    {
    }
}
