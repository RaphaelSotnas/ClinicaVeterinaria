using System.ComponentModel;

namespace ClinicaVeterinaria.Web.Enum
{
    public enum CategoriaAnimal
    {
        [Description("Cachorro")]
        Cachorro = 1,

        [Description("Gato")]
        Gato = 2,

        [Description("Hamster")]
        Hamster = 3
    }
}
