using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace API.AppStart
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                IDictionary<string, string[]> errorList =
                    context
                        .ModelState
                        .ToDictionary
                        (
                                kvp => kvp.Key,
                                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                        );
                string content = JsonConvert.SerializeObject(errorList);
                context.Result = new ContentResult
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Content = content,
                };
            }
        }
    }
}