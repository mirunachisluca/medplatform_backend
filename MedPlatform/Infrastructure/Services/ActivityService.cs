using Core.Entities;
using Core.Interfaces;
using Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ActivityService : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IHubContext<ActivityMessageHub, IActivityMessageHub> _messageHub;

        public ActivityService(IServiceScopeFactory serviceScopeFactory, IHubContext<ActivityMessageHub, IActivityMessageHub> messageHub)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _messageHub = messageHub;

            var factory = new ConnectionFactory
            {
                HostName = "squid.rmq.cloudamqp.com",
                VirtualHost = "umvatzyf",
                UserName = "umvatzyf",
                Password = "GkrCoxT3sPmP-crezwf3194pAbHhc7p2",
                DispatchConsumersAsync = true
            };

            //var factory = new ConnectionFactory
            //{
            //    HostName = "localhost",
            //    UserName = "guest",
            //    Password = "guest",
            //    DispatchConsumersAsync = true
            //};

            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.BasicQos(0, 1, false);
            _channel.QueueDeclare(queue: "Activities",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.Received += async (ch, ea) =>
            {
               var content = Encoding.UTF8.GetString(ea.Body.ToArray());
               var activity = JsonConvert.DeserializeObject<Activity>(content);

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                    _unitOfWork.ActivityRepository.Insert(activity);
                    _unitOfWork.Save();

                    var patient = _unitOfWork.PatientRepository.GetByID(activity.PatientId);

                    ActivityMessage message = new ActivityMessage { PatientName = patient.Name, CaregiverId = patient.CaregiverId };

                    await CheckRulesAsync(activity, message);
                }

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume("Activities", false, consumer);
            await Task.CompletedTask;
        }

        public async Task CheckRulesAsync(Activity activity, ActivityMessage message)
        {
            var duration = (activity.EndDate - activity.StartDate);
       
            switch (activity.ActivityName)
            {
                
                case "Sleeping":
                    if (duration.TotalHours > 7)
                    {
                        message.Message = "has slept for more than 7 hours.";
                        await _messageHub.Clients.All.SendMessage(message);
                    }
                    break;
                case "Leaving":
                    if (duration.TotalHours > 5)
                    {
                        message.Message = "has been outside for more than 5 hours.";
                        await _messageHub.Clients.All.SendMessage(message);
                    }
                    break;
                case "Toileting":
                    if (duration.TotalMinutes > 30)
                    {
                        message.Message = "has been inside the bathroom for more than 30 minutes.";
                        await _messageHub.Clients.All.SendMessage(message);
                    }
                    break;
                case "Showering":
                    if (duration.TotalMinutes>30)
                    {
                        message.Message = "has been inside the bathroom for more than 30 minutes.";
                        await _messageHub.Clients.All.SendMessage(message);
                    }
                    break;
                case "Grooming":
                    if (duration.TotalMinutes>30)
                    {
                        message.Message = "has been inside the bathroom for more than 30 minutes.";
                        await _messageHub.Clients.All.SendMessage(message);
                    }
                    break;
                default: break;
            }

        }
    }
}

