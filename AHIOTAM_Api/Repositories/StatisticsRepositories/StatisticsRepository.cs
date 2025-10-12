using AHIOTAM_Api.Dtos.CategoryDto;
using AHIOTAM_Api.Models.Context;
using Dapper;
using System.Threading.Tasks;

namespace AHIOTAM_Api.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }
        public int ActiveCategoryCount()
        {
            string query = "SELECT COUNT(*) FROM Category WHERE CategoryStatus = 1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ActiveMenuCount()
        {
            string query = "SELECT COUNT(*) FROM Menu WHERE MenuStatus = 1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int CategoryCount()
        {
            string query = "SELECT COUNT(*) FROM Category";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string CategoryNameByMaxMenuCount()
        {
            string query = @" SELECT TOP 1 c.CategoryName FROM Category c JOIN Menu m ON c.CategoryId = m.MenuCategoryId GROUP BY c.CategoryName ORDER BY COUNT(m.MenuId) DESC";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int MenuCount()
        {
            string query = "SELECT COUNT(*) FROM Menu";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int PassiveCategoryCount()
        {
            string query = "SELECT COUNT(*) FROM Category WHERE CategoryStatus = 0";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int PassiveMenuCount()
        {
            string query = "SELECT COUNT(*) FROM Menu WHERE MenuStatus = 0";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
    }
}
