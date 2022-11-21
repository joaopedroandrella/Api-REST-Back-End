using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Professor.ListarProfessor
{
    public class ListarProfessorHandler : Notifiable,
        IRequestHandler<ListarProfessorRequest, CommandResponse>
    {
        private readonly IRepositoryProfessor _repositoryProfessor;

        public ListarProfessorHandler(IRepositoryProfessor repositoryProfessor)
        {
            _repositoryProfessor=repositoryProfessor;
        }

        public Task<CommandResponse> Handle(ListarProfessorRequest request,
            CancellationToken cancellationToken)
        {
            //TESTANDO SE O PROFESSOR JÁ ESTA CADASTRADO
            var colecaoProfessor = _repositoryProfessor.ListarSemRastreamento();

            return Task.FromResult(new CommandResponse(colecaoProfessor.Select(p => new ListarProfessorResponse
            {
                Id = p.Id,
                Cpf = p.Cpf,
                Nome = p.Nome,
                Telefone = p.Telefone
            }), this)); ;
        }
    }
}
