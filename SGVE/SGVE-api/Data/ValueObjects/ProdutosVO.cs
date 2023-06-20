namespace SGVE_api.Data.ValueObjects
{
    public class ProdutosVO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Marca { get; set; }
        public decimal Custo { get; set; }
        public decimal Preco { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public DateTime Data_Alteracao { get; set; }
        public int Id_Tipo { get; set; }
    }
}
