using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using TestsLightBDD;

namespace LightBDDTests;

[Label("FEAT-1")]
[FeatureDescription(
@"In order to 
As a
I want to ")]

public partial class ValidadorCedula_feature
{
    [Label("SCENARIO-1")]
    [Scenario]
    public void Cedula_no_numérica()
    {
        Runner.RunScenario(
            Dado_un_ValidadorCedula,
            Dada_una_cédula_no_numérico,
            Cuando_se_valida_la_cedula,
            Entonces_el_resultado_debe_ser_Falso);
    }

    /*[Label("SCENARIO-1")]
    [Scenario]
    public void Template_extended_scenario()
    {
        Runner.RunScenario(
            _ => Given_template_method(),
            _ => When_template_method(),
            _ => Then_template_method());
    }*/
}