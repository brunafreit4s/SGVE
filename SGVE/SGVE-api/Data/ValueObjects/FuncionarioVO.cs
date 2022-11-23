namespace SGVE_api.Data.ValueObjects
{
    public class FuncionarioVO
    {
        public long Id { get; set; }
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Rg { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string? DDD_Celular { get; set; }
        public string? Celular { get; set; }
        public string? DDD_Telefone { get; set; }
        public string? Telefone { get; set; }
        public int Id_Endereco { get; set; }
        public string? Numero_Endereco { get; set; }
        public string? Complemento_Endereco { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public DateTime? Data_Desligamento { get; set; }
        public int Id_Cargo { get; set; }
    }
}
