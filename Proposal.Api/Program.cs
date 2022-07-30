var builder = WebApplication.CreateBuilder(args);
Microsoft.Extensions.Configuration.IConfiguration configuration = builder.Configuration;

//Adding Serilog
var logger = new LoggerConfiguration()
               .MinimumLevel.Information()
               .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
               .Enrich.FromLogContext()
               .WriteTo.RollingFile("logs/{Date}.txt")
               .CreateLogger();

builder.Logging.AddSerilog(logger);

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(builder =>
        //builder.WithOrigins("http://localhost:3000")
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
));

builder.Services.AddControllers()
    .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<ProposalDbContext>(
    builder => builder.UseSqlServer(configuration.GetConnectionString("Proposal")),
    // è necessario che sia Transient poichè ho necessità di compiere azioni asincrone
    // ogni Service così ha la propria versione unica del DbContext (con la propria connessione)
    ServiceLifetime.Transient
);

builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddHttpClient();
builder.Services.AddProposalCore(configuration);
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
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//this may crash the redirection of cors
//app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();

app.MapControllers();

app.Run();

