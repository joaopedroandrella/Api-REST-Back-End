using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Entities.Professor
{
    public static class ProfessorContract
    {
        public static void AdicionarAtualizarProfessorContract(this ProfessorEntity professorEntity)
        {
            new AddNotifications<ProfessorEntity>(professorEntity)
                .IfNullOrInvalidLength(p => p.Nome, 1, 50)
                .IfNullOrInvalidLength(p => p.Telefone, 1, 20);
        }
    }
}
