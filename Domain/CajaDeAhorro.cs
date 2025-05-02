using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8.Domain
{
    internal class CajaDeAhorro : CuentaBancaria
    {

        public decimal _tasaDeInteres { get; init; }

        public CajaDeAhorro(string numero, decimal saldo, string[] titulares, Estado estado) : base(numero, saldo, titulares)
        {
        }
        public override void Depositar(decimal monto)
        {
            if (monto <= 0)
                throw new MontoNoValido();

            if (_estado != Estado.Activa)
                throw new CuentaNoActiva(_estado);
            _saldo += monto;
        }
        public override void Retirar(decimal monto)
        {
            if (monto <= 0)
                throw new MontoNoValido();

            if (_estado != Estado.Activa)
                throw new CuentaNoActiva(_estado);

            if (_saldo < monto)
            {
                _estado = Estado.Suspendida;
                throw new SaldoInsuficiente();
            }
            _saldo -= monto;
        }
        public override void AplicarInteres()
        {
            _saldo += _saldo * _tasaDeInteres;
        }
    }
}
