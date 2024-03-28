using AutoMapper;
using BookStore.BusinessLogic.Dtos.Books;
using BookStore.BusinessLogic.Exceptions;
using BookStore.BusinessLogic.Interfaces;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Interfaces;

namespace BookStore.BusinessLogic.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly ISaveChangesRepository _saveChangesRepository;
        public BookService(IBookRepository bookRepository,
           IMapper mapper,
           ILoggerManager loggerManager,
           ISaveChangesRepository saveChangesRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;   
            _loggerManager = loggerManager;
            _saveChangesRepository = saveChangesRepository;
        }

        public async Task<BookDto> AddAsync(BookDto book, CancellationToken cancellationToken)
        {
            var mappedBook = _mapper.Map<Book>(book);
            var checkedBook = await _bookRepository.GetBySomethingAsync(x => x.Id == mappedBook.Id, cancellationToken);
            if(checkedBook != null)
            {
                _loggerManager.LogError("Error occured while adding the book");
                throw new AlreadyExistException("This book already exist");
            }
            _bookRepository.AddAsync(mappedBook);
            try
            {
                await _saveChangesRepository.SaveChangesAsync();
                _loggerManager.LogInfo("Changes successfully saved in the database");
            }
            catch (Exception ex) 
            { 
                _loggerManager.LogInfo($"Error occured while adding a book{ex.Message}");
                throw new ArgumentException($"Something went wrong while adding the location {ex.Message}");
            }
            return book; 
         }

       
        public async Task<BookDto> DeleteAsync(BookDto book, CancellationToken cancellationToken)
        {
            var mappedBook = _mapper.Map<Book>(book);
            var checkedBook = await _bookRepository.GetBySomethingAsync(x => x.Id == mappedBook.Id, cancellationToken); 
            if (checkedBook == null)
            {
                throw new NotFoundException("The location wasn't found");
            }

            try
            {
                _bookRepository.DeleteAsync(mappedBook);
                await _saveChangesRepository.SaveChangesAsync();
                _loggerManager.LogInfo("Changes successfully saved in the database");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong while deleting the location {ex.Message}", ex);
            }
            return book;
        }

        public async Task<List<BookDto>> GetAllAsync(CancellationToken cancellationToken)
        { 
            var list = await _bookRepository.GetAllAsync(cancellationToken);
            if(list == null)
            {
                throw new NotFoundException("There is no registered books yet");
            } 
            var listDto = _mapper.Map<List<BookDto>>(list);
            return listDto;
        }

        public async Task<BookDto> GetBookByDescriptionAsync(string bookDescription, CancellationToken cancellationToken)
        {
            BookDto bookDto = new BookDto();
            var mappedBook = _mapper.Map<Book>(bookDto);
            mappedBook.Description = bookDescription;
            var checkedBook = await _bookRepository.GetBySomethingAsync(x => x.Description == mappedBook.Description, cancellationToken);

            if (checkedBook == null)
            {
                throw new NotFoundException("This book wasn't found");
            }
            return _mapper.Map<BookDto>(checkedBook);
         }

        public async Task<BookDto> GetBookByNameAsync(string bookName, CancellationToken cancellationToken)
        {
            BookDto bookDto = new BookDto(); 
            var mappedBook = _mapper.Map<Book>(bookDto);
            mappedBook.Name = bookName;
            var checkedBook = await _bookRepository.GetBySomethingAsync(x => x.Name == mappedBook.Name, cancellationToken);

            if (checkedBook == null)
            {
                throw new NotFoundException("This book wasn't found");
            }
            return _mapper.Map<BookDto>(checkedBook);
        }

        public async Task<BookDto> GetByIdAsync(BookDto book, CancellationToken cancellationToken)
        {
             var mappedBook = _mapper.Map<Book>(book);
            var checkedBook = await _bookRepository.GetBySomethingAsync(x => x.Id == mappedBook.Id, cancellationToken);

            if (checkedBook == null)
            {
                throw new NotFoundException("This book wasn't found");
            }
            return _mapper.Map<BookDto>(checkedBook);
        }


        public async Task<BookDto> UpdateAsync(BookDto book, CancellationToken cancellationToken)
        {
            var mappedBook = _mapper.Map<Book>(book);
            var checkedBook = await _bookRepository.GetBySomethingAsync(x => x.Id == mappedBook.Id, cancellationToken);
            if (checkedBook == null)
            {
                throw new NotFoundException("This book wasn't found");
            }
            try
            {
                checkedBook.Name = mappedBook.Name;
                checkedBook.Description = mappedBook.Description;
                _bookRepository.UpdateAsync(mappedBook);
                await _saveChangesRepository.SaveChangesAsync();
                _loggerManager.LogInfo("Changes successfully saved in the database");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong while updating the book {ex.Message}");
            }
            return book;
        }

    }
}
