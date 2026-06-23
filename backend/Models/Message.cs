public class Message
{
    public int Id { get; set; }

    public string Content { get; set; } = string.Empty;

    public string SenderId { get; set; } = string.Empty;

    public DateTime SentAt { get; set; }

    public User Sender { get; set; } = null!;
}