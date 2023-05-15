namespace SGVE_web.Models
{
    public class EnderecosViewModel
    {
        public int id { get; set; }
        public int cep { get; set; }
        public string tipoCep { get; set; }
        public string uf { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string codigoIBGE { get; set; }       
    }
}
