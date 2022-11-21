using JPCadastro.Controllers.Base;
using JPCadastro.Core.Interfaces.UoW;
using JPCadastro.Operacional.Commands.Aluno.AdicionarProfessor;
using JPCadastro.Operacional.Commands.Professor.AtualizarProfessor;
using JPCadastro.Operacional.Commands.Professor.ListarProfessor;
using JPCadastro.Operacional.Commands.Professor.ObterProfessor;
using JPCadastro.Operacional.Commands.Professor.RemoverProfessor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JPCadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : BaseController
    {
        private readonly IMediator _mediator;

        public ProfessorController(IUnitOfWork uow, IMediator mediator) : base(uow)
        {
            _mediator=mediator;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> Adicionar(AdicionarProfessorRequest request)
        {
            return JPPostActionResult(await _mediator.Send(request));
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> Atualizar(AtualizarProfessorRequest request)
        {
            return JPPutActionResult(await _mediator.Send(request));
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            return JPGetActionResult(await _mediator.Send(new ListarProfessorRequest()));
        }

        [HttpGet("obter/{id}")]
        public async Task<IActionResult> Obter(Guid id)
        {
            return JPGetActionResult(await _mediator.Send(new ObterProfessorRequest(id)));
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            return JPDeletActionResult(await _mediator.Send(new RemoverProfessorRequest(id)));
        }
    }
}
