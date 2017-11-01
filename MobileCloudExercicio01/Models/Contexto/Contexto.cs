using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MobileCloudExercicio01.Models.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto() : base("strConn")
        {

        }

        public System.Data.Entity.DbSet<MobileCloudExercicio01.Models.Modelo> Modeloes { get; set; }
    }
}