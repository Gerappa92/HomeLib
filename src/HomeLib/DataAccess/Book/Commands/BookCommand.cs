namespace HomeLib.DataAccess.Book.Commands
{
    public abstract class BookCommand
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
    }
}
