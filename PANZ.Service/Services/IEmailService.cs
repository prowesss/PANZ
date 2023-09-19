
using PANZ.Service.Models;

namespace PANZ.Service.Services
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
