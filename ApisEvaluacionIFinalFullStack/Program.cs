using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Interface;
using Repositories.Repositorie;
using Serilog;
using Serilog.Events;
using Services.Implementation;
using Services.Interface;
using Services.Profiles;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("..\\log.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Warning)
    .CreateLogger();
builder.Logging.AddSerilog(logger);


builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ApisEvaluacionIFinalFullStack"));
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly("ApisEvaluacionIFinalFullStack"));
});


// Add services to the container.
builder.Services.AddTransient<IClientesService, ClientesService>();
builder.Services.AddTransient<IClientesRepository, ClientesRepository>();
builder.Services.AddTransient<ILibrosService, LibrosService>();
builder.Services.AddTransient<ILibrosRepository, LibrosRepository>();
builder.Services.AddTransient<IPedidosService, PedidosService>();
builder.Services.AddTransient<IPedidosRepository, PedidosRepository>();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<ClientesProfile>();
    config.AddProfile<LibrosProfile>();

});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
