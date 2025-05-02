using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;
using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8
{
    internal class Implementacion
    {
        public static void Contenido()
        {

            var cuentas = new List<CuentaBancaria>
            {
                new CajaDeAhorro("123456", 1000, new string[] { "Juan", "Maria" }, Estado.Activa)
                {
                    _tasaDeInteres = 0.05m
                },
                new CajaDeAhorro("789012",0, new string[] { "Luis", "Ana" }, Estado.Activa)
                {
                    _tasaDeInteres = 0.03m
                },
                new CuentaCorriente("654321", 500, new string[] { "Pedro", "Ana" }, Estado.Activa, 0.02m)
                {
                    _limiteDeDescubierto = 200
                },
                new CuentaCorriente("098765", 1500, new string[] { "Carlos", "Laura" }, Estado.Activa, 0.01m)
                {
                    _limiteDeDescubierto = 300
                }

            };

            foreach (var cuenta in cuentas)
            {
                try
                {
                    if (cuenta._numero == "123456")
                    {
                        cuenta.Depositar(0);
                        cuenta.Retirar(50);
                        cuenta.AplicarInteres();
                    }
                    else if (cuenta._numero == "789012")
                    {
                        cuenta.Depositar(100);
                        cuenta.Retirar(200);
                        cuenta.AplicarInteres();
                    }
                    else if (cuenta._numero == "654321")
                    {
                        cuenta.Depositar(300);
                        cuenta.Retirar(1000);
                    }
                    else if (cuenta._numero == "098765")
                    {
                        cuenta.Depositar(400);
                        cuenta.Retirar(2000);

                    }
                }
                catch (MontoNoValido ex)
                {
                    Console.WriteLine($"Cuenta N° {cuenta._numero}: " + ex.Message);
                }
                catch (CuentaNoActiva ex)
                {
                    Console.WriteLine($"Cuenta N° {cuenta._numero}: " + ex.Message);
                }
                catch (SaldoInsuficiente ex)
                {
                    Console.WriteLine($"Cuenta N° {cuenta._numero}: " + ex.Message);
                }

            }
            foreach (var cuenta in cuentas)
            {
                var resumen = new
                {
                    numero = cuenta._numero,
                    tipo = cuenta.GetType().Name,
                    saldo = cuenta._saldo


                };
                Console.WriteLine($" Nº: {resumen.numero}, Tipo: {resumen.tipo}, Saldo: ${resumen.saldo}");
            }

        }
    }
}