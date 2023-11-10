using BnSatrack.Core.Entites;
using BnSatrack.Core.Interfaces.Repository;
using BnSatrack.Infrastructure.Context;
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
    public class GestionBnRepository : RepositoryBase<Transacciones>, IGestionBnRepository
    {
        #region Atributos y Propiedades
        private readonly IConfiguration _configuration;        
        private readonly EFContext context;
        #endregion Atributos y Propiedades

        #region Constructor
        public GestionBnRepository(IConfiguration configuration, EFContext dbContext) : base(dbContext)
        {
            this._configuration = configuration;
            this.context = dbContext;
        }

        #endregion Constructor

        public object UpdateActualizarSaldo(string documento)
        {
            DataTable dt = new DataTable();          
            try
            {
                string connectionString = this._configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SPActualizarSaldo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Documento", documento);                    
                    cmd.CommandTimeout = 200;
                    var dr = cmd.ExecuteReader();
                    dt.Load(dr);
                }
                return true;
            }
            catch (Exception ex)
            {
                return new List<Ubicacion>();
            }
        }


        public object GetCancelarCDT(string idCdt)
        {
            DataTable dt = new DataTable();
            List<Ubicacion> messages = new List<Ubicacion>();
            int secuencia = 0;
            try
            {
                string connectionString = this._configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SPGetCancelarCDT", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    foreach (var item in dt.Rows)
                    {
                        messages.Add(new Ubicacion
                        {                            
                            CodDivipola = dt.Rows[secuencia]["MensajeRta"].ToString(),                        
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

        public object GetProductosxCliente(string documento)
        {
            DataTable dt = new DataTable();
            List<Ubicacion> messages = new List<Ubicacion>();
            int secuencia = 0;
            try
            {
                string connectionString = this._configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SPGetProductosxCliente", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    foreach (var item in dt.Rows)
                    {
                        messages.Add(new Ubicacion
                        {
                            IdUbicacion = Convert.ToInt32(dt.Rows[secuencia]["Nombre"]),
                            CodDivipola = dt.Rows[secuencia]["descripcion"].ToString(),
                            Descripcion = dt.Rows[secuencia]["Saldo"].ToString(),                           

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
