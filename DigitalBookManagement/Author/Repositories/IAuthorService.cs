using Author.Models;

namespace Author.Repositories
{
    public interface IAuthorService
    {
        void CreateBook(Book book);
        IEnumerable<VBook2User> GetAllBooks(long userId);
        string AuthorLogin(User user);
        string EditBook(Book book);
        string LockOrUnlocBook(Book book);
        void DeleteBook(long bookId);
        Book GetBookById(long bookId);
    }
}
