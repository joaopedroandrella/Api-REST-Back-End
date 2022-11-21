using JPCadastro.Operacional.Enumeradores;
using Microsoft.AspNetCore.Mvc;
using prmToolkit.EnumExtension;

namespace JPCadastro.Controllers.Enumerators
{

    [Route("api/[controller]")]
    [ApiController]
    public class EnumeratorsController : ControllerBase
    {
        [HttpGet("listar-periodo-curso")]
        public IActionResult ListarPeriodoCurso()
        {
            return Ok(Listar<Periodo>());
        }

        [HttpGet("listar-status-matricula")]
        public IActionResult ListarStatusMatricula ()
        {
            return Ok(Listar<StatusMatricula>());
        }

        private List<object> Listar<T>() where T : Enum
        {
            var enumVals = new List<object>();

            foreach (var item in Enum.GetValues(typeof(T)))
            {
                enumVals.Add(new
                {
                    id = (int)item,
                    name = ((T)item).GetDescription()
                });
            }
            return enumVals;
        }
    }
}
