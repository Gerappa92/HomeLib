namespace HomeLib.DataAccess.Book.Commands;

public class UpdateBookCommand : BookCommand
{
    public required int Id { get; set; }
}
