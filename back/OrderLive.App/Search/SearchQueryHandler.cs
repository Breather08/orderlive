using MediatR;
using OrderLive.Infrastructure.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderLive.App.Search
{
    public class SearchQueryHandler : IRequestHandler<SearchQuery, List<string>>
    {
        private readonly OpenAIService _openAIService;

        public SearchQueryHandler(OpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        public async Task<List<string>> Handle(SearchQuery request, CancellationToken cancellationToken)
        {
            var result = await _openAIService.Questions(request.Query);
            if (result == null)
            {
                var choises = result.Choices;
                var content = choises[0].Message.Content;
                return content.Split("- ").ToList();
            }

            return new List<string> { "result1", "result2" };
        }
    }   
}
