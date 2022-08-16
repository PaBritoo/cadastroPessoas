﻿using CadastroPessoas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CadastroPessoas.Controllers
{
    [RoutePrefix("api/pessoa")]
    public class PessoaApiController : ApiController
    {

        [Route ("verificar-cpf-ja-cadastrado")]
        [HttpGet]
        public IHttpActionResult VerificarCpfJaCadastrado(string cpf)
        {
            using(Conexao db = new Conexao())
            {
                bool existeCpf = db.Pessoa.Any(c => c.CPF == cpf);
                return Ok(new { resultado = existeCpf });
            }
            
        }
    }
}