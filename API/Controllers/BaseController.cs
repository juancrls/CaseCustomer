using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        // Método para retornar uma resposta de sucesso (status 200 OK)
        protected IActionResult Response(object data = null)
        {
            if (data != null)
            {
                return Ok(new
                {
                    success = true,
                    data
                });
            }

            return Ok(new
            {
                success = true
            });
        }

        // Método para retornar uma resposta de erro (status 400 Bad Request)
        protected IActionResult ResponseBadRequest(IEnumerable<string> errors)
        {
            return BadRequest(new
            {
                success = false,
                errors
            });
        }

        // Método para retornar uma resposta de erro não encontrado (status 404 Not Found)
        protected IActionResult ResponseNotFound()
        {
            return NotFound(new
            {
                success = false,
                errors = new List<string> { "Recurso não encontrado." }
            });
        }

        // Método para retornar uma resposta de exceção interna (status 500 Internal Server Error)
        protected IActionResult ResponseException(Exception ex)
        {
            return StatusCode(500, new
            {
                success = false,
                errors = new List<string> { ex.Message }
            });
        }
    }
}