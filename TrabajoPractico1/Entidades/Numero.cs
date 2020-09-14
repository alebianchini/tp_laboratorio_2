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
        private double num;

        public string Num
        {
            get { return num.ToString(); }
            set { num = ValidarNumero(value); }
        }

        public Numero()
        {
            this.num = 0;
        }

        public Numero(string numero)
        {
            double.TryParse(numero, out this.num);
        }

        public Numero(double numero)
        {
            this.num = numero;
        }

        private static double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double retorno))
            {
                return retorno;
            }
            else
            {
                return 0;
            }
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

            resultado = n1.num + n2.num;
            return resultado;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.num - n2.num;
            return resultado;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.num * n2.num;
            return resultado;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;
            
            if(n2.num != 0)
            {
            resultado = n1.num / n2.num;
            }
            else
            {
                resultado = double.MinValue;
            }
            return resultado;
        }

    }
}
