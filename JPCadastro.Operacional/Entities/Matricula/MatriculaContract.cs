using JPCadastro.Operacional.Entities.Matricula;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Entities.Curso
{
    public static class MatriculaContract
    {
        public static void AdicionarAtualizarMatriculaContract(this MatriculaEntity matriculaEntity)
        {
            new AddNotifications<MatriculaEntity>(matriculaEntity);
        }
    }
}
