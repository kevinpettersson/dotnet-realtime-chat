public interface IMessageService
{
    Task SaveMessageAsync(Message message);
    Task<List<Message>> GetHistoryAsync();
}