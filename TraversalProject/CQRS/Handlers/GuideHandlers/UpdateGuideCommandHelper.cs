using DataAccessLayer.Concrete;
using MediatR;
using NuGet.Protocol.Plugins;
using TraversalProject.CQRS.Commands.GuideCommands;

namespace TraversalProject.CQRS.Handlers.GuideHandlers
{
    public class UpdateGuideCommandHelper : IRequestHandler<UpdateGuideCommand>
    {
        private readonly Context _context;

        public UpdateGuideCommandHelper(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateGuideCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.GuideId);
            values.Name = request.Name;
            values.Description = request.Description;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
