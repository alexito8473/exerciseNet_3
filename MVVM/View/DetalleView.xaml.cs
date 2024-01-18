using UD4T3.MVVM.ViewModel;

namespace UD4T3.MVVM.View;
/// <summary> Clase donde se realizan las operaciones necesarias para el control de la página de detalles </summary>
/// <remarks>
/// En esta clase posee y hace los controles necesarios para el uso correcto de la pagina en cuestión. 
/// </remarks> 
public partial class DetalleView : ContentPage{

    /// <summary> Constructor de la clase DetalleView </summary>
    /// <remarks> Constructor que nos inicializa los componentes de la vista, 
    /// además de instanciar los parámetros que les sea necesario 
    /// </remarks>
    public DetalleView()
	{
		InitializeComponent();
        BindingContext = new DetalleViewModel();    // No borrar, es necesario para que se vean los datos.
    }
}