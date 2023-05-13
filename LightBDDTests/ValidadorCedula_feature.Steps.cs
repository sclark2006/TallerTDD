using FluentAssertions;
using LightBDD.Framework;
using LightBDD.XUnit2;
using Proyecto;

namespace LightBDDTests
{
    public partial class ValidadorCedula_feature : FeatureFixture
    {
        ValidadorCedula subject ;
        string cedula;
        bool resultadoEsperado;

        void Dado_un_ValidadorCedula() => 
            subject = new ValidadorCedula();
        void Dada_una_cédula_no_numérico() =>
             cedula = "65165asdfasf @1!";
        void Cuando_se_valida_la_cedula()
        {
            resultadoEsperado = subject.Validar(cedula);
            StepExecution.Current.Comment($"Validando cédula = {cedula}");
        }

        void Entonces_el_resultado_debe_ser_Falso() => 
            resultadoEsperado.Should().BeFalse();
    }
}