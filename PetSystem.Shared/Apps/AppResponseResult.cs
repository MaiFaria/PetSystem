using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace PetSystem.Shared.Apps;

public static class AppResponseResult
{
    public static ActionResult GetResponse<T>(bool sucess,
                                              IList<string> message,
                                              T data,
                                              int statusCode = 200)
    {
        object value = new();
        object? obj = new();
        obj = !data.GetType().GetProperties().Any((p) => p.Name == "Result")
               ? data : data.GetType().GetProperty("Result")!.GetValue(data);
        switch (statusCode)
        {
            case 200:
                value = new
                {
                    Success = sucess,
                    Message = message,
                    Result = obj
                };
                break;
            case 400:
                value = new
                {
                    Success = sucess,
                    Notifications = message,
                    Result = obj
                };
                break;
            case 500:
                throw new Exception(message.FirstOrDefault());
        }

        return new ObjectResult(value)
        {
            StatusCode = statusCode
        };
    }

    public static ActionResult GetResponse<T>(bool sucess,
                                              string message,
                                              T data,
                                              int statusCode = 200)
    {
        object value = new();
        object? obj = new();
        obj = !data.GetType().GetProperties().Any((p) => p.Name == "Result")
               ? data : data.GetType().GetProperty("Result")!.GetValue(data);

        switch (statusCode)
        {
            case 200:
                value = new
                {
                    Success = sucess,
                    Message = message,
                    Result = obj
                };
                break;
            case 400:
                value = new
                {
                    Success = sucess,
                    Notifications = message,
                    Result = obj
                };
                break;
            case 500:
                throw new Exception(message);
        }

        return new ObjectResult(value)
        {
            StatusCode = statusCode
        };
    }

    public static ActionResult? GetResponse<T>(bool sucess,
                                               IList<ValidationFailure> message,
                                               T data,
                                               int statusCode = 200)
    {
        if (message == null)
            return null;

        List<string> list = new List<string>();

        foreach (ValidationFailure item in message)
            list.Add(item.ErrorMessage);

        object value = new();
        StringBuilder str = new();
        List<string> listStr = new();
        message.ToList().ForEach(delegate (ValidationFailure x)
        {
            str.AppendLine(x.ErrorMessage);
            listStr.Add(x.ErrorMessage);
        });

        _ = new object();
        object? obj = new();
        obj = !data.GetType().GetProperties().Any((p) => p.Name == "Result")
               ? data : data.GetType().GetProperty("Result")!.GetValue(data);

        switch (statusCode)
        {
            case 200:
                value = new
                {
                    Success = sucess,
                    Message = message,
                    Result = obj
                };
                break;
            case 400:
                value = new
                {
                    Success = sucess,
                    Notifications = listStr,
                    Result = obj
                };
                break;
            case 500:
                value = new
                {
                    Success = sucess,
                    ErrorDescription = str.ToString(),
                    Result = obj
                };
                break;
        }

        return new ObjectResult(value)
        {
            StatusCode = statusCode
        };
    }

    public static ActionResult GetResponse(object response)
    {
        return new ObjectResult(response)
        {
            StatusCode = 200
        };
    }

    public static object GetResponseMessage(string message, int statusCode = 500)
    {
        if (statusCode == 400)
        {
            return new
            {
                success = false,
                notifications = new string[1] { message },
                result = new { }
            };
        }

        return new
        {
            success = false,
            errorDescription = new string[1] { message },
            result = new { }
        };
    }

    public static object GetResponseMessage(string[] message, int statusCode = 500)
    {
        if (statusCode == 400)
        {
            return new
            {
                success = false,
                notifications = message,
                result = new { }
            };
        }

        return new
        {
            success = false,
            errorDescription = message,
            result = new { }
        };
    }

    public static ActionResult GetResponse<T>(T response)
    {
        return new ObjectResult(response)
        {
            StatusCode = 200
        };
    }
}