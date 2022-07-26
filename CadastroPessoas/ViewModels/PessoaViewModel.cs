using CadastroPessoas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroPessoas.ViewModels
{
    public class PessoaViewModel
    {
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))                                                              //método interpreta qualquer caractere que retorna um valor de true quando ele é passado para o Char.
                throw new ApplicationException("O campo nome é obrigatório.");

            if (Nome.Length > 200)                                                                            //quantidade de caracteres desejado no campo
                throw new ApplicationException("O campo Nome só pode ter 200 caracteres");

            if (DataNascimento == null)                                                                       //tornar campo obrigatório
                throw new ApplicationException("O campo DataNascimento é obrigatório");

            if (DataNascimento > DateTime.Now.Date)                                                           //dateTime.Now.Date data atual 
                throw new ApplicationException(String.Format("O campo DataNascimento não pode ser " +
                    "maior que a data atual {0:dd/MM/yyyy}", DateTime.Now.Date));                              //string.format é que formata a data

            if (DataNascimento < new DateTime(1990 / 1 / 1))
                throw new ApplicationException(String.Format("O campo DataNascimento não pode ser " +
                    "inferior a data {0:dd/MM/yyyy}", new DateTime(1990 / 1 / 1)));

            if (string.IsNullOrWhiteSpace(EstadoCivil))
                throw new ApplicationException("O campo EstadoCivil é obrigatório");

            if (EstadoCivil.Length > 20)                                                                            //quantidade de caracteres desejado no campo
                throw new ApplicationException("O campo EstadoCivil só pode ter 20 caracteres");

            if (string.IsNullOrWhiteSpace(Sexo))
                throw new ApplicationException("O campo Sexo é obrigatório");

            if (Sexo.Length > 1)                                                                            //quantidade de caracteres desejado no campo
                throw new ApplicationException("O campo Sexo só pode ter 1 caracter");

            if (string.IsNullOrWhiteSpace(CPF))
                throw new ApplicationException("O campo CPF é obrigatório");

            if (CPF.Length != 11)                                                                            //quantidade de caracteres desejado no campo
                throw new ApplicationException("O campo CPF deve conter 11 caracteres");

            if (!ValidarCPF(CPF))
                throw new ApplicationException("CPF invalido");

            using (Conexao db = new Conexao())
            {
                if (db.Pessoa.Any(c => c.CPF == CPF))
                    throw new ApplicationException("CPF já cadastrado.");
            }

            if (string.IsNullOrWhiteSpace(CEP))                                                            
                throw new ApplicationException("O campo nome é obrigatório.");

            if (CEP.Length > 8)                                                                            
                throw new ApplicationException("O campo CEP só pode ter 8 caracteres");

            if (string.IsNullOrWhiteSpace(Endereco))
                throw new ApplicationException("O campo nome é obrigatório.");

            if (Endereco.Length > 100)
                throw new ApplicationException("O campo Endereco só pode ter 100 caracteres");


        }

        public bool ValidarCPF(string vrCPF)
        {

                string valor = vrCPF.Replace(".", "");
                valor = valor.Replace("-", "");

                if (valor.Length != 11)
                    return false;

                bool igual = true;
                for (int i = 1; i < 11 && igual; i++)
                    if (valor[i] != valor[0])
                        igual = false;

                if (igual || valor == "12345678909")
                    return false;

                int[] numeros = new int[11];
                for (int i = 0; i < 11; i++)
                    numeros[i] = int.Parse(
                      valor[i].ToString());

                int soma = 0;
                for (int i = 0; i < 9; i++)
                    soma += (10 - i) * numeros[i];

                int resultado = soma % 11;
                if (resultado == 1 || resultado == 0)
                {
                    if (numeros[9] != 0)
                        return false;
                }
                else if (numeros[9] != 11 - resultado)
                    return false;

                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += (11 - i) * numeros[i];
                resultado = soma % 11;
                if (resultado == 1 || resultado == 0)
                {
                    if (numeros[10] != 0)
                        return false;
                }
                else
                    if (numeros[10] != 11 - resultado)
                    return false;

                return true;            
        }
    }
}