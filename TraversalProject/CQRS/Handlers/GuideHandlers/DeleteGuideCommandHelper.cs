using DataAccessLayer.Concrete;
using MediatR;
using NuGet.Protocol.Plugins;
using TraversalProject.CQRS.Commands.GuideCommands;

namespace TraversalProject.CQRS.Handlers.GuideHandlers
{
    public class DeleteGuideCommandHelper : IRequestHandler<DeleteGuideCommand>
    {
        private readonly Context _context;

        public DeleteGuideCommandHelper(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGuideCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.Id);
            _context.Remove(values);
            await _context.SaveChangesAsync();
            return Unit.Value;
        } 
    }
}
