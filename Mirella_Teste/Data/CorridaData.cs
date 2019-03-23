using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Mirella_Teste.Models;

namespace Mirella_Teste.Data
{
    public class CorridaData
    {
        internal static List<CorridaViewModel> BuscarCorridas()
        {
            List<CorridaViewModel> re = new List<CorridaViewModel>();
            string conexao = @"Data Source=DESKTOP-1SM8DBR\SQLEXPRESS; Initial Catalog=TesteAplicativoCarona; Integrated Security=SSPI";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                string comando = @"
                    SELECT
	                    C.IdCorrida,
	                    M.Nome AS [NomeMotorista],
	                    P.Nome AS [NomePassageiro],
	                    C.DataCorrida,
	                    C.Valor
                    FROM Corridas AS C

                    INNER JOIN Motoristas M ON
	                    M.Id = C.IdMotorista

                    INNER JOIN Passageiros P ON 
	                    P.Id = C.IdPassageiro";

                using (SqlCommand cmd = new SqlCommand(comando, conn))
                {
                    conn.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        re.Add(new CorridaViewModel
                        {
                            Id = (int)reader["IdCorrida"],
                            Motorista = reader["NomeMotorista"].ToString(),
                            Passageiro = reader["NomePassageiro"].ToString(),
                            DataCorrida = Convert.ToDateTime(reader["DataCorrida"]),
                            Valor = Convert.ToDouble(reader["Valor"])
                        });
                    }
                }
            }
            return re;
        }

        internal static void CriarCorrida(CriarCorridaViewModel model)
        {
            string conexao = @"Data Source=DESKTOP-1SM8DBR\SQLEXPRESS; Initial Catalog=TesteAplicativoCarona; Integrated Security=SSPI";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                string comando = $"INSERT INTO Corridas (IdMotorista,IdPassageiro,DataCorrida,Valor)" +
                    $"VALUES('{model.IdMotorista}','{model.IdPassageiro}','{model.DataCorrida.ToString("yyyy-MM-dd")}',{model.Valor.ToString().Replace(",",".")})";
                using (SqlCommand cmd = new SqlCommand(comando, conn))
                {
                    conn.Open();
                    var teste = cmd.ExecuteScalar();
                }
            }
        }
    }
}
