using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
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

        protected IActionResult ResponseBadRequest(IEnumerable<string> errors)
        {
            return BadRequest(new
            {
                success = false,
                errors
            });
        }

        protected IActionResult ResponseNotFound()
        {
            return NotFound(new
            {
                success = false,
                errors = new List<string> { "Resource not found." }
            });
        }

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