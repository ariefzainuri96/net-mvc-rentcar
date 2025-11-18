using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentCar.Models
{
  public class HttpError: ObjectResult
  {
    public HttpError(string message, int statusCode = StatusCodes.Status400BadRequest)
            : base(new { error = message, status = statusCode, timestamp = DateTime.UtcNow })
        {
            StatusCode = statusCode;
        }
  }
}