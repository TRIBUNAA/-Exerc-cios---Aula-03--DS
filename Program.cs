﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Aula03Colecoes.Models;

namespace Aula03Colecoes
{
    class Program
    {
       static List<Funcionario> lista = new List<Funcionario>();

       static void Main(string[] args)
       {
          ExemplosListasColecoes(); 
       }

       public static void CriarLista()
       {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.Cpf = "1357924608";
            f3.DataAdmissao = DateTime.Parse("01/01/2000");
            f3.Salario = 100.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.Cpf = "12345678912";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.Cpf = "12345678913";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Rodrigo Garro";
            f6.Cpf = "12345678915";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f6);
       }

       public static void ExibirLista()
       {
           string dados = "";
           for (int i = 0; i < lista.Count; i++)
           {
               dados += "===============================\n";
               dados += string.Format("Id: {0} \n", lista[i].Id);
               dados += string.Format("Nome: {0 \n}", lista[i].Nome);
               dados += string.Format("CPF: {0} \n", lista[i].Cpf);
               dados += string.Format("Admissão: {0:dd/MM/yyyy} \n", lista[i].DataAdmissao);
               dados += string.Format("Salário: {0:c2} \n", lista[i].Salario);
               dados += string.Format("Tipo: {0} \n", lista[i].TipoFuncionario);
               dados += "===============================\n";   
           }
           Console.WriteLine(dados);
       }
       public static void ObterPorId()
       {
            lista = lista.FindAll(x => x.Id == 1);
            ExibirLista();
       }

       public static void ExemplosListasColecoes()
       {
        Console.WriteLine("==================================================");
        Console.WriteLine("****** Exemplos - Aula 03 Listas e Coleçôes ******");
        Console.WriteLine("==================================================");
        CriarLista();
        int opcaoEscolhida = 0;
        do
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("--- Digite o número referente a opção desejada : ---");
            Console.WriteLine("1 - Obter Por Id");
            Console.WriteLine("2 - Adicionar Funcionário");
            Console.WriteLine("3 - Obter Por Id digitado");
            Console.WriteLine("4 - Obter Por Salário digitado");
            Console.WriteLine("====================================================");
            Console.WriteLine("----- Ou tecle qualquer outro número para sair -----");
            Console.WriteLine("====================================================");

            opcaoEscolhida = int.Parse(Console.ReadLine());
            string mensagem = string.Empty;
            switch (opcaoEscolhida)
            {
                case 1:
                    ObterPorId();
                    break;
                case 2:
                    AdicionarFuncionario();
                    break;
                case 3:
                    Console.WriteLine("Digite o Id do funcionário que você deseja buscar");
                    int id = int.Parse(Console.ReadLine());
                    ObterPorId(id);
                    break;
                case 4:
                    Console.WriteLine("Digite o salário para obter todos acima do valor indicado:");
                    decimal salario = decimal.Parse(Console.ReadLine());
                    ObterPorSalario(salario);
                    break;
                default:
                    Console.WriteLine("Saindo do sistema....");
                    break;
            }
        } while (opcaoEscolhida >= 1 && opcaoEscolhida <= 10);

        Console.WriteLine("================================================"); 
        Console.WriteLine("* Obrigado por utilizar o sistema volte sempre *");
        Console.WriteLine("================================================");

    }

    public static void AdicionarFuncionario()
    {
        Funcionario f = new Funcionario();

        Console.WriteLine("Digite o nome: ");
        f.Nome = Console.ReadLine();

        Console.WriteLine("Digite o salário: ");
        f.Salario = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Digite a data de admissão: ");
        f.DataAdmissao = DateTime.Parse(Console.ReadLine());

        if (string.IsNullOrEmpty(f.Nome))
        {
            Console.WriteLine("O nome deve ser preenchido ");
            return;
        }
        else if(f.Salario == 0)
        {
            Console.WriteLine("Valor do salário não pode ser 0");
            return;
        }
        else
        {
            lista.Add(f);
            ExibirLista();
        }
    }

    public static void ObterPorId(int id)
    {
        Funcionario fBusca = lista.Find(x => x.Id == id);

        Console.WriteLine($"Funcionario encontrado: {fBusca.Nome}");
    }

    public static void ObterPorSalario(decimal valor)
    {
        lista = lista.FindAll(x => x.Salario >= valor);
        ExibirLista();
    }

    public static void Ordenar()
    {
        lista = lista.OrderBy(x => x.Nome).ToList();
        ExibirLista();
    }

    public static void ContarFuncionarios()
    {
        int qtd = lista.Count();
        Console.WriteLine($"Existem {qtd} funcionários. ");
    }

    public static void SomarSalarios()
    {
        decimal somatorio = lista.Sum(x => x.Salario);
        Console.WriteLine (string.Format("A soma dos salários é {0:c2}. ", somatorio));
    }

    public static void ExibirAprendizes()
    {
        lista = lista.FindAll( x => x.TipoFuncionario == TipoFuncionarioEnum.Aprendiz);
        ExibirLista();
    }

    public static void BuscarPorNomeAproximado()
    {
        AdicionarFuncionario();

        lista = lista.FindAll( x => x.Nome.ToLower().Contains("ronaldo"));

        ExibirLista();
    }

    public void BuscarPorCpfRemover()
    {
        Funcionario fBusca = lista.Find( x => x.Cpf == "01987654321");
        lista.Remove(fBusca);
        Console.WriteLine($"Personagem removido: {fBusca.Nome} \nLista Atualizada: \n ");

        ExibirLista();
    }

    public static void RemoverIdMenor4()
    {
        lista.RemoveAll( x => x.Id < 4);
        ExibirLista();
    }
}
}
