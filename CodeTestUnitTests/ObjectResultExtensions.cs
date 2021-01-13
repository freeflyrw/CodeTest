using Microsoft.AspNetCore.Mvc;

namespace CodeTestUnitTests
{
    internal static class ObjectResultExtensions
    {
        internal static T GetValueFromResult<T>(this ActionResult<T> actionResult)
        {
            return (T)((OkObjectResult)actionResult.Result).Value;
        }
    }
}
