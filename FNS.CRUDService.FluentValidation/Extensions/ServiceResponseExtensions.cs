using FluentValidation.Results;
using FNS.CRUDService.Model;

namespace FNS.CRUDService.FluentValidation.Extensions
{
    public static class ServiceResponseExtensions
    {
        public static ServiceResponse<T> AddError<T>(this ServiceResponse<T> serviceResponse, ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
            {
                foreach (var r in validationResult.Errors)
                {
                    serviceResponse.AddError(r.PropertyName, r.ErrorMessage);
                }
            }
            return serviceResponse;
        }
    }
}
