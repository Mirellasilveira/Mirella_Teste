using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Mirella_Teste.Models;

namespace Mirella_Teste.Data
{
    public class PassageiroData
    {
        internal static List<PassageirosViewModel> BuscarPassageiro(string nome)
        {
            List<PassageirosViewModel> re = new List<PassageirosViewModel>();
            string conexao = @"Data Source=tcp:testeaplicativo.database.windows.net,1433;Initial Catalog=TesteAplicativoBd;User Id=HenriqueBR@testeaplicativo.database.windows.net;Password=087615Baldin;";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                string comando = $"SELECT * FROM Passageiros ";
                if (!string.IsNullOrEmpty(nome))
                    comando += "WHERE Nome LIKE '%{nome}%'";

                using (SqlCommand cmd = new SqlCommand(comando, conn))
                {
                    conn.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        re.Add(new PassageirosViewModel
                        {
                            Id = (int)reader["Id"],
                            Nome = reader["Nome"].ToString(),
                        });
                    }
                }
            }
            return re;
        }

        internal static void CriarPassageiro(CriarPassageiroViewModel viewModel)
        {
            string conexao = @"Data Source=tcp:testeaplicativo.database.windows.net,1433;Initial Catalog=TesteAplicativoBd;User Id=HenriqueBR@testeaplicativo.database.windows.net;Password=087615Baldin;";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                string comando = $"INSERT INTO Passageiros (Nome,DataNascimento,CPF,Sexo)" +
                    $"VALUES('{viewModel.Nome}','{viewModel.DataNascimento.ToString("yyyy-MM-dd")}','{viewModel.CPF}','{viewModel.Sexo}')";
                using (SqlCommand cmd = new SqlCommand(comando, conn))
                {
                    conn.Open();
                    var teste = cmd.ExecuteScalar();
                }
            }
        }
    }
}
