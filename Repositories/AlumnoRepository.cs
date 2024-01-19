using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD4T3.MVVM.Model;
using static SQLite.SQLite3;

namespace UD4T3.Repositories {
    /// <summary> Clase repositorio de los Alumnos </summary>
    /// <remarks>
    /// Clase donde se va a crear la conexión de la base de datos interna,
    /// además de controlar y ser el que haga las peticiones a la base de datos.
    /// </remarks>
    public class AlumnoRepository {
        /// <summary> Atributo de la clase repositorio AlumnoRepository </summary>
        /// <remarks>
        /// Se establece un atributo que nos será el conector con la base de datos interno de la aplicación.
        /// </remarks>
        private SQLiteConnection connection;
        /// <summary> Atributo de la clase repositorio AlumnoRepository </summary>
        /// <remarks>
        /// Se establece un atributo que nos almacenara los mensajes que queremos almacenar.
        /// </remarks>
        public string StatusMessages { get; private set; } // Tiene privado el set, porque solo queremos que se creen en esta clase, pero que lo vena el resto.
        /// <summary> Constructor de la clase AlumnoRepository </summary>
        /// <remarks>
        /// Se instancia el atributo connection, para poder conectarnos a la base de datos.
        /// También crearemos la tabla de alumnos.
        /// </remarks>
        public AlumnoRepository() {
            connection = new SQLiteConnection(Constantes.DatabasePath, Constantes.Flags);
            connection.CreateTable<Alumno>();
        }
        /// <summary> Método para añadir o actualizar</summary>
        /// <remarks> El método añade o actualiza los datos de un alumno, y nos indica cuantas filas han sido cambiadas/añadidas.</remarks>
        /// <param name="alumno">El alumno que va ha ser modificado o actualizado</param>
        public void AñadirOActualizar(Alumno alumno) {
            if (alumno != null) {
                try {
                    if (alumno.Nif != null && alumno.Empresa!=null && alumno.Nif != "" && alumno.Empresa != "") { // Compruebo primero si es nulo, porque si voy a introducir un nuevo alumno,y compruebo si es un string vacío por si al actualizarlo lo he borrado
                        if (alumno.Nif.Length<=9) {
                            if (alumno.ID != 0) {
                                StatusMessages = string.Format(Constantes.TEXT_ACTU_FILA_MENSAJE_FORMAT, connection.Update(alumno)); // En el este caso estaríamos actualizando al alumno
                            } else {
                                StatusMessages = string.Format(Constantes.TEXT_AÑAD_FILA_MENSAJE_FORMAT, connection.Insert(alumno));  // En el este caso estaríamos añadiendo al alumno          
                            }
                        } else {
                            StatusMessages = string.Format(Constantes.ERROR_MENSAJE,Constantes.TEXT_CONTROL_NIF_RANGE);
                        }
                    } else {
                        StatusMessages = string.Format(Constantes.ERROR_MENSAJE, ((alumno.Nif == null)|| (alumno.Nif=="") ? Constantes.ERROR_NO_EXITS_NIF: "") + ((alumno.Empresa == null) || (alumno.Empresa == "") ? Constantes.ERROR_NO_EXITS_EMPRESA : ""));
                    }
                } catch (Exception ex) {
                    StatusMessages = string.Format(Constantes.ERROR_MENSAJE, ex.Message);
                }
            } else {
                StatusMessages = string.Format(Constantes.ERROR_MENSAJE, Constantes.ERROR_NO_EXITS_ID);
            }
        }
        /// <summary> Método para pedir todos los alumnos</summary>
        /// <remarks> El método nos devuelve la lista de todos los alumnos que estén alojado en el servidor.</remarks>
        /// <returns> Retorna una lista de alumnos, pero en el caso fallo devolverá un null</returns>
        public List<Alumno> GetAll() {
            List<Alumno> list = null; // Creamos una lista
            try {
                list = connection.Table<Alumno>().ToList(); // Nos conectamos a la base de datos y sacamos una lista con todos los alumnos
                StatusMessages = Constantes.TEXT_OBTENER_TODOS_DATOS_LISTA;
            } catch (Exception ex) {
                StatusMessages = string.Format(Constantes.ERROR_OBTENER_TODOS_DATOS_LISTA_FORMAT, ex.Message);
            }
            return list;        // Cuidado que puede ser nulo
        }
        /// <summary> Método para pedir un alumno</summary>
        /// <remarks> 
        /// El método nos devuelve la un alumno de todos los que estén alojado en el servidor. 
        /// Que deberá coincidir con el id introducido por el argumento
        /// </remarks>
        /// <returns> Retorna una lista de alumnos, pero en el caso fallo devolverá un null</returns>
        /// <param name="id">Id del usuario que vamos a buscar en la base de datos</param>
        public Alumno Get(int id) {
            Alumno alumno = null;
            try {
              
                alumno = connection.Table<Alumno>().FirstOrDefault(t => t.ID == id); // Buscamos por el id introducido por el argumento
                StatusMessages = Constantes.TEXT_OBTENER_DATO_ALUMNO_LISTA;
            } catch (Exception ex) {
                StatusMessages = string.Format(Constantes.ERROR_OBTENER_DATO_ALUMNO_LISTA_FORMAT, ex.Message);
                alumno= new Alumno();
            }
            return alumno;
        }
        /// <summary> Método para borrar un alumno</summary>
        /// <remarks> El método nos borrar un alumno cuyo id introducido por parámetro exista.</remarks>
        /// <param name="id">Id del usuario que vamos a buscar en la base de datos</param>
        public void Delete(int id) {
            try {
                StatusMessages = string.Format(Constantes.TEXT_DELE_FILA_MENSAJE_FORMAT, connection.Delete(Get(id))); // Con el delete borraremos al usuario definitivamente de la base de datos
            } catch (Exception ex) {
                StatusMessages = string.Format(Constantes.ERROR_BORRAR_ALUMNO_LISTA_FORMAT, Constantes.ADVERTENCIA_BORRAR_ALUMNO);
            }
        }
    }
}
