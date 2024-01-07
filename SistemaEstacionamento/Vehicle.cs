using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstacionamento
{
    public class Vehicle
    {
        public string Placa { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Ano { get; private set; }
        public DateTime Entrada { get; private set; }

        public Vehicle(string placa, string marca, string modelo, string ano)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Entrada = DateTime.Now;
        }
    }
}
