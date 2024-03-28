using AutoMapper;
using BookStore.BusinessLogic.Dtos.Categories;
using BookStore.BusinessLogic.Exceptions;
using BookStore.BusinessLogic.Interfaces;
using BookStore.DataAccess.Interfaces;
using BookStore.DataAccess.Models;

namespace BookStore.BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly ISaveChangesRepository _saveChangesRepository;

        public CategoryService(ICategoryRepository categoryRepository,
          IMapper mapper,
          ILoggerManager loggerManager,
          ISaveChangesRepository saveChangesRepository)


        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _saveChangesRepository = saveChangesRepository;
        }


        public async Task<CategoryDto> AddAsync(CategoryDto category, CancellationToken cancellationToken)
        {
            var mappedCategory = _mapper.Map<Category>(category);
            var checkedCategory = await _categoryRepository.GetBySomethingAsync(x => x.Id == mappedCategory.Id, cancellationToken);
            if (checkedCategory != null)
            {
                _loggerManager.LogError("Error occured while adding the category");
                throw new AlreadyExistException("This category already exist");
            }
            _categoryRepository.AddAsync(mappedCategory);
            try
            {
                await _saveChangesRepository.SaveChangesAsync();
                _loggerManager.LogInfo("Changes successfully saved in the database");
            }
            catch (Exception ex)
            {

                _loggerManager.LogInfo($"Error occured while adding a category{ex.Message}");
                throw new ArgumentException($"Something went wrong while adding the location {ex.Message}");
            }
            return category;
        }


        public async Task<CategoryDto> DeleteAsync(CategoryDto category, CancellationToken cancellationToken)
        {
            var mappedCategory = _mapper.Map<Category>(category);
            var checkedCategory = await _categoryRepository.GetBySomethingAsync(x => x.Id == mappedCategory.Id, cancellationToken);
            if (checkedCategory == null)
            {
                throw new NotFoundException("The location wasn't found");
            }

            try
            {
                _categoryRepository.DeleteAsync(mappedCategory);
                await _saveChangesRepository.SaveChangesAsync();
                _loggerManager.LogInfo("Changes successfully saved in the database");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong while deleting the location {ex.Message}", ex);
            }
            return category;
        }
        public async Task<List<CategoryDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetAllAsync(cancellationToken);
            if (list == null)
            {
                throw new NotFoundException("There is no registered category yet");
            }
            var listDto = _mapper.Map<List<CategoryDto>>(list);
            return listDto;

        }

        public Task<CategoryDto> GetByIdAsync(CategoryDto entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }



        public async Task<CategoryDto> GetCategoryByNameAsync(string categoryName, CancellationToken cancellationToken)
        {
            CategoryDto categoryDto = new CategoryDto();
            var mappedCategory = _mapper.Map<Category>(categoryDto);
            mappedCategory.Name = categoryName;
            var checkedCategory = await _categoryRepository.GetBySomethingAsync(x => x.Name == mappedCategory.Name, cancellationToken);

            if (checkedCategory == null)
            {
                throw new NotFoundException("This caterory wasn't found");
            }
            return _mapper.Map<CategoryDto>(checkedCategory);
        }


        public async Task<CategoryDto> UpdateAsync(CategoryDto category, CancellationToken cancellationToken)
        {
            var mappedCategory = _mapper.Map<Category>(category);
            var checkedCategory = await _categoryRepository.GetBySomethingAsync(x => x.Id == mappedCategory.Id, cancellationToken);
            if (checkedCategory == null)
            {
                throw new NotFoundException("This category wasn't found");
            }
            try
            {
                checkedCategory.Name = mappedCategory.Name;
                _categoryRepository.UpdateAsync(mappedCategory);
                await _saveChangesRepository.SaveChangesAsync();
                _loggerManager.LogInfo("Changes successfully saved in the database");
            }


            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong while updating the category {ex.Message}");
            }
            return category;
        }


}   }         

        


