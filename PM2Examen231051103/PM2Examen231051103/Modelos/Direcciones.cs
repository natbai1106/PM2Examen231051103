using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM2Examen231051103.Modelos
{
    class Direcciones
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public double latitud { get; set; }

        public double longitud { get; set; }
        
        [MaxLength(500)]
        public string descriplarga { get; set; }
        
        [MaxLength(250)]
        public string descripcorta { get; set; }
    }
}
