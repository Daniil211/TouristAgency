using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamWebApiClient.Models;

namespace Application.Mobile.Services.Services.Tour
{
    public class InMemoryTourService : ITourService
    {
        private readonly List<Book> _books = new List<Book>();
        public InMemoryTourService()
        {
            _books.Add(new Book { TourName = "Clean code", Duration = "Robert C Martin", Description = "A book about good code", Image = "test", InSale = true, VideoTour = "test", Price = 1000 });
            _books.Add(new Book { TourName = "Clean code", Duration = "Robert C Martin", Description = "A book about good code", Image = "test", InSale = true, VideoTour = "test", Price = 1000 });
            _books.Add(new Book { TourName = "Clean code", Duration = "Robert C Martin", Description = "A book about good code", Image = "test", InSale = true, VideoTour = "test", Price = 1000 });
        }

        public Task AddBook(Book book)
        {
            book.TourId = ++_books.Last().TourId;
            _books.Add(book);
            return Task.CompletedTask;
        }

        public Task DeleteBook(Book book)
        {
            _books.Remove(book);
            return Task.CompletedTask;
        }

        public Task<Book> GetBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.TourId == id);
            return Task.FromResult(book);
        }

        public Task<IEnumerable<Book>> GetBooks()
        {
            return Task.FromResult(_books.AsEnumerable());
        }

        public Task SaveBook(Book book)
        {
            _books[_books.FindIndex(b => b.TourId == book.TourId)] = book;
            return Task.CompletedTask;
        }
    }
}
