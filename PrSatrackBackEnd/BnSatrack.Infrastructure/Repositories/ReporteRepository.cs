using BnSatrack.Core.Entites;
using BnSatrack.Core.Interfaces.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnSatrack.Infrastructure.Repositories
{
    public class ReporteRepository : IReportesRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionstrings;

        public ReporteRepository(IConfiguration configuration, IOptions<AppSettings> app)
        {
            this._configuration = configuration;
            this.connectionstrings = app.Value.ConnectionStrings;
        }

        List<MesaMes> IReportesRepository.GetReporteMesaMes()
        {
            DataTable dt = new DataTable();
            List<MesaMes> messages = new List<MesaMes>();
            int secuencia = 0;
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SPGetReporteMesaMes", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    foreach (var item in dt.Rows)
                    {
                        messages.Add(new MesaMes
                        {                            
                            Mes = dt.Rows[secuencia]["Mes"].ToString(),
                            DocumentoCliente = dt.Rows[secuencia]["DocumentoCliente"].ToString(),
                            SaldoTotal = dt.Rows[secuencia]["SaldoTotal"].ToString(),
                          

                        });
                        secuencia++;
                    }
                }

                return messages;
            }
            catch (Exception ex)
            {
                return new List<MesaMes>();
            }
        }

        List<SaldoPromedio> IReportesRepository.GetReporteSaldoPromedio()
        {
            DataTable dt = new DataTable();
            List<SaldoPromedio> messages = new List<SaldoPromedio>();
            int secuencia = 0;
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SPGetReporteSaldoPromedio", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    foreach (var item in dt.Rows)
                    {
                        messages.Add(new SaldoPromedio
                        {
                            TipoCliente = dt.Rows[secuencia]["TipoCliente"].ToString(),
                            Promedio = dt.Rows[secuencia]["Promedio"].ToString()

                        });
                        secuencia++;
                    }
                }

                return messages;
            }
            catch (Exception ex)
            {
                return new List<SaldoPromedio>();
            }
        }

        List<TopClientes> IReportesRepository.GetReporteTopClientesPorProductoo()
        {
            DataTable dt = new DataTable();
            List<TopClientes> messages = new List<TopClientes>();
            int secuencia = 0;
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SPGetReporteTopClientes", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    foreach (var item in dt.Rows)
                    {
                        messages.Add(new TopClientes
                        {
                            Posicion = dt.Rows[secuencia]["posicion"].ToString(),
                            Nombre = dt.Rows[secuencia]["Nombre"].ToString(),
                            descripcion = dt.Rows[secuencia]["descripcion"].ToString(),
                            Saldo = dt.Rows[secuencia]["Saldo"].ToString()
                        });
                        secuencia++;
                    }
                }

                return messages;
            }
            catch (Exception ex)
            {
                return new List<TopClientes>();
            }
        }
    }
}
