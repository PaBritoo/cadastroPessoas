using CadastroPessoas.Models;
using CadastroPessoas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroPessoas.Controllers
{
    public class PessoaController : Controller
    {
        public ActionResult Listar()
        {
            using (Conexao db = new Conexao())                                       /*conexao com banco de dados*/        
            {
                List<Pessoa> pessoasModels = db.Pessoa.ToList();                     /*db.Pessoa.ToList esta puxando tudo que está cadastrado no banco de dados e irá guardar tudo dentro da variavel criada (pessoaModels)*/
                List<PessoaViewModel> pessoasVms = new List<PessoaViewModel>();

                foreach (Pessoa item in pessoasModels)                               /*irá executar uma açao para cada item da lista >pessoaModels<*/
                {
                    PessoaViewModel pessoaVm = new PessoaViewModel();
                    pessoaVm.Nome = item.Nome;
                    pessoaVm.DataNascimento = item.DataNascimento;
                    pessoaVm.Sexo = item.Sexo;
                    pessoaVm.EstadoCivil = item.EstadoCivil;
                    pessoaVm.CPF = item.CPF;
                    pessoaVm.CEP = item.CEP;
                    pessoaVm.Endereco = item.Endereco;
                    pessoaVm.Numero = item.Numero;
                    pessoaVm.Complemento = item.Complemento;
                    pessoaVm.Bairro = item.Bairro;
                    pessoaVm.Cidade = item.Cidade;
                    pessoaVm.UF = item.UF;

                    pessoasVms.Add(pessoaVm);
                }

                return View(pessoasVms);
            }

        }
                
        public ActionResult Cadastrar()
        {
            if (TempData["mensagemSucesso"] != null)
            {
                ViewBag.mensagemSucesso = TempData["mensagemSucesso"];
            }
            return View();                                              ///local onde será retornado apos salvar dados
        }

        [HttpPost]                                                      //http post serve para enviar dados e httpGet serve para receber dados
        public ActionResult CadastrarPost(PessoaViewModel dados)
        {
            dados.TratarDados();
            dados.Validar();                                       /* irá tratar os dados antes de validar*/

            Pessoa model = new Pessoa();                          // criar novo registro da tabela Pessoa - ou seja criar uma variavel do tipo Pessoa
            model.Nome = dados.Nome;
            model.DataNascimento = dados.DataNascimento.Value;
            model.Sexo = dados.Sexo;
            model.EstadoCivil = dados.EstadoCivil;
            model.CPF = dados.CPF;
            model.CEP = dados.CEP;
            model.Endereco = dados.Endereco;
            model.Numero = dados.Numero;
            model.Complemento = dados.Complemento;
            model.Bairro = dados.Bairro;
            model.Cidade = dados.Cidade;
            model.UF = dados.UF;

            //codigo Entity Framework
            using (Conexao db = new Conexao())                         //declarar variavel  - tipo da classe que vai receber o banco de dados (nesse caso o Conexao) e essa variavel vai receber uma instancia que no caso é uma nova conexão no banco de dados
            {           
                db.Pessoa.Add(model);
                db.SaveChanges();
            }

            TempData["mensagemSucesso"] = "Cadastro realizado com sucesso.";
            
            return RedirectToAction("Cadastrar");                       // toda action post tem que retornar depois para algum lugar apos salvar os dados, retornar para uma view nesse caso o Cadastrar

        }

    }
}