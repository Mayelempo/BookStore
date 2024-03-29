using BookStore.BusinessLogic.Dtos.Collections;
using BookStore.BusinessLogic.Dtos.Users;
using BookStore.BusinessLogic.Interfaces;
using BookStore.BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookStore.Presentation.Controllers
{
    public class CollectionController : Controller
    {

        private readonly ICollectionService _collectionService;
        public CollectionController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync(CollectionDto collection, CancellationToken cancellationToken)
        {
            var result = await _collectionService.AddAsync(collection,cancellationToken);
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAsync(CollectionDto collection, CancellationToken cancellationToken)
        {
            var result = await _collectionService.DeleteAsync(collection,cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _collectionService.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCollectionByDescriptionAsync(string collectionDescription, CancellationToken cancellationToken)
        {
            var result = await _collectionService.GetCollectionByDescriptionAsync(collectionDescription, cancellationToken);
            return Ok(result);

        }


            [HttpGet("{name}")]
            [ProducesResponseType((int)HttpStatusCode.OK)]
            public async Task<IActionResult> GetCollectionByNameAsync(string collectionName, CancellationToken cancellationToken)
            {
                var result = await _collectionService.GetCollectionByNameAsync(collectionName, cancellationToken);
                return Ok(result);
            }


            [HttpGet("{email}")]
            [ProducesResponseType((int)HttpStatusCode.OK)]
            public async Task<IActionResult> GetByIdAsync(CollectionDto collection, CancellationToken cancellationToken)
            {
                var result = await _collectionService.GetByIdAsync(collection, cancellationToken);
                return Ok(result);
            }

        [HttpPut("{UserCreateDto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(CollectionDto collection, CancellationToken cancellationToken)
        {
            var result = await _collectionService.UpdateAsync(collection, cancellationToken);
            return Ok(result);
        }
    }
}
