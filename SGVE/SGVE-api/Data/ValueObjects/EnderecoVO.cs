namespace SGVE_api.Data.ValueObjects
{
    public class EnderecoVO
    {
        public long _id { get; set; }
        public int _cep { get; set; }
        public string _tipoCep { get; set; }
        public string _uf { get; set; }
        public string _cidade { get; set; }
        public string _bairro { get; set; }
        public string _endereco { get; set; }
        public string _complemento { get; set; }
        public string _codigoIBGE { get; set; }
    }
}
