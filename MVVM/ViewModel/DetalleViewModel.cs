using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UD4T3.MVVM.ViewModel{
    /// <summary> Clase vistaModelo sobre los detalles de los alumnos </summary>
    /// <remarks>
    /// Clase donde vamos a ser intermediario entre el modelo y su vista.
    /// </remarks>
    public class DetalleViewModel{

        /// <summary> Atributo de la clase DetalleViewModel </summary>
        /// <remarks>
        /// El atributo instancia consigo los métodos getter y setter del atributo.
        /// Se instancia el nombre.
        /// </remarks>
        public string Nombre { get; set; }

        /// <summary> Atributo de la clase DetalleViewModel </summary>
        /// <remarks>
        /// El atributo instancia consigo los métodos getter y setter del atributo.
        /// Se instancia el Nif.
        /// </remarks>
        public string Nif { get; set; }

        /// <summary> Atributo de la clase DetalleViewModel </summary>
        /// <remarks>
        /// El atributo instancia consigo los métodos getter y setter del atributo.
        /// Se instancia el Empresa.
        /// </remarks>
        public string Empresa { get; set; }
    }
}
