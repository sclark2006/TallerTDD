using System.Globalization;
using System.Text.RegularExpressions;

namespace Proyecto
{
    public class ValidadorCedula
    {
        private const int LONGITUD_CEDULA = 11;
        private const int ULTIMO_DIGITO = LONGITUD_CEDULA - 1;
        private const int DIGITOS_MUNICIPIO = 3;
        private const string DIGITOS_PARIDAD = "1212121212";
        private const int MAXIMO_VALOR_DECIMAL = 9;

        public bool Validar(string cedula)
        {
            //Valida nulidad
            if (cedula == null) return false;
            
            cedula = SoloDigitos(cedula);
            
            //Valida longitud
            if (cedula.Length != LONGITUD_CEDULA) return false;
            
            int[] digitos = cedula.Select(d => int.Parse(d.ToString())).ToArray();
            
            //Valida municipios
            var municipio = digitos.Take(DIGITOS_MUNICIPIO).Sum();
            if(municipio == 0) return false;

            //Calcula el digito verificador
            int suma = 0;
            var verificador = digitos[ULTIMO_DIGITO];
            var factoresParidad = DIGITOS_PARIDAD.Select(d => int.Parse(d.ToString())).ToArray();
            for (int indice = 0; indice < ULTIMO_DIGITO; indice++)
            {
                var digito = digitos[indice];
                var paridad = digito * factoresParidad[indice];
                if (paridad > MAXIMO_VALOR_DECIMAL)
                {
                    paridad = paridad.ToString().Select(d => int.Parse(d.ToString())).Sum();
                    //var res1 = paridad.ToString().ToArray();
                    //paridad = Convert.ToInt32(res1[0]) + Convert.ToInt32(res1[1]);
                }
                suma += paridad;
            }
            var resultado = ((ULTIMO_DIGITO - (suma % ULTIMO_DIGITO)) % ULTIMO_DIGITO);
            return resultado == verificador;
        }

        private string SoloDigitos(string value)
        {
            return Regex.Replace(value, @"\D+", string.Empty);
        }
    }
}