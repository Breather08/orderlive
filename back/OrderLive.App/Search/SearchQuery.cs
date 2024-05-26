using MediatR;
using System.Collections.Generic;

namespace OrderLive.App.Search
{
    public class SearchQuery : IRequest<List<string>>
    {
        public string Query { get; set; }
    }
}
