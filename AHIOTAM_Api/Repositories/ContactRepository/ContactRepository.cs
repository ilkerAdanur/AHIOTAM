using AHIOTAM_Api.Dtos.ContactDto;
using AHIOTAM_Api.Models.Context;
using Dapper;

namespace AHIOTAM_Api.Repositories.ContactRepository
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateContact(CreateContactDto createContactDto)
        {
            string query = "INSERT INTO Contact (Title, Description, Address1, Address2,PhoneNumber,Email ,ImageUrl,IsActive) VALUES (@title, @description, @address1, @address2,@phoneNumber,@email,@imageUrl,@isActive)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createContactDto.Title);
            parameters.Add("@description", createContactDto.Description);
            parameters.Add("@address1", createContactDto.Address1);
            parameters.Add("@address2", createContactDto.Address2);
            parameters.Add("@phoneNumber", createContactDto.PhoneNumber);
            parameters.Add("@email", createContactDto.Email);
            parameters.Add("@imageUrl", createContactDto.ImageUrl);
            parameters.Add("@isActive", false);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteContact(int id)
        {
            string query = "Delete from Contact where ContactId = @ContactId";
            var parameters = new DynamicParameters();
            parameters.Add("@ContactId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<ResultContactDto> GetActiveContact()
        {
            string query = "SELECT * FROM Contact where IsActive = 1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultContactDto>(query);
                return values;
            }
        }

        public async Task<List<ResultContactDto>> GetAllContact()
        {
            string query = "SELECT * FROM Contact";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultContactDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdContactDto> GetContactById(int id)
        {
            string query = "Select * from Contact where ContactId = @contactId";
            var parameters = new DynamicParameters();
            parameters.Add("@contactId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdContactDto>(query, parameters);
                return values;
            }
        }
        public async Task UpdateContact(UpdateContactDto updateContactDto)
        {
            string query = "Update Contact set Title = @title, Description = @description, Address1 = @address1, Address2 = @address2, PhoneNumber=@phoneNumber, Email=@email, ImageUrl=@imageUrl where ContactId = @contactId";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateContactDto.Title);
            parameters.Add("@description", updateContactDto.Description);
            parameters.Add("@address1", updateContactDto.Address1);
            parameters.Add("@address2", updateContactDto.Address2);
            parameters.Add("@phoneNumber", updateContactDto.PhoneNumber);
            parameters.Add("@email", updateContactDto.Email);
            parameters.Add("@imageUrl", updateContactDto.ImageUrl);
            parameters.Add("@contactId", updateContactDto.ContactId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task SetActiveContact(int id)
        {
            string deactivateQuery = "UPDATE Contact SET IsActive = 0";
            string activateQuery = "UPDATE Contact SET IsActive = 1 WHERE ContactId = @ContactId";
            var parameters = new DynamicParameters();
            parameters.Add("@ContactId", id);

            using (var connection = _context.CreateConnection())
            {
                connection.Open(); // HATA almamak için bağlantı açık olmalı

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        await connection.ExecuteAsync(deactivateQuery, transaction: transaction);
                        await connection.ExecuteAsync(activateQuery, parameters, transaction: transaction);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

        }
    }
}
