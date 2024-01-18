using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UD4T3.MVVM.Model {
    /// <summary> Clase Alumno </summary>
    /// <remarks>
    /// Clase donde se crea la un alumno, esta clase sirve como modelo para la creación del SQLite de la aplicación
    /// </remarks>  
    [SQLite.Table("Alumno")]
    public class Alumno {

        /// <summary> Propiedad de la clase Alumno </summary>
        /// <remarks> Se establece un id incremental para el alumno </remarks>
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        /// <summary> Propiedad de la clase Alumno </summary>
        /// <remarks> Se establece un nombre que tendrá el alumno </remarks>
        [SQLite.Column("nombre"), NotNull]
        public string Nombre { get; set; }
        /// <summary> Propiedad de la clase Alumno </summary>
        /// <remarks> Se establece un nif que tendrá el alumno </remarks>
        [MaxLength(9),Unique]
        public string Nif { get; set; }

        /// <summary> Propiedad de la clase Alumno </summary>
        /// <remarks> Se establece la empresa que pertenece el alumno </remarks>
        [MaxLength(100)]
        public string Empresa { get; set; }
    }
}
