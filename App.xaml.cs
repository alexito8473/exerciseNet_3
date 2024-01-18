using UD4T3.MVVM.View;
using UD4T3.Repositories;

namespace UD4T3 {
    /// <summary> Clase App </summary>
    /// <remarks>
    /// Clase donde vamos a ser intermediario entre el modelo y su vista de los alumnos.
    /// </remarks>
    public partial class App : Application {
        /// <summary> Atributo de la clase App </summary>
        /// <remarks> Atributo de tipo AlumnoRepository, se establece el repostorio conexión
        /// con la base de datos
        /// </remarks> 
        public static AlumnoRepository AlumnoRepository { get; set; }

        /// <summary> Constructor de la clase App </summary>
        /// <remarks> Constructor que nos inicializa los componentes de la vista, además de instanciar los parámetros que les sea necesario </remarks>
        ///<param name="alumnoRepository"> Reposotorio actual del sistema</param>
        public App(AlumnoRepository alumnoRepository) {
            InitializeComponent();
            if (alumnoRepository != null) {                  // Hago esto para revisar que no sea nulo
                AlumnoRepository = alumnoRepository;
            }
            MainPage = new NavigationPage(new AlumnoView()); // Uso el NavegationPage, para poder crear pantallas 
        }
    }
}
