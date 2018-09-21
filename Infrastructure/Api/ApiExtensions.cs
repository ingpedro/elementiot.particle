using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections;
using System.Linq;

namespace ElementIoT.Particle.Infrastructure.Api
{
    public static class ApiExtensions
    {
        /// <summary>
        /// Extension method to get a list of all ModelState error messages.
        /// </summary>
        /// <param name="modelState">model state</param>
        /// <returns>ModelState error messages</returns>
        public static IEnumerable Errors(this ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                return modelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray())
                    .Where(m => m.Value.Count() > 0);
            }

            return null;
        }
    }
}
