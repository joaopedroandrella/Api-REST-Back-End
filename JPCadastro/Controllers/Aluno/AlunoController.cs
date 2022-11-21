using JPCadastro.Controllers.Base;
using JPCadastro.Core.Interfaces.UoW;
using JPCadastro.Operacional.Commands.Aluno.AdicionarAluno;
using JPCadastro.Operacional.Commands.Aluno.AtualizarAluno;
using JPCadastro.Operacional.Commands.Aluno.ListarAluno;
using JPCadastro.Operacional.Commands.Aluno.ObterAluno;
using JPCadastro.Operacional.Commands.Aluno.RemoverAluno;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JPCadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : BaseController
    {
        private readonly IMediator _mediator;

        public AlunoController(IUnitOfWork uow, IMediator mediator) : base(uow)
        {
            _mediator=mediator;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> Adicionar(AdicionarAlunoRequest request)
        {
            return JPPostActionResult(await _mediator.Send(request));
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> Atualizar(AtualizarAlunoRequest request)
        {
            return JPPutActionResult(await _mediator.Send(request));
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            return JPGetActionResult(await _mediator.Send(new ListarAlunoRequest()));
        }

        [HttpGet("obter/{id}")]
        public async Task<IActionResult> Obter(Guid id)
        {
            return JPGetActionResult(await _mediator.Send(new ObterAlunoRequest(id)));
        }

        [HttpDelete("remover/{id}")]    
        public async Task<IActionResult> Remover(Guid id)
        {
            return JPDeletActionResult(await _mediator.Send(new RemoverAlunoRequest(id)));
        }
    }
}
