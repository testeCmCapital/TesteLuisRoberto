﻿using CMCapital.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CMCapital.API.Configuracao;

public class MiddlewareGlobalExcecoes : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Exception? error = null;
        string responseBody = string.Empty;

        Stream originalResponseBody = context.Response.Body;

        try
        {
            using var memStream = new MemoryStream();
            context.Response.Body = memStream;

            await next(context);

            memStream.Position = 0;
            responseBody = new StreamReader(memStream).ReadToEnd();

            memStream.Position = 0;
            await memStream.CopyToAsync(originalResponseBody);
            context.Response.Body = originalResponseBody;
        }
        catch (Excecao ex)
        {
            context.Response.Body = originalResponseBody;

            error = ex;

            var resposta = new ProblemDetails
            {
                Title = $"Ocorreu um erro ao processar a requisição.",
                Status = (int)ex.HttpStatusCode,
                Type = ex.GetBaseException().GetType().Name,
                Detail = string.IsNullOrEmpty(ex.Message) ? ex?.Mensagem : ex.Message,
                Instance = context.Request.Path
            };

            context.Response.StatusCode = (int)ex.HttpStatusCode;
            context.Response.ContentType = @"application/json";

            await context.Response.WriteAsJsonAsync(resposta);
        }
    }
}
