using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace PetSystem.Shared.Apps;

public class ApplicationResult
{
    public static Task<ActionResult> ReturnOk(object data, string message = "Successfully performed operation.")
    {
        return Task.FromResult(AppResponseResult.GetResponse(sucess: true,
                                                             message,
                                                             data));
    }

    public static Task<ActionResult> ReturnNo(object? data = null, string? message = null, int statusCode = 400)
    {
        return Task.FromResult(AppResponseResult.GetResponse(sucess: false,
                                                             new string[1] { message },
                                                             data,
                                                             statusCode));
    }

    public static Task<ActionResult> ReturnNo(object? data = null, IList<ValidationFailure> message = null, int statusCode = 400)
    {
        return Task.FromResult(AppResponseResult.GetResponse(sucess: false,
                                                             message,
                                                             data,
                                                             statusCode));
    }
}