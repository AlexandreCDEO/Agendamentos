using System.Text.Json.Serialization;
using Agendamentos.Domain.Handlers;
using Agendamentos.Domain.Repositorios;
using Agendamentos.Infra.ContextoDeDados;
using Agendamentos.Infra.Repositorios;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder);
ConfigureMvc(builder);
var app = builder.Build();
app.MapControllers();
app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<ContextoDeAgendamentos>();
    builder.Services.AddTransient<IRepositorioAgendamento, RepositorioAgendamento>();
    builder.Services.AddTransient<IRepositorioMedico, RepositorioMedico>();
    builder.Services.AddTransient<IRepositorioPaciente, RepositorioPaciente>();
    builder.Services.AddTransient<ManipuladorAgendamento, ManipuladorAgendamento>();
    builder.Services.AddTransient<ManipuladorMedico, ManipuladorMedico>();
    builder.Services.AddTransient<ManipuladorPaciente, ManipuladorPaciente>();

}
void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services.AddControllers()
        .ConfigureApiBehaviorOptions(option => { option.SuppressModelStateInvalidFilter = true; })
        .AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        });
        
}