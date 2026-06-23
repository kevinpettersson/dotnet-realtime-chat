

using Microsoft.EntityFrameworkCore;

public class MessageService : IMessageService
{

    private readonly AppDbContext _context;

    public MessageService(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Message>> GetHistoryAsync()
    {
        return _context.Messages
            .OrderBy(m => m.SentAt)
            .ToListAsync();
    }

    public async Task SaveMessageAsync(Message message)
    {
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
    }
    
}