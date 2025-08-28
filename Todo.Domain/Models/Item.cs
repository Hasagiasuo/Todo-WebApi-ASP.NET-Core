namespace Todo.Domain.Models;

public class Item
{
	public Guid Id { get; set; }
	public required string Title { get; set; }
	public bool IsCompleted { get; set; } = false;
	public DateTime Created { get; set; } = DateTime.Now;
	public DateTime Updated { get; set; } = DateTime.Now;
	public DateTime? CompletedDate { get; set; }
	public required DateTime CompleteDate { get; set; }
	public required User User { get; set; }
	public required	Guid UserId { get; set; }
}