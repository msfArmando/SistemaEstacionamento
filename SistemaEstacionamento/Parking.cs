using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemaEstacionamento
{
    public class Parking
    {
        public List<Vehicle> VeiculosEstacionados { get; private set; }
        public Parking()
        {
            List<Vehicle> listaVeiculosNoEstacionamento = new List<Vehicle>();
            VeiculosEstacionados = listaVeiculosNoEstacionamento;
        }

        public void CadastrarVeiculo(Vehicle veiculo)
        {
            if (ValidarPlaca(veiculo.Placa))
            {
                foreach (var veiculoLista in VeiculosEstacionados)
                {
                    if (veiculo.Placa == veiculoLista.Placa)
                        throw new Exception("Não foi possível estacionar o veículo pois o mesmo já está estacionado.");
                    else if(veiculo.Ano < 1884 || veiculo.Ano > 2024)
                    {
                        throw new Exception("Ano de carro inválido.");
                    }
                }
                VeiculosEstacionados.Add(veiculo);
                Console.WriteLine("Carro estacionado.");
            }
            else
            {
                throw new Exception("Formato de placa inválido.");
            }
        }

        public void RemverVeiculo(string placa)
        {
            foreach (var veiculo in VeiculosEstacionados)
            {
                if (veiculo.Placa == placa)
                {
                    int valorInicial = 5;
                    VeiculosEstacionados.Remove(veiculo);

                    DateTime vehicleExitTime = DateTime.Now;
                    TimeSpan Diference = vehicleExitTime - veiculo.Entrada;
                    int multipliedValue = (valorInicial + (int)Diference.TotalHours * 2);
                    string formattedValue = multipliedValue.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));

                    Console.WriteLine("Veículo removido.");
                    Console.WriteLine($"Valor total a ser pago: {formattedValue}");
                    return;
                }
            }
            throw new Exception("Veículo não encontrado.");
        }

        public void ListarVeiculos()
        {
            Console.WriteLine("Véículos estacionados: ");
            if(VeiculosEstacionados.Count == 0)
            {
                Console.WriteLine("Não existem veículos estacionados.");
            }
            else
            {
                foreach (var veiculo in VeiculosEstacionados)
                {
                    Console.WriteLine("=======================\n" +
                        $"Placa: {veiculo.Placa}\n" +
                        $"Marca: {veiculo.Marca}\n" +
                        $"Modelo: {veiculo.Modelo}\n" +
                        $"Ano: {veiculo.Ano}\n" +
                        $"=======================");
                }
            }
        }

        private static bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa)) { return false; }

            if (placa.Length > 8) { return false; }

            placa = placa.Replace("-", "").Trim();

            if (char.IsLetter(placa, 4))
            {
                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(placa);
            }
            else
            {
                var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return padraoNormal.IsMatch(placa);
            }
        }
    }
}
