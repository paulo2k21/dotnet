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
            medicos.Add(medico);
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
            pacientes.Add(paciente);
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
}
