using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Entities.Aluno
{
    public static class AlunoContract
    {
        public static void AdicionarAtualizarAlunoContract(this AlunoEntity alunoEntity)
        {
            new AddNotifications<AlunoEntity>(alunoEntity)
                .IfNullOrInvalidLength(p => p.Cpf, 1, 11)
                .IfNullOrInvalidLength(p => p.Nome, 1, 50)
                .IfNullOrInvalidLength(p => p.Telefone, 1, 20);
        }
    }
}
