using ORMExample.Abstract;
using ORMExample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ORMExample.Concrete
{
    public class PersonelService : IPersonelService
    {
        private readonly IPersonelRepository _personelRepository;

        public PersonelService(IPersonelRepository personelRepository)
        {
            _personelRepository = personelRepository;
        }

        public async Task<int> CreatePersonelAsync(Personel personel)
        {
            return await _personelRepository.CreateAsync(personel);
        }

        public async Task<int> DeletePersonelAsync(Personel personel)
        {
            return await _personelRepository.DeleteAsync(personel);
        }

        public async Task<List<Personel>> GetAllPersonel()
        {
            return await _personelRepository.GetAllAsync();
        }

        public async Task<Personel> GetPersonelById(int id)
        {
            return await _personelRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdatePersonelAsync(Personel personel)
        {
            return await _personelRepository.UpdateAsync(personel);
        }
    }
}
