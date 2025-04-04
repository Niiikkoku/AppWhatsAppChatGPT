namespace AppWhatsAppChatGPT.Models
{
    public class UserMessage
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime SentDate { get; set; } = DateTime.Now;
        public UserMessage() { }
    }
}

