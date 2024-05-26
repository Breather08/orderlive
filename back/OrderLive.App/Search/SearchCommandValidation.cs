using FluentValidation;

namespace OrderLive.App.Search
{
    public class SearchCommandValidation : AbstractValidator<SearchQuery>
    {
        public SearchCommandValidation()
        {
            RuleFor(x => x).NotNull();
        }
    }
}
