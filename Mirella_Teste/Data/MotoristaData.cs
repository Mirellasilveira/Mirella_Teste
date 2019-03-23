using Mirella_Teste.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Mirella_Teste.Data
{
    public static class MotoristaData
    {
        public static void CriarMotorista(CriarMotoristaViewModel model)
        {
            string conexao = @"Data Source=DESKTOP-1SM8DBR\SQLEXPRESS; Initial Catalog=TesteAplicativoCarona; Integrated Security=SSPI";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                string comando = $"INSERT INTO Motoristas (Nome,DataNascimento,CPF,ModeloCarro,Sexo)" +
                    $"VALUES('{model.Nome}','{model.DataNascimento.ToString("yyyy-MM-dd")}','{model.CPF}','{model.ModeloCarro}','{model.Sexo}')";
                using (SqlCommand cmd = new SqlCommand(comando, conn))
                {
                    conn.Open();
                    var teste = cmd.ExecuteScalar();
                }
            }
        }

        internal static List<MotoristaViewModel> BuscarMotoristasAtivos()
        {
            List<MotoristaViewModel> re = new List<MotoristaViewModel>();
            string conexao = @"Data Source=DESKTOP-1SM8DBR\SQLEXPRESS; Initial Catalog=TesteAplicativoCarona; Integrated Security=SSPI";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                string comando = $"SELECT * FROM Motoristas WHERE Status = 1";

                using (SqlCommand cmd = new SqlCommand(comando, conn))
                {
                    conn.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        re.Add(new MotoristaViewModel
                        {
                            Id = (int)reader["Id"],
                            Nome = reader["Nome"].ToString(),
                            ModeloCarro = reader["ModeloCarro"].ToString(),
                            Status = Convert.ToBoolean(reader["Status"])

                        });
                    }
                }
            }
            return re;
        }

        public static List<MotoristaViewModel> BuscarMotorista(string nome)
        {
            List<MotoristaViewModel> re = new List<MotoristaViewModel>();
            string conexao = @"Data Source=DESKTOP-1SM8DBR\SQLEXPRESS; Initial Catalog=TesteAplicativoCarona; Integrated Security=SSPI";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                string comando = $"SELECT * FROM Motoristas ";
                if (!string.IsNullOrEmpty(nome))
                    comando += "WHERE Nome LIKE '%{nome}%'";

                using (SqlCommand cmd = new SqlCommand(comando, conn))
                {
                    conn.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        re.Add(new MotoristaViewModel
                        {
                            Id = (int)reader["Id"],
                            Nome = reader["Nome"].ToString(),
                            ModeloCarro = reader["ModeloCarro"].ToString(),
                            Status = Convert.ToBoolean(reader["Status"])

                        });
                    }
                }
            }
            return re;
        }

        public static List<MotoristaViewModel> BuscarMotoristas()
        {
            throw new NotImplementedException();
        }

        public static void AtivarMotorista(string id)
        {
            string conexao = @"Data Source=DESKTOP-1SM8DBR\SQLEXPRESS; Initial Catalog=TesteAplicativoCarona; Integrated Security=SSPI";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                string comando = $"UPDATE Motoristas SET Status = 1 WHERE Id = " + id;
                using (SqlCommand cmd = new SqlCommand(comando, conn))
                {
                    conn.Open();
                    var teste = cmd.ExecuteScalar();
                }
            }
        }

        public static void DesativarMotorista(string id)
        {
            string conexao = @"Data Source=DESKTOP-1SM8DBR\SQLEXPRESS; Initial Catalog=TesteAplicativoCarona; Integrated Security=SSPI";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                string comando = $"UPDATE Motoristas SET Status = 0 WHERE Id = " + id;
                using (SqlCommand cmd = new SqlCommand(comando, conn))
                {
                    conn.Open();
                    var teste = cmd.ExecuteScalar();
                }
            }
        }
    }
}
