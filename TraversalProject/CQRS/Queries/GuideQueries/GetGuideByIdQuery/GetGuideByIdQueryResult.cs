using MediatR;
using TraversalProject.CQRS.Results.GuideResults;

namespace TraversalProject.CQRS.Queries.GuideQueries.GetGuideByIdQuery
{
    public class GetGuideByIdQuery : IRequest<GetGuideByIdQueryResult>
    {
        public GetGuideByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
