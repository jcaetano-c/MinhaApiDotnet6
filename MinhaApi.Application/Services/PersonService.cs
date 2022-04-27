using AutoMapper;
using MinhaApi.Application.DTOs;
using MinhaApi.Application.DTOs.Validations;
using MinhaApi.Application.Services.Interfaces;
using MinhaApi.Domain.Entitites;
using MinhaApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaApi.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
                return ResultService.Fail<PersonDTO>("ResultService: Object must be passed.");

            var result = new PersonDTOValidator().Validate(personDTO);
            if (!result.IsValid)
                return ResultService.RequestError<PersonDTO>("Problemns on validate", result);

            var person = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.CreateAsync(person);
            return ResultService.Success<PersonDTO>(_mapper.Map<PersonDTO>(data));
        }


        public async Task<ResultService<ICollection<PersonDTO>>> GetAsync()
        {
            var people = await _personRepository.GetPeopleAsync();
            return ResultService.Success<ICollection<PersonDTO>>(_mapper.Map<ICollection<PersonDTO>>(people));
        }

        public async Task<ResultService<PersonDTO>> GetByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsyc(id);
            if (person is null)
                return ResultService.Fail<PersonDTO>("Person not found");
            return ResultService.Success(_mapper.Map<PersonDTO>(person));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var person = await _personRepository.GetByIdAsyc(id);
            if (person is null)
                return ResultService.Fail("Person not found");

            await _personRepository.DeleteAsync(person);
            return ResultService.Success($"Person with id {id} was removed.");

        }

        public async Task<ResultService> UpdatedAsync(PersonDTO personDTO)
        {
            if(personDTO is null)
                return ResultService.Fail("Object must be passed.");

            var validation = new PersonDTOValidator().Validate(personDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problem balidating fields.", validation);

            var person = await _personRepository.GetByIdAsyc(personDTO.Id);
            Console.WriteLine(person);
            if (person == null)
                return ResultService.Fail("Person not found.");

            //var person = _mapper.Map<Person>(personDTO); -- Inserir
            person = _mapper.Map<PersonDTO, Person>(personDTO, person); // - Editar

            await _personRepository.EditAsync(person);
            return ResultService.Success($"Person wit id {person.Id} updated");
        }
    }
}
