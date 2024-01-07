using System.Net;

namespace CMCapital.API.Helpers;

public class Excecao : Exception
{
    private HttpStatusCode _httpStatusCode = HttpStatusCode.BadRequest;

    public Excecao() : base("")
    {
        Mensagem = string.Empty;
    }

    public Excecao(string mensagem) : base(mensagem)
    {
        Mensagem = mensagem;
    }

    public Excecao(string mensagem, HttpStatusCode statusCode) : base(mensagem)
    {
        Mensagem = mensagem;
        _httpStatusCode = statusCode;
    }

    public string Mensagem { get; private set; }
    public HttpStatusCode HttpStatusCode => _httpStatusCode;
}
