using CQRSWithMediatRSampleDemo.Models.Enums;

namespace CQRSWithMediatRSampleDemo.Entities;

public class TodoList : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public  TodoStatus Status { get; set; }
    public DateTimeOffset StartDateTimeOffset { get; set; }
    public DateTimeOffset EndDateTimeOffset { get; set; }
    public bool IsDeleted { get; set; }
}
