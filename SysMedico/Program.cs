﻿using System;
using System.Collections.Generic;
using System.Linq;

public enum Sexo
{
    Masculino,
    Feminino
}

public class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }

    public int Idade
    {
        get
        {
            int idade = DateTime.Now.Year - DataNascimento.Year;
            if (DateTime.Now.Month < DataNascimento.Month || (DateTime.Now.Month == DataNascimento.Month && DateTime.Now.Day < DataNascimento.Day))
            {
                idade--;
            }
            return idade;
        }
    }
}

public class Medico : Pessoa
{
    public string CRM { get; set; }

    public Medico(string nome, DateTime dataNascimento, string cpf, string crm)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = cpf;
        CRM = crm;
    }
}

public class Paciente : Pessoa
{
    public Sexo Sexo { get; set; }
    public string Sintomas { get; set; }

    public Paciente(string nome, DateTime dataNascimento, string cpf, Sexo sexo, string sintomas)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = cpf;
        Sexo = sexo;
        Sintomas = sintomas;
    }
}

public class ClinicaMedica
{
    private List<Medico> medicos = new List<Medico>();
    private List<Paciente> pacientes = new List<Paciente>();

    public void AdicionarMedico(Medico medico)
    {
        
        if (!medicos.Any(m => m.CPF == medico.CPF) && !medicos.Any(m => m.CRM == medico.CRM))
        {
           
            if (ValidarCPF(medico.CPF))
            {
                medicos.Add(medico);
            }
            else
            {
                throw new ArgumentException("O CPF deve ter exatamente 11 dígitos numéricos.");
            }
        }
        else
        {
            throw new ArgumentException("CPF ou CRM já cadastrado para outro médico.");
        }
    }

    public void AdicionarPaciente(Paciente paciente)
    {
        
        if (!pacientes.Any(p => p.CPF == paciente.CPF))
        {
           
            if (ValidarCPF(paciente.CPF))
            {
                pacientes.Add(paciente);
            }
            else
            {
                throw new ArgumentException("O CPF deve ter exatamente 11 dígitos numéricos.");
            }
        }
        else
        {
            throw new ArgumentException("CPF já cadastrado para outro paciente.");
        }
    }

    public IEnumerable<Medico> ObterMedicosPorIdade(int idadeMinima, int idadeMaxima)
    {
        return medicos.Where(m => m.Idade >= idadeMinima && m.Idade <= idadeMaxima);
    }

    public IEnumerable<Paciente> ObterPacientesPorIdade(int idadeMinima, int idadeMaxima)
    {
        return pacientes.Where(p => p.Idade >= idadeMinima && p.Idade <= idadeMaxima);
    }

    public IEnumerable<Paciente> ObterPacientesPorSexo(Sexo sexo)
    {
        return pacientes.Where(p => p.Sexo == sexo);
    }

    public IEnumerable<Paciente> ObterPacientesOrdemAlfabetica()
    {
        return pacientes.OrderBy(p => p.Nome);
    }

    public IEnumerable<Paciente> ObterPacientesPorSintomas(string textoSintomas)
    {
        return pacientes.Where(p => p.Sintomas.Contains(textoSintomas, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Pessoa> ObterAniversariantesDoMes(int mes)
    {
        return medicos.Concat<Pessoa>(pacientes).Where(p => p.DataNascimento.Month == mes);
    }

    private static bool ValidarCPF(string cpf)
    {
        
        if (cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            return false;
        }

        return true;
    }
}

class Program
{
    static void ExibirMedicos(IEnumerable<Medico> medicos)
    {
        foreach (var medico in medicos)
        {
            Console.WriteLine($"Nome: {medico.Nome}, CRM: {medico.CRM}, Idade: {medico.Idade}");
        }
    }

    static void ExibirPacientes(IEnumerable<Paciente> pacientes)
    {
        foreach (var paciente in pacientes)
        {
            Console.WriteLine($"Nome: {paciente.Nome}, Sexo: {paciente.Sexo}, Idade: {paciente.Idade}");
        }
    }

    static void ExibirMedicosEClientes(IEnumerable<Pessoa> pessoas)
    {
        foreach (var pessoa in pessoas)
        {
            if (pessoa is Medico medico)
            {
                Console.WriteLine($"Médico - Nome: {medico.Nome}, CRM: {medico.CRM}, Idade: {medico.Idade}");
            }
            else if (pessoa is Paciente paciente)
            {
                Console.WriteLine($"Paciente - Nome: {paciente.Nome}, Sexo: {paciente.Sexo}, Idade: {paciente.Idade}");
            }
        }
    }

    static void Main()
    {
        
        ClinicaMedica clinica = new ClinicaMedica();

       
        clinica.AdicionarMedico(new Medico("Dr. João Bichão", new DateTime(1980, 1, 1), "12345678901", "CRM85965"));

        clinica.AdicionarMedico(new Medico("Dra. Maria Braow", new DateTime(1975, 5, 10), "98765432101", "CRM54321"));

         clinica.AdicionarMedico(new Medico("Dra. Lula", new DateTime(1975, 5, 10), "98765432101", "CRM54391"));
          clinica.AdicionarMedico(new Medico("Dra. Ivete", new DateTime(1975, 5, 9), "98765403101", "CRM58321"));

        
        clinica.AdicionarPaciente(new Paciente("Paciente: Mano 1", new DateTime(1990, 3, 15), "11122233344", Sexo.Masculino, "Febre, Dor de cabeça"));

        clinica.AdicionarPaciente(new Paciente("Paciente: Mana2", new DateTime(1985, 8, 20), "55566677788", Sexo.Feminino, "Dor nas costas"));
        
     clinica.AdicionarPaciente(new Paciente("Paciente: Mana Bolsonaro", new DateTime(1985, 6, 6), "55545677788", Sexo.Feminino, "Dor de Barriga"));

     clinica.AdicionarPaciente(new Paciente("Paciente: Mana Michele ", new DateTime(1985, 8, 20), "55566977788", Sexo.Feminino, "Dente"));


        Console.WriteLine("Relatório de Médicos com idade entre 30 e 50 anos:");

        var relatorioMedicosIdade = clinica.ObterMedicosPorIdade(30, 50);

        ExibirMedicos(relatorioMedicosIdade);

        Console.WriteLine("\nRelatório de Pacientes com idade entre 25 e 40 anos:");

        var relatorioPacientesIdade = clinica.ObterPacientesPorIdade(25, 40);

        ExibirPacientes(relatorioPacientesIdade);

        Console.WriteLine("\nRelatório de Pacientes do sexo Masculino:");

        var relatorioPacientesSexo = clinica.ObterPacientesPorSexo(Sexo.Masculino);

        ExibirPacientes(relatorioPacientesSexo);

        Console.WriteLine("\nRelatório de Pacientes em ordem alfabética:");

        var relatorioPacientesOrdemAlfabetica = clinica.ObterPacientesOrdemAlfabetica();

        ExibirPacientes(relatorioPacientesOrdemAlfabetica);

        Console.WriteLine("\nRelatório de Pacientes com sintomas contendo 'Dor':");

        var relatorioPacientesSintomas = clinica.ObterPacientesPorSintomas("Dor");

        ExibirPacientes(relatorioPacientesSintomas);

        Console.WriteLine("\nRelatório de Médicos e Pacientes aniversariantes do mês 5:");

        var relatorioAniversariantes = clinica.ObterAniversariantesDoMes(5);

        ExibirMedicosEClientes(relatorioAniversariantes);
    }
}
