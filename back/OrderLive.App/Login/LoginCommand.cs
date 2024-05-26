using MediatR;

namespace OrderLive.App.Login
{
    public class LoginCommand : IRequest<string>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
