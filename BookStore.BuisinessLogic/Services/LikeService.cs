using AutoMapper;
using BookStore.BusinessLogic.Dtos.Likes;
using BookStore.BusinessLogic.Exceptions;
using BookStore.BusinessLogic.Interfaces;
using BookStore.DataAccess.Interfaces;
using BookStore.DataAccess.Models;


namespace BookStore.BusinessLogic.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly ISaveChangesRepository _saveChangesRepository;
        public LikeService(ILikeRepository likeRepository,
           IMapper mapper,
           ILoggerManager loggerManager,
           ISaveChangesRepository saveChangesRepository)

        {
            _likeRepository = likeRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _saveChangesRepository = saveChangesRepository;
        }
        public async Task<LikeDto> AddAsync(LikeDto like, CancellationToken cancellationToken)
        {
            var mappedLike = _mapper.Map<Like>(like);
            var checkedLike = await _likeRepository.GetBySomethingAsync(x => x.Id == mappedLike.Id, cancellationToken);
            if (checkedLike != null)
            {
                _loggerManager.LogError("Error occured while adding the like");
                throw new AlreadyExistException("This like already exist");
            }
            _likeRepository.AddAsync(mappedLike);
            try
            {
                await _saveChangesRepository.SaveChangesAsync();
                _loggerManager.LogInfo("Changes successfully saved in the database");
            }
            catch (Exception ex)
            {
                _loggerManager.LogInfo($"Error occured while adding a like{ex.Message}");
                throw new ArgumentException($"Something went wrong while adding the location {ex.Message}");
            }
            return like;

        }

        public async Task<LikeDto> DeleteAsync(LikeDto like, CancellationToken cancellationToken)
        {
            var mappedLike = _mapper.Map<Like>(like);
            var checkedLike = await _likeRepository.GetBySomethingAsync(x => x.Id == mappedLike.Id, cancellationToken);
            if (checkedLike == null)
            {
                throw new NotFoundException("The location wasn't found");
            }

            try
            {
                _likeRepository.DeleteAsync(mappedLike);
                await _saveChangesRepository.SaveChangesAsync();
                _loggerManager.LogInfo("Changes successfully saved in the database");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong while deleting the location {ex.Message}", ex);
            }
            return like;
        }

        public async Task<List<LikeDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var list = await _likeRepository.GetAllAsync(cancellationToken);
            if (list == null)
            {
                throw new NotFoundException("There is no registered likes yet");
            }
            var listDto = _mapper.Map<List<LikeDto>>(list);
            return listDto;
        }

        public async Task<LikeDto> GetLikeByDescriptionAsync(string likeDescription, CancellationToken cancellationToken)
        {
            LikeDto likeDto = new LikeDto();
            var mappedLike = _mapper.Map<Like>(likeDto);
            mappedLike.Description = likeDescription;
            var checkedLike = await _likeRepository.GetBySomethingAsync(x => x.Description == mappedLike.Description, cancellationToken);

            if (checkedLike == null)
            {
                throw new NotFoundException("This like wasn't found");
            }
          
           return _mapper.Map<LikeDto>(checkedLike);
        }
       

        public async Task<LikeDto> GetByIdAsync(LikeDto like, CancellationToken cancellationToken)
        {
            var mappedLike = _mapper.Map<Like>(like);
            var checkedLike = await _likeRepository.GetBySomethingAsync(x => x.Id == mappedLike.Id, cancellationToken);

            if (checkedLike == null)
            {
                throw new NotFoundException("This like wasn't found");
            }

            return _mapper.Map<LikeDto>(checkedLike);
        }


        public async Task<LikeDto> UpdateAsync(LikeDto like, CancellationToken cancellationToken)
        {
            var mappedLike = _mapper.Map<Like>(like);
            var checkedLike = await _likeRepository.GetBySomethingAsync(x => x.Id == mappedLike.Id, cancellationToken); 
            if (checkedLike == null)
            {
                throw new NotFoundException("This like wasn't found");
            }
            try
            {
                checkedLike.Liked = mappedLike.Liked;
                checkedLike.Description = mappedLike.Description;
                _likeRepository.UpdateAsync(mappedLike);
                await _saveChangesRepository.SaveChangesAsync();
                _loggerManager.LogInfo("Changes successfully saved in the database");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong while updating the like {ex.Message}");
            }
            return like;
        }

        public async Task<LikeDto> GetLikeByCreationDateTimeAsync(DateTime creationDateTime, CancellationToken cancellationToken)
        {
            LikeDto likeDto = new LikeDto();
            var mappedLike = _mapper.Map<Like>(likeDto);
            var checkedLike = await _likeRepository.GetBySomethingAsync(x => x.CreationDateTime == mappedLike.CreationDateTime, cancellationToken);

            if (checkedLike == null)
            {
                throw new NotFoundException("This like wasn't found");
            }

            return _mapper.Map<LikeDto>(checkedLike);
        }
    }
}
