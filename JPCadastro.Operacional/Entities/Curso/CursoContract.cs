using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Entities.Curso
{
    public static class CursoContract
    {
        public static void AdicionarAtualizarCursoContract(this CursoEntity cursoEntity)
        {
            new AddNotifications<CursoEntity>(cursoEntity)
                .IfNullOrInvalidLength(p => p.Nome, 1, 50);
        }
    }
}
