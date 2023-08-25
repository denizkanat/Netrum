﻿namespace Netrum.Business.Implementations
{
    using AutoMapper;
    using Infrastructure.Utilities.ApiResponses;
    using Interfaces;
    using Microsoft.AspNetCore.Http;
    using Constants;
    using Infrastructure.CustomExceptions;
    using Netrum.DAL.Interfaces;
    using Model.Dtos.Contact;
    using Model.Entities;

    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        private readonly IMapper _mapper;
        public ContactService(IContactRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

       
        public async Task<ApiResponse<ContactDto>> AddContactAsync(ContactPostDto dto)
        {
            var contact = _mapper.Map<Contact>(dto);
            var insertedContact = await _repository.AddAsync(contact);
            var response = await _repository.GetContactByIdAsync(insertedContact.Id, "Country");
            var mapDto = _mapper.Map<ContactDto>(response);
            return ApiResponse<ContactDto>.Success(StatusCodes.Status201Created, mapDto);
        }

        
        public async Task<ApiResponse<ContactDto>> GetContactAsync(int id, params string[] includeList)
        {
            var contact = await _repository.GetContactByIdAsync(id, includeList);
            if (contact != null)
            {
                var dto = _mapper.Map<ContactDto>(contact);
                return ApiResponse<ContactDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }
        
        public async Task<ApiResponse<List<ContactDto>>> GetContactsAsync(params string[] includeList)
        {
            var contacts = await _repository.GetAllAsync(includeList: includeList);
            if (contacts != null && contacts.Count > 0)
            {
                var returnList = _mapper.Map<List<ContactDto>>(contacts);
                return ApiResponse<List<ContactDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }
    }
}
