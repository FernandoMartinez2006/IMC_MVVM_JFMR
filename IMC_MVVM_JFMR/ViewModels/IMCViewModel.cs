using IMC_MVVM_JFMR.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IMC_MVVM_JFMR.ViewModels
{
    public class IMCViewModel : INotifyPropertyChanged
    {
        // los entry capturan texto, incluso si son numeros
        public string Ptexto { get; set; } = "";
        public string Etexto { get; set; } = "";
        private string resultado = " ingresa tus datos";
        public string Resultado
        {
            get { return resultado; }
            set
            {
                resultado = value;
                //notificamos al label
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Resultado)));
            }
        }
        //El Boton usará este comando mediante binding
        public ICommand CalcularIMCCommand { get; }
        public IMCViewModel()
        {
            //al ejecutar el comando se llama a calcular
            CalcularIMCCommand = new Command(Calcular);
        }
        //Binding Escucha el evento
        public event PropertyChangedEventHandler? PropertyChanged;
        public void Calcular()
        {
            //validamos cada campo por separado
            double peso;
            bool pesoValido = double.TryParse(Ptexto, out peso);
            if (pesoValido == false || !double.IsFinite(peso) || peso <= 0)
            {
                Resultado = "Escribe un peso valido mayor que 0";
                return; // termina sin calcular

            }
            double estatura;
            bool estaturaValido = double.TryParse(Etexto, out estatura);
            if (estaturaValido == false || !double.IsFinite(estatura) || estatura <= 0)
            {
                Resultado = "Escribe una estatura valida mayor que 0";
                return; // termina sin calcular
            }
            // Creamos el modelo y le asignamos los datos.
            Persona persona = new Persona();
            persona.peso = peso;
            persona.estatura = estatura;
            // El modelo realiza la operación.
            double imc = persona.IMC();
            // Evitamos mostrar un resultado numérico inválido.
            if (!double.IsFinite(imc))
            {
                Resultado = "Revisa el peso y la estatura.";
                return;
            }
            // F2 muestra el número con dos decimales.
            Resultado = "Tu IMC es: " + imc.ToString("F2");
        }
    }
}