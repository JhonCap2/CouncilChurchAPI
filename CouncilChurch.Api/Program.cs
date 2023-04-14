using CouncilChurch.Core.Interface;
using CouncilChurch.Infraestructure.Data;
using CouncilChurch.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



//Comunicacion entre los IRepository y los Repository
builder.Services.AddTransient<IAddressRespository, AddressRepository>();
builder.Services.AddTransient<IChurchRepository, ChurchRepository>();
builder.Services.AddTransient<ICivilStateRepository, CivilStateRepository>();
builder.Services.AddTransient<ICouncilRepository, CouncilRepository>();
builder.Services.AddTransient<IMemberRepository, MemberRepository>();
builder.Services.AddTransient<IProfessionRepository, ProfessionRepository>();
builder.Services.AddTransient<ISocialNetworkRepository, SocialNetworkRepository>();

//Conection de la DB con el Sistema
builder.Services.AddDbContext<DbChurchContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Church"))

 );

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.




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

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
