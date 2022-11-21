using System.ComponentModel;

namespace JPCadastro.Operacional.Enumeradores
{
    public enum Periodo
    {
        [Description("Manhã")]
        Manha,
        [Description("Tarde")]
        Tarde,
        [Description("Noite")]
        Noite,
        [Description("Integral")]
        Integral
    }
}
