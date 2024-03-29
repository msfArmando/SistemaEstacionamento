﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstacionamento
{
    class Program
    {
        public static void Main(string[] args)
        {
            Parking sistemaEstacionamento = new Parking();

            int option = 0;

            Console.WriteLine("Bem-vindo(a) ao Sistema de Estacionamento BigMonsa!\n" +
                    "1 - Cadastrar veículo\n" +
                    "2 - Remover veículo\n" +
                    "3 - Listar veículo\n" +
                    "4 - Encerrar");
            do
            {
                try
                {
                    Console.WriteLine("====================================");
                    Console.WriteLine("Escolha uma das opções disponíveis: ");
                    try
                    {
                        option = Int32.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        throw new Exception("Opção inválida");
                    }

                    switch (option)
                    {
                        case 1:

                            string placa, marca, modelo;
                            int ano;

                            Console.Write("Digite a placa: ");
                            placa = Console.ReadLine();

                            Console.Write("Digite a marca: ");
                            marca = Console.ReadLine();

                            Console.Write("Digite o modelo: ");
                            modelo = Console.ReadLine();

                            Console.Write("Digite o ano: ");
                            try
                            {
                                ano = Int32.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                throw new Exception("Formato de ano inválido.");
                            }

                            Vehicle veiculo = new Vehicle(placa, marca, modelo, ano);

                            sistemaEstacionamento.CadastrarVeiculo(veiculo);

                            break;
                        case 2:

                            string placaRemover;

                            Console.WriteLine("Digite a placa do veículo que deseja remover: ");
                            placaRemover = Console.ReadLine();

                            sistemaEstacionamento.RemverVeiculo(placaRemover);

                            break;
                        case 3:

                            sistemaEstacionamento.ListarVeiculos();

                            break;
                        case 4:
                            
                            Console.WriteLine("Encerrando sistema...");
                            Thread.Sleep(3000);

                            break;
                        default:
                            throw new Exception("Opção indisponível.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (option != 4);
        }
    }
}