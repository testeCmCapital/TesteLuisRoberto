using CMCapital.API.Configuracao;

var builder = WebApplication.CreateBuilder(args);

InjecaoDependencia.Configurar(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<MiddlewareGlobalExcecoes>();
app.Run();


