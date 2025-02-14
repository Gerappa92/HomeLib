namespace HomeLib.BusinessLogic.Commands.Books
{
    public abstract class Book
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
    }
}
