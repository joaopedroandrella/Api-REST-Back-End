using prmToolkit.NotificationPattern;

namespace JPCadastro.Core.DTOs
{
    public class CommandResponse
    {
        public bool Sucesso { get; }
        public object Dados { get; }
        public IEnumerable<Notification> Notificacoes { get; }

        public CommandResponse(object dados, INotifiable notificacoes)
        {
            Sucesso=notificacoes.IsValid();
            Dados=notificacoes.IsValid() ? dados : null;
            Notificacoes=notificacoes.Notifications;
        }

        public CommandResponse(INotifiable notificacoes)
        {
            Sucesso=false;
            Dados=null;
            Notificacoes=notificacoes.Notifications;
        }
    }
}
