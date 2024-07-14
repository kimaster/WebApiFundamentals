namespace CityInfo.Api.Services
{
    public class LocalMailService : IMailService
    {
        private string _mailTo = "hakim.maakeb@hotmail.com";
        private string _mailFrom = "hakim@gmail.com";

        public LocalMailService(ILogger<LocalMailService> logger) => Logger = logger;

        public ILogger<LocalMailService> Logger { get; }
        public void Send(string subject, string message)
        {
            Logger.LogInformation($"mail from {_mailFrom} to {_mailTo} , with {nameof(LocalMailService)}");
            Logger.LogInformation($"subject {subject}");
            Logger.LogInformation($"message {message}");
        }
    }
}
