using System;
using System.Dynamic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TgAppCrates.Core.models;
using TgAppCrates.Core.Abstractions;

namespace MyApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var services = CreateServices();

            CardsDbContext context = services.GetRequiredService<CardsDbContext>();
            //context.Database.Migrate();

            Application app = services.GetRequiredService<Application>();
        }

        private static ServiceProvider CreateServices()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            ICardRepository myCardRepository = null; // ???
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(configuration)
                .AddDbContext<CardsDbContext>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }

    public class Application
    {
        /*private readonly ICardRepository _cardsRepository;

        public Application(ICardRepository cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }

        public async Task<List<Card>> GetAllCards(string tgId)
        {
            return await _cardsRepository.GetCards(tgId);
        }

        public async Task<Task> addCardToUser(string tgId, short type)
        {
            return _cardsRepository.addCardToUser(tgId, type);
        }

        public async Task<Task> update(Guid id, string tgId, short type, int count)
        {
            return _cardsRepository.update(id, tgId, type, count);
        }*/
    }
}