using AutoMapper;
using Todo.Domain.Models;

namespace Todo.Application.DTO;

public class ItemCreate(string title, string username, DateTime completeDate)
{
  public required string Title { get; set; } = title;
  public required string Username { get; set; } = username;
	public required	DateTime CompleteDate { get; set; } = completeDate;
}
public class ItemResponce(string title, bool isCompleted, DateTime completeDate)
{
  public string Title { get; set; } = title;
  public bool IsCompleted { get; set; } = isCompleted;
  public DateTime CompleteDate { get; set; } =  completeDate;
}

public class ItemCompleteNow(string title, string username)
{
  public string Title { get; set; } = title;
  public string Username { get; set; } = username;
}
public class ItemUpdate(string username, string title, string newTitle, bool newIsCompleted, DateTime newCompleteDate)
{
  public string Title { get; set; } = title;
  public string Username { get; set; } = username;
  public string NewTitle { get; set; } = newTitle;
  public bool NewIsCompleted { get; set; } = newIsCompleted;
  public DateTime NewCompleteDate { get; set; } =  newCompleteDate;
}