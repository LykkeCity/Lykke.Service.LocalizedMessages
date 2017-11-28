using Autofac;
using Autofac.Extensions.DependencyInjection;
using AzureStorage.Tables;
using Common.Log;
using Lykke.Service.LocalizedMessages.AzureRepositories.Message;
using Lykke.Service.LocalizedMessages.Core.Domain;
using Lykke.Service.LocalizedMessages.Core.Domain.Messages;
using Lykke.Service.LocalizedMessages.Core.Services;
using Lykke.Service.LocalizedMessages.Core.Settings.ServiceSettings;
using Lykke.Service.LocalizedMessages.Services;
using Lykke.SettingsReader;
using Microsoft.Extensions.DependencyInjection;

namespace Lykke.Service.LocalizedMessages.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<LocalizedMessagesSettings> _settings;
        private readonly ILog _log;
        // NOTE: you can remove it if you don't need to use IServiceCollection extensions to register service specific dependencies
        private readonly IServiceCollection _services;

        public ServiceModule(IReloadingManager<LocalizedMessagesSettings> settings, ILog log)
        {
            _settings = settings;
            _log = log;

            _services = new ServiceCollection();
        }

        protected override void Load(ContainerBuilder builder)
        {
            // TODO: Do not register entire settings in container, pass necessary settings to services which requires them
            // ex:
            //  builder.RegisterType<QuotesPublisher>()
            //      .As<IQuotesPublisher>()
            //      .WithParameter(TypedParameter.From(_settings.CurrentValue.QuotesPublication))

            builder.RegisterInstance(_log)
                .As<ILog>()
                .SingleInstance();

            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

            builder.RegisterType<StartupManager>()
                .As<IStartupManager>();

            builder.RegisterType<ShutdownManager>()
                .As<IShutdownManager>();

            // TODO: Add your dependencies here

            var dbSettings = _settings.Nested(x => x.Db);

            builder.RegisterInstance<IMessageRepository>(
                new MessageRepository(
                    AzureTableStorage<MessageLocalizedEntity>.Create(
                        dbSettings.ConnectionString(x => x.MessageConnString), dbSettings.CurrentValue.MessageTable, _log)
                    )
            );

            builder.Populate(_services);
        }
    }
}
