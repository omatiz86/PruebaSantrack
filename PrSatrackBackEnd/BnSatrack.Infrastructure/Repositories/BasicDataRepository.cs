using BnSatrack.Core.Entites;
using BnSatrack.Core.Interfaces.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnSatrack.Infrastructure.Repositories
{
    public class BasicDataRepository   : IBasicDataRepository
    {        
        private readonly IConfiguration _configuration;
        private readonly string connectionstrings;

        public BasicDataRepository(IConfiguration configuration, IOptions<AppSettings> app)
        {
            this._configuration = configuration;
            this.connectionstrings = app.Value.ConnectionStrings;
        }

        public List<TipoProducto> GetProductos()
        {
            DataTable dt = new DataTable();
            List<TipoProducto> messages = new List<TipoProducto>();
            int secuencia = 0;
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SPGetTiposProdutos", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    foreach (var item in dt.Rows)
                    {
                        messages.Add(new TipoProducto
                        {
                            IdTipoProducto = Convert.ToInt32(dt.Rows[secuencia]["IdTipoProducto"]),
                            Descripcion = dt.Rows[secuencia]["Productos"].ToString()                           
                        });
                        secuencia++;
                    }
                }

                return messages;
            }
            catch (Exception ex)
            {
                return new List<TipoProducto>();
            }
        }

        public List<Ubicacion> GetUbicacion()
        {
            DataTable dt = new DataTable();
            List<Ubicacion> messages = new List<Ubicacion>();
            int secuencia = 0;
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SPGetUbicacion", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    foreach (var item in dt.Rows)
                    {
                        messages.Add(new Ubicacion
                        {
                            IdUbicacion = Convert.ToInt32(dt.Rows[secuencia]["IdUbicacion"]),
                            CodDivipola = dt.Rows[secuencia]["CodDivipola"].ToString(),
                            Descripcion = dt.Rows[secuencia]["Descripcion"].ToString(),
                            Tipo = dt.Rows[secuencia]["Tipo"].ToString(),
                            IdPapa = dt.Rows[secuencia]["IdPapa"].ToString(),
                            IdHijo = dt.Rows[secuencia]["IdHijo"].ToString(),
                            Activo = dt.Rows[secuencia]["Activo"].ToString(),

                        });
                        secuencia++;
                    }
                }

                return messages;
            }
            catch (Exception ex)
            {
                return new List<Ubicacion>();
            }
        }

    }
}
