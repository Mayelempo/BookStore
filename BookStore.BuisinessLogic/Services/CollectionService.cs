using AutoMapper;
using BookStore.BusinessLogic.Dtos.Collections;
using BookStore.BusinessLogic.Exceptions;
using BookStore.BusinessLogic.Interfaces;
using BookStore.DataAccess.Interfaces;
using BookStore.DataAccess.Models;


namespace BookStore.BusinessLogic.Services
{
    public class CollectionService : ICollectionService
    {

        private readonly ICollectionRepository _collectionRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly ISaveChangesRepository _saveChangesRepository;
        public CollectionService(ICollectionRepository collectionRepository,
           IMapper mapper,
           ILoggerManager loggerManager,
           ISaveChangesRepository saveChangesRepository)

        {
            _collectionRepository = collectionRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _saveChangesRepository = saveChangesRepository;
        }



        public async Task<CollectionDto> AddAsync(CollectionDto collection, CancellationToken cancellationToken)
        {
            var mappedCollection = _mapper.Map<Collection>(collection);
            var checkedCollection = await _collectionRepository.GetBySomethingAsync(x => x.Id == mappedCollection.Id, cancellationToken);
            if (checkedCollection != null)
            {
                _loggerManager.LogError("Error occured while adding the book");
                throw new AlreadyExistException("This collection already exist");
            }
            _collectionRepository.AddAsync(mappedCollection);
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
            return collection;
        }


        public async Task<CollectionDto> DeleteAsync(CollectionDto collection, CancellationToken cancellationToken)
        {
            var mappedCollection = _mapper.Map<Collection>(collection);
            var checkedCollection = await _collectionRepository.GetBySomethingAsync(x => x.Id == mappedCollection.Id, cancellationToken);
            if (checkedCollection == null)
            {
                throw new NotFoundException("The location wasn't found");
            }

            try
            {
                _collectionRepository.DeleteAsync(mappedCollection);
                await _saveChangesRepository.SaveChangesAsync();
                _loggerManager.LogInfo("Changes successfully saved in the database");
            }
            catch (Exception ex)


            {
                throw new ArgumentException($"Something went wrong while deleting the location {ex.Message}", ex);
            }
            return collection;

        }

        public async Task<List<CollectionDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var list = await _collectionRepository.GetAllAsync(cancellationToken);
            if (list == null)
            {
                throw new NotFoundException("There is no registered collections yet");
            }
            var listDto = _mapper.Map<List<CollectionDto>>(list);
            return listDto;
        }


        public async Task<CollectionDto> GetCollectionByDescriptionAsync(string collectionDescription, CancellationToken cancellationToken)
        {
            CollectionDto collectionDto = new CollectionDto();
            var mappedCollection = _mapper.Map<Collection>(collectionDto);
            mappedCollection.Description = collectionDescription;
            var checkedCollection = await _collectionRepository.GetBySomethingAsync(x => x.Description == mappedCollection.Description, cancellationToken);

            if (checkedCollection == null)
            {
                throw new NotFoundException("This collection wasn't found");
            }
            return _mapper.Map<CollectionDto>(checkedCollection);
        }

        public async Task<CollectionDto> GetCollectionByNameAsync(string collectionName, CancellationToken cancellationToken)
        {
            CollectionDto collectionDto = new CollectionDto();
            var mappedCollection = _mapper.Map<Collection>(collectionDto);
            mappedCollection.Name = collectionName;
            var checkedCollection = await _collectionRepository.GetBySomethingAsync(x => x.Name == mappedCollection.Name, cancellationToken);

            if (checkedCollection == null)
            {
                throw new NotFoundException("This collection wasn't found");
            }
            return _mapper.Map<CollectionDto>(checkedCollection);
        }
        public async Task<CollectionDto> GetByIdAsync(CollectionDto collection, CancellationToken cancellationToken)
        {
            var mappedCollection = _mapper.Map<Collection>(collection);
            var checkedCollection = await _collectionRepository.GetBySomethingAsync(x => x.Id == mappedCollection.Id, cancellationToken);

            if (checkedCollection == null)
            {
                throw new NotFoundException("This collection wasn't found");
            }
            return _mapper.Map<CollectionDto>(checkedCollection);
        }

        public async Task<CollectionDto> UpdateAsync(CollectionDto collection, CancellationToken cancellationToken)
        {
            var mappedCollection = _mapper.Map<Collection>(collection);
            var checkedCollection = await _collectionRepository.GetBySomethingAsync(x => x.Id == mappedCollection.Id, cancellationToken);
            if (checkedCollection == null)
            {
                throw new NotFoundException("This collection wasn't found");
            }
            try
            {
                checkedCollection.Name = mappedCollection.Name;
                checkedCollection.Description = mappedCollection.Description;
                _collectionRepository.UpdateAsync(mappedCollection);
                await _saveChangesRepository.SaveChangesAsync();
                _loggerManager.LogInfo("Changes successfully saved in the database");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong while updating the collection {ex.Message}");
            }
            return collection;
        }

        public async Task<CollectionDto> GetCollectionByTagAsync(string tag, CancellationToken cancellationToken)
        {
            CollectionDto collectionDto = new CollectionDto();
            var mappedCollection = _mapper.Map<Collection>(collectionDto);
            var checkedCollection = await _collectionRepository.GetBySomethingAsync(x => x.Tags == mappedCollection.Tags, cancellationToken);

            if (checkedCollection == null)
            {
                throw new NotFoundException("This like wasn't found");
            }

            return _mapper.Map<CollectionDto>(checkedCollection);

        }
    }
}