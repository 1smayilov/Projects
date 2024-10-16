using DataAccessLayer.Concrete;
using TraversalProject.CQRS.Queries.DestinationQueries;
using TraversalProject.CQRS.Results.DestinationResults;

namespace TraversalProject.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIdQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery query) 
        {
              var values = _context.Destinations.Find(query.Id); 
            return new GetDestinationByIdQueryResult
            {
                DestinationId = values.DestinationId,
                City = values.City,
                DayNight = values.DayNight,
                Price = values.Price
            };
        } 
    }
}
