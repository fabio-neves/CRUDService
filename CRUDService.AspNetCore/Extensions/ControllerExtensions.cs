using FNS.CRUDService.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CRUDService.AspNetCore.Extensions
{
    public static class ControllerExtensions
    {
        public static ObjectResult HandleError<T>(this ControllerBase controller, ServiceResponse<T> response)
        {
            if (response.Errors.Any())
            {
                foreach (var err in response.Errors)
                {
                    foreach (var message in err.Value)
                    {
                        controller.ModelState.AddModelError(err.Key, message);
                    }
                }

                return new UnprocessableEntityObjectResult(controller.ModelState);
            }

            var error = new Dictionary<string, string>();
            error.Add("Message", "Something goes wrong!");
            return controller.StatusCode(422, error);
        }
    }
}
