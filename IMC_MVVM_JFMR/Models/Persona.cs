using System;
using System.Collections.Generic;
using System.Text;

namespace IMC_MVVM_JFMR.Models
{
    public class Persona
    {
        //Datos numericos necesarios para el calculo
        public double peso { get; set; }
        public double estatura { get; set; }

        //devolver el IMC usando los datos pertenecientes a la persona
        public double IMC()
        {
            return peso / (estatura * estatura);
        }
    }
}
