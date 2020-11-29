using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza una operacion entre los dos numeros que recibe por parametro, condicionada por el operador que recibe.
        /// </summary>
        /// <param name="num1">primer numero de la operacion</param>
        /// <param name="num2">segundo numero de la operacion</param>
        /// <param name="operador">operador</param>
        /// <returns>Retorna el valor de la operacion realizada.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            string operAux;

            operAux = ValidarOperador(Convert.ToChar(operador));

            switch (operAux)
            {
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                default:
                    resultado = num1 + num2;
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Valida que el operador recibido como tipo char sea un operador valido.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Retorna el operador recibido en formato string en caso de ser valido. Caso contrario retorna "+"</returns>
        private static string ValidarOperador(char operador)
        {
            string retorno = "+";

            if (operador == '-' || operador == '/' || operador == '*')
            {
                retorno = operador.ToString();
            }

            return retorno;
        }
    }
}
