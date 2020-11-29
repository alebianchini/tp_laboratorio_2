using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public string SetNumero
        {
            set { numero = ValidarNumero(value); }
        }

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(string strNumero)
        {
            double.TryParse(strNumero, out this.numero);
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        private static double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double retorno))
            {
                return retorno;
            }
            return 0;
        }

        private static bool EsBinario(string binario)
        {
            return Regex.IsMatch(binario, "^[01]+$");
        }

        public static string DecimalBinario(double numero)
        {
            string ret;
            int numAux;

            if (ValidarNumero(numero.ToString()) != 0)
            {
                numAux = (int)numero;
                ret = Convert.ToString(numAux, 2);
            }
            else
            {
                ret = "Valor invalido";
            }
            return ret;
        }

        public static string DecimalBinario(string numero)
        {
            double.TryParse(numero, out double numAux);
            return DecimalBinario(numAux);
        }

        public static string BinarioDecimal(string binario)
        {
            string ret;
            int numAux;

            if (EsBinario(binario))
            {
                numAux = Convert.ToInt32(binario, 2);
                ret = numAux.ToString();
            }
            else
            {
                ret = "Valor invalido";
            }
            return ret;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero + n2.numero;
            return resultado;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero - n2.numero;
            return resultado;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero * n2.numero;
            return resultado;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;
            
            if(n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            else
            {
                resultado = double.MinValue;
            }
            return resultado;
        }

    }
}
