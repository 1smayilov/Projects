using DataAccessLayer.Concrete;
using MediatR;
using TraversalProject.CQRS.Queries.GuideQueries.GetGuideByIdQuery;
using TraversalProject.CQRS.Results.GuideResults;

namespace TraversalProject.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIdQueryHandler : IRequestHandler<GetGuideByIdQuery, GetGuideByIdQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIdQueryHandler(Context context )
        {
            _context = context;
        }

        public async Task<GetGuideByIdQueryResult> Handle(GetGuideByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.Id);
            return new GetGuideByIdQueryResult
            {
                GuideId = values.GuideId,
                Description = values.Description, 
                Name = values.Name
            };

        }
    }
}
