using JPCadastro.Controllers.Base;
using JPCadastro.Core.Interfaces.UoW;
using JPCadastro.Operacional.Commands.Matricula.AdicionarMatricula;
using JPCadastro.Operacional.Commands.Matricula.AtualizarMatricula;
using JPCadastro.Operacional.Commands.Matricula.ListarMatricula;
using JPCadastro.Operacional.Commands.Matricula.ObterMatricula;
using JPCadastro.Operacional.Commands.Matricula.RemoverMatricula;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JPCadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : BaseController
    {
        private readonly IMediator _mediator;

        public MatriculaController(IUnitOfWork uow, IMediator mediator) : base(uow)
        {
            _mediator=mediator;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> Adicionar(AdicionarMatriculaRequest request)
        {
            return JPPostActionResult(await _mediator.Send(request));
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            return JPGetActionResult(await _mediator.Send(new ListarMatriculaRequest()));
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> Atualizar(AtualizarMatriculaRequest request)
        {
            return JPPutActionResult(await _mediator.Send(request));
        }

        [HttpGet("obter/{id}")]
        public async Task<IActionResult> Obter(Guid id)
        {
            return JPGetActionResult(await _mediator.Send(new ObterMatriculaRequest(id)));
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            return JPDeletActionResult(await _mediator.Send(new RemoverMatriculaRequest(id)));
        }
    }
}