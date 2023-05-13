using FluentAssertions;
using Proyecto;

namespace TestNUnit;

public class ValidarCedulaTests
{
    ValidadorCedula subject;
    bool resultadoEsperado;

    public ValidarCedulaTests()
    {
        subject = new ValidadorCedula();
    }

    [Fact]
    public void ValidarCedula_debe_retornar_False_Cuando_la_cedula_digitada_no_sea_numérica()
    {
        //ARRANGE
        var cedula = "65165asdfasf @1!";

        //ACT

        resultadoEsperado = subject.Validar(cedula);
        //ASSERT

        resultadoEsperado.Should().BeFalse();
    }

    [Fact]
    public void ValidarCedula_debe_retornar_False_Cuando_la_longitud_de_la_cedula_sea_diferente_de_11()
    {
        //ARRANGE
        var cedula = "65165165";

        //ACT

        resultadoEsperado = subject.Validar(cedula);
        //ASSERT

        resultadoEsperado.Should().BeFalse();
    }

    [Fact]
    public void ValidarCedula_debe_retornar_False_Cuando_la_cedula_sea_nula_o_vacía()
    {
        //ARRANGE
        string cedula = null;

        //ACT

        resultadoEsperado = subject.Validar(cedula);
        //ASSERT

        resultadoEsperado.Should().BeFalse();
    }

    [Fact]
    public void ValidarCedula_debe_retornar_True_Cuando_el_digito_verificador_de_la_cedula_sea_correcto()
    {
        //ARRANGE
        string cedula = "40214210565";

        //ACT

        resultadoEsperado = subject.Validar(cedula);
        //ASSERT

        resultadoEsperado.Should().BeTrue();
    }

    [Fact]
    public void ValidarCedula_debe_retornar_False_Cuando_el_digito_verificador_de_la_cedula_sea_incorrecto()
    {
        //ARRANGE
        string cedula = "00112717651";

        //ACT

        resultadoEsperado = subject.Validar(cedula);
        //ASSERT

        resultadoEsperado.Should().BeFalse();
    }
}