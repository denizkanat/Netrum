namespace Netrum.Business.Implementations
{
    using AutoMapper;
    using Infrastructure.CustomExceptions;
    using Infrastructure.Utilities.ApiResponses;
    using Microsoft.AspNetCore.Http;
    using Constants;
    using Interfaces;
    using Netrum.DAL.Interfaces;
    using Model.Dtos.Person;
    using Model.Entities;

    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        
        public async Task<ApiResponse<PersonDto>> AddAsync(PersonPostDto dto)
        {
            var person = _mapper.Map<Person>(dto);
            var insertedPerson = await _repository.AddAsync(person);
            var response = await GetPersonByIdAsync(insertedPerson.Id, "PersonRatings", "PersonRatings.User", "MoviePersons", "MoviePersons.Movie", "MoviePersons.PersonType", "Country", "Gender");
            return ApiResponse<PersonDto>.Success(StatusCodes.Status201Created, response.Data);
        }

      
        public async Task<ApiResponse<NoData>> DeleteAsync(int personId)
        {
            var person = await _repository.GetPersonByIdAsync(personId);
            if (person != null)
            {
                await _repository.RemoveAsync(person);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }

 
        public async Task<ApiResponse<PersonDto>> GetPersonByIdAsync(int personId, params string[] includeList)
        {
            var person = await _repository.GetPersonByIdAsync(personId, includeList);
            if (person != null)
            {
                var dto = _mapper.Map<PersonDto>(person);
                return ApiResponse<PersonDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }

   
        public async Task<ApiResponse<List<PersonDto>>> GetPersonsAsync(params string[] includeList)
        {
            var persons = await _repository.GetAllAsync(includeList: includeList);
            if (persons != null && persons.Count > 0)
            {
                var dtoList = _mapper.Map<List<PersonDto>>(persons);
                return ApiResponse<List<PersonDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }


        public async Task<ApiResponse<List<PersonDto>>> GetPersonsByAgeRangeAsync(int min, int max, params string[] includeList)
        {
            var persons = await _repository.GetPersonsByAgeRangeAsync(min, max, includeList);
            if (persons != null && persons.Count > 0)
            {
                var dto = _mapper.Map<List<PersonDto>>(persons);
                return ApiResponse<List<PersonDto>>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }
        
        
        public async Task<ApiResponse<NoData>> UpdateAsync(PersonPutDto dto)
        {
            var person = await _repository.GetPersonByIdAsync(dto.Id);
            if (person != null)
            {
                var updatePerson = _mapper.Map<Person>(dto);
                await _repository.UpdateAsync(updatePerson);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }
    }
}
