namespace Repositories.Items
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string? Description { get; set; }
        public bool IsComplete { get; set; } = false;
        public DateTime? Deadline { get; set; }
        public int? CategoryId { get; set; }
    }
}
