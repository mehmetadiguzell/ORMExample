using Dapper;
using Microsoft.Extensions.Configuration;
using ORMExample.Abstract;
using ORMExample.Concrete;
using ORMExample.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ORMExample.Concrete
{
    public class PersonelRepository : BaseRepository, IPersonelRepository
    {

        public PersonelRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<int> CreateAsync(Personel entity)
        {
            try
            {
                string query = "INSERT INTO Personels (FirstName, LastName, PhoneNumber) VALUES (@FirstName, @LastName, @PhoneNumber)";

                var parameters = new DynamicParameters();
                parameters.Add("FirstName", entity.FirstName, DbType.String);
                parameters.Add("LastName", entity.LastName, DbType.String);
                parameters.Add("PhoneNumber", entity.PhoneNumber, DbType.String);

                using var connection = CreateConnection();
                return (await connection.ExecuteAsync(query, parameters));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> DeleteAsync(Personel entity)
        {
            try
            {
                string query = "DELETE FROM Personels WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", entity.Id, DbType.Int32);

                using var connection = CreateConnection();
                return (await connection.ExecuteAsync(query, parameters));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Personel>> GetAllAsync()
        {
            try
            {
                string query = "SELECT * FROM Personels";
                using var connection = CreateConnection();
                return (await connection.QueryAsync<Personel>(query)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Personel> GetByIdAsync(int id)
        {
            try
            {
                string query = "SELECT * FROM Personels Where Id=@id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);
                using var connection = CreateConnection();
                return (await connection.QueryFirstOrDefaultAsync<Personel>(query, parameters));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(Personel entity)
        {
            try
            {
                string query = "UPDATE Personels SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("FirstName", entity.FirstName, DbType.String);
                parameters.Add("LastName", entity.LastName, DbType.String);
                parameters.Add("PhoneNumber", entity.PhoneNumber, DbType.String);
                parameters.Add("Id", entity.Id, DbType.Int32);

                using var connection = CreateConnection();
                return (await connection.ExecuteAsync(query, parameters));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
