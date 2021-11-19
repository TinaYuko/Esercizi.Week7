using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_3
{
    class NumeroComplesso
    {
        //a+ib
        public double ParteReale { get; set; }
        public double ParteImmaginaria { get; set; }

        public NumeroComplesso Divisione(NumeroComplesso value)
        {
            //a+ib
            //c+id
            //((ac+bd)/(c^2+d^2)) + i((bc - ad)/(c^2+d^2))

            //ci calcoliamo prima il denominatore
            double denom = Math.Pow(value.ParteReale, 2) + Math.Pow(value.ParteImmaginaria, 2);
            if (denom == 0)
            {
                //Custom eccezione
                //Throw NumeroComplessoException
                throw new NumeroComplessoException("Non è possibile realizzare questa divisione. Denominatore non può essere zero!")
                {
                    PrimoOperatore = this,
                    SecondoOperatore = value
                };

            }

                //((ac+bd)/denom
                double parteRealeRisultato = ((this.ParteReale * value.ParteReale) + (this.ParteImmaginaria * value.ParteImmaginaria)) / denom;
                //i((bc - ad)/denom
                double parteImmaginariaRisultato = ((this.ParteImmaginaria * value.ParteReale) - (this.ParteReale * value.ParteImmaginaria)) / denom;

                return new NumeroComplesso { ParteReale = parteRealeRisultato, ParteImmaginaria = parteImmaginariaRisultato };
            
            
        }
        public override string ToString()
        {
            if (ParteImmaginaria>0)
            {
                return $"{ParteReale} + i{ParteImmaginaria}";
            }
            else
            {
                return $"{ParteReale} - i{Math.Abs(ParteImmaginaria)}";
            }
        }
    }
}
