using ORMExample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ORMExample.Abstract
{
    public interface IPersonelService
    {

        public Task<List<Personel>> GetAllPersonel();
        public Task<Personel> GetPersonelById(int id);
        public Task<int> CreatePersonelAsync(Personel personel);
        public Task<int> UpdatePersonelAsync(Personel personel);
        public Task<int> DeletePersonelAsync(Personel personel);

    }
}
