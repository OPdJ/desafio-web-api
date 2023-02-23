using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioWebAPI.API.Controllers.Custom
{
    public class ControllerCustom : ControllerBase
    {
        [NonAction]
        public string ModelError()
        {
            StringBuilder errorBuild = new StringBuilder();

            var errors = ModelState.Values
                            .SelectMany(e => e.Errors)
                            .Select(e => e.ErrorMessage)
                            .ToList();

            foreach (var erro in errors)
            {
                errorBuild.Append($"{erro} ");
            }

            return errorBuild.ToString();
        }
    }
}
