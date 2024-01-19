using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UD4T3.MVVM.Model;

namespace UD4T3.MVVM.ViewModel {
    /// <summary> Clase vistaModelo sobre los datos de los alumnos </summary>
    /// <remarks>
    /// Clase donde vamos a ser intermediario entre el modelo y su vista de los alumnos.
    /// </remarks>
    [AddINotifyPropertyChangedInterface]
    public class AlumnoViewModel {
        /// <summary> Atributo de la clase AlumnoViewModel </summary>
        /// <remarks>
        /// El atributo instancia consigo los métodos getter y setter.
        /// Se establece una lista de alumnos
        /// </remarks>
        public List<Alumno> Alumnos { get; set; }
        /// <summary> Atributo de la clase AlumnoViewModel </summary>
        /// <remarks>
        /// El atributo instancia consigo los métodos getter y setter.
        /// Se establece el alumno que esta siendo observado en un instante de uso.
        /// </remarks>
        public Alumno AlumnoActual { get; set; }
        /// <summary> Atributo de la clase AlumnoViewModel </summary>
        /// <remarks>
        /// El atributo instancia consigo los métodos getter y setter..
        /// Se establece el comando de creación y actualización de un alumno.
        /// </remarks>
        public ICommand CrearOActualizarAlumno { get; set; }
        /// <summary> Atributo de la clase AlumnoViewModel </summary>
        /// <remarks>
        /// El atributo instancia consigo los métodos getter y setter..
        /// Se establece el comando de borrado de un alumno.
        /// </remarks>
        public ICommand BorrarAlumno { get; set; }
        /// <summary> Atributo de la clase AlumnoViewModel </summary>
        /// <remarks>
        /// El atributo instancia consigo los métodos getter y setter..
        /// Se establece el comando de tratar los datos de un alumno y instanciar que usuario es actual.
        /// </remarks>
        public ICommand DetalleAlumno { get; set; }
        /// <summary> Constructor de la clase AlumnoViewModel </summary>
        /// <remarks>
        /// Se instancia el atributo AlumnoActual, además se construyen los comandos
        /// de creación y actualización, de borrado y de detalle.
        /// </remarks>
        public AlumnoViewModel() {
            Refresh();
            AlumnoActual = new Alumno();
            ConstruirComandoCrearActualizar();
            ConstruirComandoBorrar();
            ConstruirComandoDetalle();
        }
        /// <summary> Método para construir el comando de creación y actualización</summary>
        /// <remarks> 
        /// Con el método creamos un comando para actualizar o añadir un usuario,
        /// también crea un mensaje para saber que que ha sido creado/actualizado el usuario bien o no.
        /// </remarks>
        private void ConstruirComandoCrearActualizar() {
            CrearOActualizarAlumno = new Command(() => {
                App.AlumnoRepository.AñadirOActualizar(AlumnoActual); // Llamamos al método para poder conectarnos a la base de datos.
                Mensaje(Constantes.TITULO_COMANDO, App.AlumnoRepository.StatusMessages);
                AlumnoActual = new Alumno(); // Cuando ya ha sido actualizado o añadido el alumno, los datos del anterior Alumno actual ya no hace falta.
                Refresh();                   // Recargamos los valores de la página para poder ver la lista de alumnos, sino lo hiciéramos no se nos actualizaría a tiempo real.         
            });
        }
        /// <summary> Método para construir el comando de borrado</summary>
        /// <remarks> 
        /// Con el método creamos un comando para borrar un usuario,
        /// también crea un mensaje para saber que que ha sido borrado el usuario bien o no.
        /// </remarks>
        private void ConstruirComandoBorrar() {
            BorrarAlumno = new Command(() => {
                if (AlumnoActual!=null) {
                    App.AlumnoRepository.Delete(AlumnoActual.ID);   // Llamamos al método para poder conectarnos a la base de datos y borrar un alumno
                    Mensaje(Constantes.TITULO_COMANDO, App.AlumnoRepository.StatusMessages);

                } else {
                    Mensaje(Constantes.TITULO_COMANDO, String.Format(Constantes.ERROR_BORRAR_ALUMNO_LISTA_FORMAT, Constantes.ADVERTENCIA_BORRAR_ALUMNO));
                }
                AlumnoActual = new Alumno();   // Cuando ya ha sido actualizado o añadido el alumno, los datos del anterior Alumno actual ya no hace falta.
                Refresh();                       // Recargamos los valores de la página para poder ver la lista de alumnos, sino lo hiciéramos no se nos actualizaría a tiempo real.         
            });
        }
        /// <summary> Método para construir el comando de detalle</summary>
        /// <remarks> 
        /// Con el método creamos un comando para instanciar el usuarioActual,
        /// </remarks>
        private void ConstruirComandoDetalle() {
            if (AlumnoActual!=null) {
                DetalleAlumno = new Command(() => {
                    if (AlumnoActual != null) {
                        AlumnoActual = App.AlumnoRepository.Get(AlumnoActual.ID);
                    } else {
                        AlumnoActual = null;    // Tengo que hacer esto para evitar que falle el sistema al darle 2 veces al botn de detalle
                    } 
                    Refresh();          // Refrescamos la pagina.
                });
            } else {
                AlumnoActual = new Alumno();
            }
            
        }

        /// <summary> Método actualizar lista de los alumnos</summary>
        /// <remarks> 
        /// Con el método podemos volver a cargar la lista de los alumnos, la lista vendrá dada de la base de datos.
        /// </remarks>
        private void Refresh() {
            Alumnos = App.AlumnoRepository.GetAll(); // Nos conectamos a la base de datos, y obtenemos a todos los alumnos que estén registrados
        }
        /// <summary> Método mostrar mensajes</summary>
        /// <remarks> 
        /// Con el método podremos crear mensajes personalizados para que el usuario este atento a las advertencias. 
        /// </remarks>
        /// <param name="title">Titulo del mensaje</param>
        /// <param name="message">Cuerpo del mensaje</param>
        private void Mensaje(string title, string message) {
            App.Current.MainPage.DisplayAlert(title, message, "Ok"); // Hacemos una alerta personalizada.
        }
    }
}
