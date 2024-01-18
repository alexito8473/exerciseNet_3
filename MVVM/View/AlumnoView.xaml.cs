using UD4T3.MVVM.ViewModel;
///////////////////////////////////////////
// Tarea: UD4T2
// Alumno/a: Aguilar Alba Alejandro
// Curso: 2023/2024
///////////////////////////////////////////
/// <summary> Clase donde se realizan las operaciones necesarias para el control de la página principal </summary>
/// <remarks>
/// En esta clase posee y hace los controles necesarios para el uso correcto de la pagina en cuestión. 
/// </remarks>  
namespace UD4T3.MVVM.View;
/// <summary> Clase vista del Alumno </summary>
/// <remarks>
/// Aquí tenemos el la clase que esta conectada directamente al View de la aplicación, para poder realizarle funciones y poder cambiar el estado de la aplicación
/// </remarks>  
public partial class AlumnoView : ContentPage{

    /// <summary> Constructor de la clase AlumnoView </summary>
    /// <remarks> Constructor que nos inicializa los componentes de la vista, además de instanciar los parámetros que les sea necesario </remarks>
    public AlumnoView()
	{
		InitializeComponent();

		BindingContext = new AlumnoViewModel();             // Importante, sin el no podremos utilizar los métodos de añadir, borrar y detallar al alumno. 
	}
    /// <summary> Método para mostrar los detalles del los alumnos</summary>
    /// <remarks> 
    /// Método que crea una nueva ventana cuando es pulsado el botón de detalle, 
    /// pero primero deberemos de haber seleccionado al Alumno en cuestión.
    /// </remarks>
    /// <param name="sender"> Objeto de la acción</param>
    /// <param name=" e"> Tipo del evento</param>
    private void Detalle_Clicked(object sender, EventArgs e) {
        AlumnoViewModel textoSalida = (AlumnoViewModel)BindingContext; // Gracias ha esto podemos obtener los datos que estamos utilizando en la aplicación.
        if (textoSalida.AlumnoActual != null) {                        // Si no comprobamos que es distinto a nulo, produce error porque el alumno no ha sido marcado con anterioridad
            Navigation.PushAsync(new DetalleView {                     // Crearemos en pila otra vista, que se mostrara los datos del alumno actula
                BindingContext = new DetalleViewModel { Nombre = textoSalida.AlumnoActual.Nombre, Nif = textoSalida.AlumnoActual.Nif, Empresa = textoSalida.AlumnoActual.Empresa }
            });
        } else {
            App.Current.MainPage.DisplayAlert(Constantes.ERROR_DETALLE_TITULO,Constantes.ERROR_DETALLE_MENSAJE,Constantes.ERROR_DETALLE_BOTON_SALIDA); // En el caso que de error, porque el alumno no ha sido seleccionado, mostraremos un mensaje de error para que se sepa porque ha dado fallo.
        }

    }
}