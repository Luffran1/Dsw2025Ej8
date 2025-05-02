using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8.Domain;

internal class CuentaCorriente : CuentaBancaria
{

    public decimal _comision { get; set; }
    public decimal _limiteDeDescubierto { get; set; }



    public CuentaCorriente(string numero, decimal saldo, string[] titulares, Estado estado, decimal comision) : base(numero, saldo, titulares)
    {
        _comision = comision;

    }
    public override void Depositar(decimal monto)
    {
        if (monto <= 0)
            throw new MontoNoValido();
        if (_estado != Estado.Activa)
            throw new CuentaNoActiva(_estado);
        monto -= monto * _comision;
        _saldo += monto;
    }
    public override void Retirar(decimal monto)
    {
        if (monto <= 0)
            throw new MontoNoValido();
        if (_estado != Estado.Activa)
            throw new CuentaNoActiva(_estado);

        if (_saldo - monto >= -_limiteDeDescubierto)
        {
            _saldo -= monto;
        }
        else
        {
            _estado = Estado.Suspendida;
            throw new SaldoInsuficiente();
        }
        if (_saldo < monto)
        {
            _estado = Estado.Suspendida;
        }

    }

}
