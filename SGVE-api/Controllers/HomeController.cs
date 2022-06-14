using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using SGVE.Models;
using SGVE_api.EntityStore;
using Microsoft.AspNetCore.Http;
using System.Data;
using MySql.Data.MySqlClient;
using SGVE_api.Models;

namespace SGVE_api.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<Usuario>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Retorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Retorno), StatusCodes.Status500InternalServerError)]
        [Route("api/Home/DadosUsuario/")]
        public IActionResult Get_DadosUsuario([FromBody] Usuario vData)
        {
            try
            {
                var retorno = new List<Usuario>();
                MySqlParameter[] oParametros = new MySqlParameter[2];
                oParametros[0] = new MySqlParameter("EMAIL", vData.EMAIL_FUNC);
                oParametros[1] = new MySqlParameter("SENHA", vData.SENHA_FUNC);

                ConnectionMySql cms = new ConnectionMySql();

                var oDS = cms.ExecuteQuery(2, "PROC_LOGIN_FUNC", oParametros);

                foreach (DataRow row in oDS.Tables[0].Rows)
                {
                    retorno.Add(new Usuario()
                    {
                        NOME_FUNC   = RetornoDataSet.ConsultaDataRow(row, "NOME_FUNC"),
                        COD_FUNC    = int.Parse(RetornoDataSet.ConsultaDataRow(row, "FK_COD_CARGO")),
                    });
                }

                if (retorno.Count > 0)
                {
                    return Ok(retorno);
                }
                else
                {
                    return BadRequest(retorno);
                }
            }
            catch(Exception ex)
            {
                ERRO objErro = new ERRO();
                objErro.strErro = "Erro Interno 1.1: " + ex.Message;
                return StatusCode((int)StatusCodes.Status500InternalServerError, objErro.strErro);
            }
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(List<Produtos>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Retorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Retorno), StatusCodes.Status500InternalServerError)]
        [Route("api/Home/ProdutosEstoque/")]
        public IActionResult Get_ProdutosEstoque()
        {
            try
            {
                var retorno = new List<Produtos>();

                ConnectionMySql cms = new ConnectionMySql();

                MySqlParameter[] oParametros = new MySqlParameter[2];
                oParametros[0] = new MySqlParameter("CODIGO", 0);
                oParametros[1] = new MySqlParameter("NOME", "");

                var oDS = cms.ExecuteQuery(2, "PROC_SELECT_PROD", oParametros);

                foreach (DataRow row in oDS.Tables[0].Rows)
                {
                    retorno.Add(new Produtos()
                    {
                        COD_BARRAS          = RetornoDataSet.ConsultaDataRow(row, "COD_BARRAS"),
                        NOME_PROD           = RetornoDataSet.ConsultaDataRow(row, "NOME_PROD"),
                        MARCA_PROD          = RetornoDataSet.ConsultaDataRow(row, "MARCA_PROD"),
                        PRECO_PROD          = double.Parse(RetornoDataSet.ConsultaDataRow(row, "PRECO_PROD")),
                        CUSTO_PROD          = double.Parse(RetornoDataSet.ConsultaDataRow(row, "CUSTO_PROD")),
                        DATA_CAD_PROD       = RetornoDataSet.ConsultaDataRow(row, "DATA_CAD_PROD"),
                        QUANTIDADE_PROD     = int.Parse(RetornoDataSet.ConsultaDataRow(row, "QUANTIDADE_PROD")),
                        DESC_PROD           = RetornoDataSet.ConsultaDataRow(row, "DESC_PROD"),
                    });
                }

                if (retorno.Count > 0)
                {
                    return Ok(retorno);
                }
                else
                {
                    return BadRequest(retorno);
                }
            }
            catch (Exception ex)
            {
                ERRO objErro = new ERRO();
                objErro.strErro = "Erro Interno 1.2: " + ex.Message;
                return StatusCode((int)StatusCodes.Status500InternalServerError, objErro.strErro);
            }
        }

        [HttpPost("api/Home/AdicionaUsuario")]
        public JsonResult Post_DadosUsuario(Usuario parametros)
        {
            try
            {
                _context.Funcionario.Add(parametros);
                _context.SaveChanges();

                return Json(_context);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
