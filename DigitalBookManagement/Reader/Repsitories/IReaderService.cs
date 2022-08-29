using Reader.Models;

namespace Reader.Repsitories
{
    public interface IReaderService
    {
        IEnumerable<VBook2User> SearchBook(string? bookTitle, string? category, string? author, decimal? price, string? publisher);
        void PurchaseBook(Payment payment);
        Book GetBookById(long bookId);
        IEnumerable<VBookPayment> GetPaymentHistory(string email);
        VBookPayment GetBookByIdForPayment(long bookId);

        void GetRefund(long paymentId);

    }
}
