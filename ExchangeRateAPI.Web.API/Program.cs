using ExchangeRateAPI.Web.Api.Contracts;
using ExchangeRateAPI.Web.Api.DAL;
using ExchangeRateAPI.Web.Api.Impl;

namespace ExchangeRateAPI.Web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<ICountriesDAL, CountriesDAL>();
            builder.Services.AddSingleton<IPartnersDAL, PartnersDAL>();

            builder.Services.AddSingleton<ICountryImpl, CountryImpl>();
            builder.Services.AddSingleton<IExchangeRateImpl, ExchangeRateImpl>();            
            builder.Services.AddSingleton<IRateAdjustmentFactory, RateAdjustmentFactory>();


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
        }
    }
}