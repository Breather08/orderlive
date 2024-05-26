using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace OrderLive.App.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return "token";
        }
    }
}
