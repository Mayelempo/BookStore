using AutoMapper;
using BookStore.BusinessLogic.Dtos.Comments;
using BookStore.BusinessLogic.Exceptions;
using BookStore.BusinessLogic.Interfaces;
using BookStore.DataAccess.Interfaces;
using BookStore.DataAccess.Models;


namespace BookStore.BusinessLogic.Services
{
    public class CommentService :ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly ISaveChangesRepository _saveChangesRepository;
        public CommentService(ICommentRepository commentRepository,
           IMapper mapper,
           ILoggerManager loggerManager,
           ISaveChangesRepository saveChangesRepository)

        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _saveChangesRepository = saveChangesRepository;
        }

        public async Task<CommentDto> AddAsync(CommentDto comment, CancellationToken cancellationToken)
        {
            var mappedComment = _mapper.Map<Comment>(comment);
            var checkedComment = await _commentRepository.GetBySomethingAsync(x => x.Id == mappedComment.Id, cancellationToken);
            if (checkedComment != null)
            {
                _loggerManager.LogError("Error occured while adding the comment");
                throw new AlreadyExistException("This comment already exist");
            }
            _commentRepository.AddAsync(mappedComment);
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
            return comment;
        }


        public async Task<CommentDto> DeleteAsync(CommentDto comment, CancellationToken cancellationToken)
        {
            var mappedComment = _mapper.Map<Comment>(comment);
            var checkedComment = await _commentRepository.GetBySomethingAsync(x => x.Id == mappedComment.Id, cancellationToken);
            if (checkedComment == null)
            {
                throw new NotFoundException("The location wasn't found");
            }

            try
            {
                _commentRepository.DeleteAsync(mappedComment);
                await _saveChangesRepository.SaveChangesAsync();
                _loggerManager.LogInfo("Changes successfully saved in the database");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong while deleting the location {ex.Message}", ex);
            }
            return comment;
        }

        public async Task<List<CommentDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var list = await _commentRepository.GetAllAsync(cancellationToken);
            if (list == null)
            {
                throw new NotFoundException("There is no registered books yet");
            }
            var listDto = _mapper.Map<List<CommentDto>>(list);
            return listDto;
        }

        public async Task<CommentDto> GetCommentByAsync(string commentText, CancellationToken cancellationToken)
        {
            CommentDto commentDto = new CommentDto();
            var mappedComment = _mapper.Map<Comment>(commentDto);
            mappedComment.CommentText = commentText;
            var checkedComment = await _commentRepository.GetBySomethingAsync(x => x.CommentText == mappedComment.CommentText, cancellationToken);

            if (checkedComment == null)
            {
                throw new NotFoundException("This comment wasn't found");
            }
            return _mapper.Map<CommentDto>(checkedComment);
        }


        public async Task<CommentDto> GetByIdAsync(CommentDto comment, CancellationToken cancellationToken)
        {
            var mappedComment = _mapper.Map<Comment>(comment);
            var checkedComment = await _commentRepository.GetBySomethingAsync(x => x.Id == mappedComment.Id, cancellationToken);

            if (checkedComment == null)
            {
                throw new NotFoundException("This comment wasn't found");
            }
            return _mapper.Map<CommentDto>(checkedComment);
        }
        public async Task<CommentDto> UpdateAsync(CommentDto comment, CancellationToken cancellationToken)
        {
            var mappedComment = _mapper.Map<Comment>(comment);
            var checkedComment = await _commentRepository.GetBySomethingAsync(x => x.Id == mappedComment.Id, cancellationToken);
            if (checkedComment == null)
            {
                throw new NotFoundException("This comment wasn't found");
            }
            try
            {
                checkedComment.CommentText = mappedComment.CommentText;
                _commentRepository.UpdateAsync(mappedComment);
                await _saveChangesRepository.SaveChangesAsync();
                _loggerManager.LogInfo("Changes successfully saved in the database");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong while updating the comment {ex.Message}");
            }
            return comment;
        }

        public async Task<CommentDto> GetCommentByCreationDateTimeAsync(DateTime creationDateTime, CancellationToken cancellationToken)
        {
            
                CommentDto commentDto = new CommentDto();
                var mappedComment = _mapper.Map<Comment>(commentDto);
                var checkedComment = await _commentRepository.GetBySomethingAsync(x => x.CreationDateTime == mappedComment.CreationDateTime, cancellationToken);

                if (checkedComment == null)
                {
                    throw new NotFoundException("This like wasn't found");
                }

                return _mapper.Map<CommentDto>(checkedComment);
            
        }

        public async Task<CommentDto> GetCommentByCommentTextAsync(string commentText, CancellationToken cancellationToken)
        {
            CommentDto commentDto = new CommentDto();
            var mappedComment = _mapper.Map<Comment>(commentDto);
            var checkedComment = await _commentRepository.GetBySomethingAsync(x => x.CommentText == mappedComment.CommentText, cancellationToken);

            if (checkedComment == null)
            {
                throw new NotFoundException("This like wasn't found");
            }

            return _mapper.Map<CommentDto>(checkedComment);


        }


    }
}
