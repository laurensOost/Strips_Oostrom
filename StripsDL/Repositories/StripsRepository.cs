using StripsBL.DTOs;
using StripsBL.Interfaces;
using StripsBL.Model;
using StripsDL.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsDL.Repositories
{
    public class StripsRepository : IStripsRepository
    {
        private string connectionString;

        public StripsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<StripDTO> GetStripsByReeksId(int reeksId)
        {
            var strips = new List<StripDTO>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT Id, Nr, Titel, Uitgeverij, Reeks FROM Strip WHERE Reeks = @ReeksId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ReeksId", reeksId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var strip = new StripDTO(
                                int.Parse(reader["Id"].ToString()),
                                reader["titel"].ToString(),
                                reader["Nr"].ToString(),
                                reader["Titel"].ToString(),
                                $"http://localhost:5044/api/Strips/beheer/strip/{reader["Id"]}"
                            );
                            strips.Add(strip);
                        }
                    }
                }

                return strips;
            }
        }
    }
}
