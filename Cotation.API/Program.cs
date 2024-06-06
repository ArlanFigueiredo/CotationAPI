using Cotation.Application.Services.SCompany;
using Cotation.Communication.DTOS.AddressDTO;
using Cotation.Communication.DTOS.CompanyDTO;
using Cotation.Communication.DTOS.CotationsDTO;
using Cotation.Communication.DTOS.ItemDTO;
using Cotation.Communication.DTOS.ProductDTO;
using Cotation.Communication.DTOS.UserDTO;
using Cotation.Infrastructure.Context;
using Cotation.Infrastructure.Repositories.RepositoryCompany;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(DTOCompanyProfile));

builder.Services.AddAutoMapper(options => {
    options.AddProfile<DTOCompanyProfile>();
    options.AddProfile<DTOAddressProfile>();
    options.AddProfile<DTOProductProfile>();
    options.AddProfile<DTOItemProfile>();   
    options.AddProfile<DTOCotationsProfile>();
    options.AddProfile<DTOUserProfile>();
});

// Register repositories and services
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<RegisterCompanyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
