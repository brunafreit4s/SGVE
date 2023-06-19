namespace SGVE_api.Data.ValueObjects
{
    public class FuncionarioVO
    {
        public long Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public string Cep_Endereco { get; set; }
        public string Logradouro_Endereco { get; set; }
        public string Numero_Endereco { get; set; }
        public string Complemento_Endereco { get; set; }
        public string Bairro_Endereco { get; set; }
        public string Cidade_Endereco { get; set; }
        public string UF_Endereco { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public DateTime Data_Alteracao { get; set; }
        public int Id_Cargo { get; set; }
    }

    public class FuncionarioChat
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}
