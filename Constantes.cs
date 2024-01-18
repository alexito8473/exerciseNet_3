using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UD4T3 {
    /// <summary> Clase de las variables constantes del proyecto </summary>
    /// <remarks> Clase donde se almacenan las distintas variables que van a ser utilizadas alrededor de la aplicación.</remarks>
    public class Constantes {
        /*
        * Los atributos son readonly para que no se puedan modificar en el resto del proyecto.
        * Los atributos son estáticos para que no haga falta instanciar la clase para hacer uso de ellos.
        * Los atributos son públicos para que cualquier usuario pueda hacer uso de ellos.
        */

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un texto de erro cuando un alumno no tiene un nif</remarks> 
        public readonly static string ERROR_NO_EXITS_NIF = "Debe existir un nif ";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se indica que ha habido un fallo en el id del alumno</remarks> 
        public readonly static string ERROR_NO_EXITS_ID = "Fallo en el id del alumno";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un texto de erro cuando un alumno no tiene una empresa</remarks> 
        public readonly static string ERROR_NO_EXITS_EMPRESA = " Debe existir la empresa";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un texto de adveertencia sobre el rango máximo de nif</remarks> 
        public readonly static string TEXT_CONTROL_NIF_RANGE = "El nif no puede tener más de 9 caracteres";
        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un texto de alerta cuando se almacena una lista. </remarks> 
        public readonly static string TEXT_OBTENER_TODOS_DATOS_LISTA = "Visionado de todos los alumnos";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un texto de error cuando la lista no se puede obtener, esta formateado. </remarks>
        public readonly static string ERROR_OBTENER_TODOS_DATOS_LISTA_FORMAT = "Error al obtener la lista de alumnos = {0}";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un texto de alerta cuando se almacena los datos de un alumno. </remarks> 
        public readonly static string TEXT_OBTENER_DATO_ALUMNO_LISTA = "Error al obtener un alumno de la lista = {0}";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un texto de error cuando no se almacena los datos de un alumno, preparado para usarse en un formato</remarks> 
        public readonly static string ERROR_OBTENER_DATO_ALUMNO_LISTA_FORMAT = "Error al obtener un alumno de la lista = {0}";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un texto de error cuando no se puede borrar un alumno, preparado para usarse en un formato</remarks> 
        public readonly static string ERROR_BORRAR_ALUMNO_LISTA_FORMAT = "Error al borrar el alumno = {0}";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un texto de advertencia para saber que debe seleccionar a un alumno para borrarlo</remarks> 
        public readonly static string ADVERTENCIA_BORRAR_ALUMNO = "Selecciona a un alumno";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un texto de error, siendo el titular de los mensajes </remarks> 
        public readonly static string ERROR_DETALLE_TITULO = "Mostrar detalles";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un texto de error, siendo el cuerpo de los mensajes </remarks> 
        public readonly static string ERROR_DETALLE_MENSAJE = "Debes seleccionar antes a un alumno";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un texto de error, usado como boton de salida </remarks> 
        public readonly static string ERROR_DETALLE_BOTON_SALIDA = "👌";   // Imagen bonita y precisa

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un texto de error genérico, preparado para usarse en un formato </remarks> 
        public readonly static string ERROR_MENSAJE = "Error importante = {0}";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un titulo genérico </remarks> 
        public readonly static string TITULO_COMANDO = "Información";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un texto que indica la cantidad de filas han sido actualizada, preparado para usarse en un formato </remarks> 
        public readonly static string TEXT_ACTU_FILA_MENSAJE_FORMAT = "Un total de {0} fila/s se han actualizado";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un texto que indica la cantidad de filas han sido añadidas, preparado para usarse en un formato </remarks> 
        public readonly static string TEXT_AÑAD_FILA_MENSAJE_FORMAT = "Un total de {0} fila/s se han añadidos";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se almacena un texto que indica la cantidad de filas han sido borradas, preparado para usarse en un formato </remarks> 
        public readonly static string TEXT_DELE_FILA_MENSAJE_FORMAT = "Se han borrado un total de {0} filas";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se indica el nombre de la base de datos </remarks> 
        private const string DBFilename = "AguilarUD4T3.db3";

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo SQLiteOpenFlags, donde se indica las las diferentes conexiones del sistema </remarks> 
        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        /// <summary> Atributo de la clase Constantes </summary>
        /// <remarks> Atributo de tipo string, donde se indica la dirección de la base de datos</remarks> 
        public static string DatabasePath {
            get {
                return Path.Combine(FileSystem.AppDataDirectory, DBFilename);
            }
        }
    }
}
