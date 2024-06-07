using Cotation.API.Validators.Address;
using Cotation.API.Validators.Company;
using Cotation.Application.Services.SAddress;
using Cotation.Application.Services.SCompany;
using Cotation.Communication.DTOS.AddressDTO;
using Cotation.Communication.DTOS.CompanyDTO;
using Cotation.Communication.DTOS.CotationsDTO;
using Cotation.Communication.DTOS.ItemDTO;
using Cotation.Communication.DTOS.ProductDTO;
using Cotation.Communication.DTOS.UserDTO;
using Cotation.Infrastructure.Context;
using Cotation.Infrastructure.Repositories.RepositoryAddress;
using Cotation.Infrastructure.Repositories.RepositoryCompany;
using Cotation.Infrastructure.Repositories.RepositoryCotations;
using Cotation.Infrastructure.Repositories.RepositoryItem;
using Cotation.Infrastructure.Repositories.RepositoryProduct;
using Cotation.Infrastructure.Repositories.RepositoryUser;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICotationRepository, CotationsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IItemsRepository, ItemsRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<RegisterCompanyService>();
builder.Services.AddScoped<UpdateCompanyService>();
builder.Services.AddScoped<GetAllCompanyService>();
builder.Services.AddScoped<GetCompanyByIdService>();
builder.Services.AddScoped<DeleteCompanyService>();
builder.Services.AddScoped<GetCompanyByNameService>();

builder.Services.AddScoped<RegisterAddressService>();
builder.Services.AddScoped<UpdateAddressService>();
builder.Services.AddScoped<DeleteAddressService>();
builder.Services.AddScoped<GetAllAddressService>();
builder.Services.AddScoped<GetAddressByIdService>();




builder.Services.AddScoped<ResponseErrorRegisterCompany>();
builder.Services.AddScoped<ValidatorRegisterCompany>();

builder.Services.AddScoped<ResponseErrorRegisterAddress>();
builder.Services.AddScoped<ValidatorRegisterAddress>();

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
