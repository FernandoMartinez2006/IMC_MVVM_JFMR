using IMC_MVVM_JFMR.ViewModels;

namespace IMC_MVVM_JFMR.Views;

public partial class imcPage : ContentPage
{
    public imcPage()
    {
        // Crea los controles definidos en el XAML.
        InitializeComponent();
        // Conecta la pantalla con sus datos y comandos.
        BindingContext = new IMCViewModel();
    }
}