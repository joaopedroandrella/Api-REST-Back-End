using prmToolkit.NotificationPattern;

namespace JPCadastro.Core.Entities
{
    public abstract class EntityBase<TId> : Notifiable
    {
        public TId Id { get; protected set; }
    }
}
