using System;
using System.Data;

namespace SGVE_api.Models
{
    public class RetornoDataSet
    {
        public static string ConsultaDataRow(DataRow oDR, string Campo)
        {
            return oDR[Campo].ToString().Trim();
        }
    }
}
