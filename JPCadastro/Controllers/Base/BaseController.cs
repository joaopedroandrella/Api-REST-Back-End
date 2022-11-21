using JPCadastro.Core.DTOs;
using JPCadastro.Core.Interfaces.UoW;
using Microsoft.AspNetCore.Mvc;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        protected BaseController(IUnitOfWork uow)
        {
            _uow=uow;
        }

        //Adicionar (POST)
        protected IActionResult JPPostActionResult(CommandResponse commandResponse)
        {
            if (!commandResponse.Sucesso)
                return BadRequest(commandResponse);

            var commitResult = _uow.Commit();
            if (commitResult.Sucesso)
                return Created("", commandResponse);

            return TratativaErroPersistencia(commitResult);
        }

        //Atualizar (PUT)
        protected IActionResult JPPutActionResult(CommandResponse commandResponse)
        {
            if (!commandResponse.Sucesso)
                return BadRequest(commandResponse);

            var commitResult = _uow.Commit();
            if (commitResult.Sucesso)
                return Ok(commandResponse);

            return TratativaErroPersistencia(commitResult);
        }

        //LISTAR/OBTER (GET)
        protected IActionResult JPGetActionResult(CommandResponse commandResponse)
        {
            if (!commandResponse.Sucesso)
                return BadRequest(commandResponse);

            if (commandResponse.Dados==null)
                return NoContent();

            return Ok(commandResponse);
        }

        //REMOVER (DELETE)
        protected IActionResult JPDeletActionResult(CommandResponse commandResponse)
        {
            if (!commandResponse.Sucesso)
                return BadRequest(commandResponse);

            var commitResult = _uow.Commit();
            if (commitResult.Sucesso)
                return Ok(commandResponse);

            return TratativaErroPersistencia(commitResult);
        }



        //TRATATIVAS DE ERRO DO COMMIT
        private IActionResult TratativaErroPersistencia(CommitResult commitResult)
        {
            var erroResponse = new List<Notification>
            {
                new Notification("Persitência", commitResult.MensagemErroDetalhada != null
                    ? $"Ocorreu o seguinte erro ao persistir os dados: {commitResult.MensagemErro} - {commitResult.MensagemErroDetalhada}"
                    : $"Ocorreu o seguinte erro ao persistir os dados: {commitResult.MensagemErro}")

            };
            return BadRequest(new
            {
                Sucesso = false,
                Notificacoes = erroResponse
            });
        }
    }       
}
