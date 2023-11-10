using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnSatrack.Core.Entites
{
    public  class AppSettings
    {
        private readonly IConfiguration? _configuration;
        private string connectionstring; // Mover la declaración aquí

        //public AppSettings(IConfiguration configuration)
        //{
        //    this._configuration = configuration;
        //    connectionstring = _configuration.GetConnectionString("DefaultConnection"); // Inicializar en el constructor
        //}

        public string ConnectionStrings
        {
            get { return connectionstring; }
            set { this.connectionstring = value; }
        }

    }
}
