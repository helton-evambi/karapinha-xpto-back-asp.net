using KarapinhaDAL.Repositories;
using KarapinhaDTO.Booking;
using KarapinhaDTO.Category;
using KarapinhaDTO.Professional;
using KarapinhaModel;
using KarapinhaShared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapainha.Services
{
    public class ProfessionalService : IProfessionalService
    {
        private readonly ProfessionalRepository _repository;

        public ProfessionalService()
        {
            _repository = new ProfessionalRepository();
        }

        public ProfessionalDto GetById(int id)
        {
            var professional = _repository.GetById(id);
            return ProfessionalMappers.ToProfessioanlDto(professional);
        }

        public IEnumerable<ProfessionalDto> GetAll()
        {
            var professionais = _repository.GetAll();
            return professionais.Select(x => ProfessionalMappers.ToProfessioanlDto(x));
        }

        public IEnumerable<ProfessionalDto> GetByCategory(int categoryId)
        {
            var professionais = _repository.GetByCategory(categoryId);
            return professionais.Select(x => ProfessionalMappers.ToProfessioanlDto(x));
        }

        public IEnumerable<ProfessionalDto> GetByService(int serviceId)
        {
            var professionais = _repository.GetByService(serviceId);
            return professionais.Select(x => ProfessionalMappers.ToProfessioanlDto(x));
        }

        public IEnumerable<ProfessionalDto> GetTop5Professionals()
        {
            var professionais = _repository.GetTop5Professionals();
            return professionais.Select(x => ProfessionalMappers.ToProfessioanlDto(x));
        }

        public int GetCountBooking(int id)
        {
            return _repository.GetCountBooking(id);
        }

        public void CreateProfessional(ProfessionalCreateDto professionalCreateDto)
        {
            var professional = ProfessionalMappers.CreateToProfessional(professionalCreateDto);
            _repository.Add(professional);
            _repository.Save();
        }

        public void DeleteProfessional(int id)
        {
            var professional = _repository.GetById(id);
            try
            {
                if (professional != null)
                {
                    _repository.Delete(professional);
                    _repository.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProfessional(ProfessionalCreateDto professionalCreateDto)
        {
            var professional = ProfessionalMappers.CreateToProfessional(professionalCreateDto);
            _repository.Update(professional);
            _repository.Save();
        }

    }
}
