namespace Netrum.Business.Implementations;

using AutoMapper;
using DAL.Interfaces;
using Infrastructure.CustomExceptions;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Constants;
using Interfaces;
using Model.Dtos.Movie;
using Model.Entities;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;
    private readonly IMapper _mapper;
    public MovieService(IMovieRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    public async Task<ApiResponse<MovieDto>> AddAsync(MoviePostDto dto)
    {
        var movie = _mapper.Map<Movie>(dto);
        var insertedMovie = await _repository.AddAsync(movie);
        var response = await GetMovieByIdAsync(insertedMovie.Id, "Category");
        return ApiResponse<MovieDto>.Success(StatusCodes.Status201Created, response.Data);
    }

    public async Task<ApiResponse<NoData>> DeleteAsync(int id)
    {
        var movie = await _repository.GetByIdAsync(id);
        if (movie != null)
        {
            await _repository.RemoveAsync(movie);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
        throw new NotFoundException(ErrorMessages.NotFoundId);
    }
    
    public async Task<ApiResponse<MovieDto>> GetMovieByIdAsync(int id, params string[] includeList)
    {
        var movie = await _repository.GetByIdAsync(id, includeList);
        if (movie != null)
        {
            var dto = _mapper.Map<MovieDto>(movie);
            return ApiResponse<MovieDto>.Success(StatusCodes.Status200OK, dto);
        }
        throw new NotFoundException(ErrorMessages.NotFoundId);
    }


    public async Task<ApiResponse<List<MovieDto>>> GetMoviesAsync(params string[] includeList)
    {
        var movies = await _repository.GetAllAsync(includeList: includeList);
        if (movies != null && movies.Count > 0)
        {
            var returnList = _mapper.Map<List<MovieDto>>(movies);
            return ApiResponse<List<MovieDto>>.Success(StatusCodes.Status200OK, returnList);
        }
        throw new NotFoundException(ErrorMessages.NotFoundContent);
    }


    public async Task<ApiResponse<List<MovieDto>>> GetMoviesByDurationRangeAsync(int min, int max, params string[] includeList)
    {
        var movies = await _repository.GetMoviesByDurationRangeAsync(min, max, includeList);
        if (movies != null && movies.Count > 0)
        {
            var moviesDto = _mapper.Map<List<MovieDto>>(movies);
            return ApiResponse<List<MovieDto>>.Success(StatusCodes.Status200OK, moviesDto);
        }
        throw new NotFoundException(ErrorMessages.NotFoundContent);
    }

    public async Task<ApiResponse<List<MovieDto>>> GetMoviesByReleaseDateRangeAsync(DateTime start, DateTime end, params string[] includeList)
    {
        if (start > end)
        {
            throw new BadRequestException(ErrorMessages.StartDateGraterThanEndDate);
        }
        var movies = await _repository.GetMoviesByReleaseDateRangeAsync(start, end, includeList);
        if (movies != null && movies.Count > 0)
        {
            var moviesDto = _mapper.Map<List<MovieDto>>(movies);
            return ApiResponse<List<MovieDto>>.Success(StatusCodes.Status200OK, moviesDto);
        }
        throw new NotFoundException(ErrorMessages.NotFoundContent);
    }
    
    
    public async Task<ApiResponse<NoData>> UpdateAsync(MoviePutDto dto)
    {
        var movie = await _repository.GetByIdAsync(dto.Id);
        if (movie != null)
        {
            var movieDto = _mapper.Map<Movie>(dto);
            await _repository.UpdateAsync(movieDto);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
        throw new NotFoundException(ErrorMessages.NotFoundId);
    }
}