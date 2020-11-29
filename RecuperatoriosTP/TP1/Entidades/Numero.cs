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

        /// <summary>
        /// Setea el atributo numero del Numero, luego de validar que sea valido.
        /// </summary>
        public string SetNumero
        {
            set { numero = ValidarNumero(value); }
        }

        /// <summary>
        /// Constructor por defecto de un Numero, setea su valor en 0.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Construye un numero asignandole el string recibido por parametro como su valor en caso de que sea valido.
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            double.TryParse(strNumero, out this.numero);
        }

        /// <summary>
        /// Construye un numero asignandole el double recibido por parametro como su valor.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Valida que el string recibido sea un double valido y lo transforma a double
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Retorna el valor recibido por parametro en formato double en caso de ser valido. Caso contrario retorna 0.</returns>
        private static double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double retorno))
            {
                return retorno;
            }
            return 0;
        }

        /// <summary>
        /// Valida que el string recibido sea un numero Binario, osea, este compuesto por 0 y 1.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>retorna true en caso de que sea binario. False en caso contrario.</returns>
        private static bool EsBinario(string binario)
        {
            return Regex.IsMatch(binario, "^[01]+$");
        }

        /// <summary>
        /// Transforma un numero decimal a Binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna un string con el valor transformado en Binario. Caso contrario retorna "Valor invalido".</returns>
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

        /// <summary>
        /// Transforma un numero decimal a Binario, recibiendo el numero como string.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna un string con el valor transformado en Binario. Caso contrario retorna "Valor invalido"</returns>
        public static string DecimalBinario(string numero)
        {
            if(double.TryParse(numero, out double numAux))
            {
                return DecimalBinario(numAux);
            }
            return "Valor invalido";
        }

        /// <summary>
        /// Transforma un numero binario en decimal, recibiendo el numero como string.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Retorna un string con el valor transformado en Decimal. Caso contrario retorna "Valor invalido"</returns>
        public static string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            {
                return Convert.ToInt32(binario, 2).ToString();
            }
            return "Valor invalido";
        }

        /// <summary>
        /// Realiza la suma entre dos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna su resultado en formato double.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Realiza la resta entre dos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna su resultado en formato double.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Realiza la multiplicacion entre dos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna su resultado en formato double.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Realiza la division entre dos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna su resultado en formato double. En caso de que el numero divisor sea 0, retornara double.MinValue.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            return double.MinValue;
        }
    }
}
