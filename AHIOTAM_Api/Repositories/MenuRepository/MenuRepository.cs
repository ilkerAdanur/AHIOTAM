using AHIOTAM_Api.Dtos.MenuDto;
using AHIOTAM_Api.Models.Context;
using Dapper;

namespace AHIOTAM_Api.Repositories.MenuRepository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly Context _context;

        public MenuRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateMenu(CreateMenuDto createMenuDto)
        {
            string query = "INSERT INTO Menu (FoodPrice, FoodTitle, FoodDescription, FoodImageUrl,MenuCategoryId) VALUES (@foodPrice, @foodTitle, @foodDescription, @foodImageUrl,@menuCategoryId)";
            var parameters = new DynamicParameters();
            parameters.Add("@foodPrice", createMenuDto.FoodPrice);
            parameters.Add("@foodTitle", createMenuDto.FoodTitle);
            parameters.Add("@foodDescription", createMenuDto.FoodDescription);
            parameters.Add("@foodImageUrl", createMenuDto.FoodImageUrl);
            parameters.Add("@menuCategoryId", createMenuDto.MenuCategoryId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteMenu(int id)
        {
            string query = "Delete from Menu where MenuId = @MenuId";
            var parameters = new DynamicParameters();
            parameters.Add("@MenuId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultMenuDto>> GetAllMenu()
        {
            string query = "SELECT * FROM Menu";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultMenuDto>(query);
                return values.ToList();
            }
        }


        public async Task<GetByIdMenuDto> GetMenuById(int id)
        {
            string query = "Select * from Menu where MenuId = @menuId";
            var parameters = new DynamicParameters();
            parameters.Add("@menuId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdMenuDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultMenuWithCategoryDto>> GetAllMenuWithCategory()
        {
            string query = "SELECT MenuId, FoodPrice, FoodTitle, FoodDescription, FoodImageUrl, CategoryName, CategoryStatus,CategoryElementId,MenuStatus,SpicealMenu FROM Menu Inner JOIN Category ON Category.CategoryId = Menu.MenuCategoryId";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultMenuWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateMenu(UpdateMenuDto updateMenuDto)
        {
            string query = "Update Menu set FoodPrice = @foodPrice, FoodTitle = @foodTitle, FoodDescription = @foodDescription, FoodImageUrl = @foodImageUrl where MenuId = @menuId";
            var parameters = new DynamicParameters();
            parameters.Add("@foodPrice", updateMenuDto.FoodPrice);
            parameters.Add("@foodTitle", updateMenuDto.FoodTitle);
            parameters.Add("@foodDescription", updateMenuDto.FoodDescription);
            parameters.Add("@foodImageUrl", updateMenuDto.FoodImageUrl);
            parameters.Add("@menuId", updateMenuDto.MenuId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultLast3MenuWithCategoryDto>> GetLast3MenuWithCategory()
        {
            string query = "Select Top(3) MenuId, FoodPrice, FoodTitle, FoodDescription, FoodImageUrl, CategoryName, CategoryStatus,CategoryElementId,MenuStatus FROM Menu Inner JOIN Category ON Category.CategoryId = Menu.MenuCategoryId where MenuStatus = 1 order by Menu.MenuId desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast3MenuWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task MenuStatusChangeToFalse(int id)
        {
            string query = "Update Menu set MenuStatus=0 where MenuId=@menuId";
            var parameters = new DynamicParameters();
            parameters.Add("@menuId", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task MenuStatusChangeToTrue(int id)
        {
            string query = "Update Menu set MenuStatus=1 where MenuId=@menuId";
            var parameters = new DynamicParameters();
            parameters.Add("@menuId", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task ToggleSpicealMenu(int id)
        {
            string query = "Update Menu set SpicealMenu = CASE WHEN SpicealMenu = 1 THEN 0 ELSE 1 END where MenuId = @menuId";
            var parameters = new DynamicParameters();
            parameters.Add("@menuId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultMenuWithCategoryDto>> GetTop6MenusPerCategoryAsync()
        {
            string query = @"SELECT * FROM (SELECT Menu.MenuId, Menu.FoodPrice, Menu.FoodTitle, Menu.FoodDescription, Menu.FoodImageUrl, Menu.MenuStatus, Menu.SpicealMenu, Category.CategoryName, Category.CategoryStatus, Category.CategoryElementId, ROW_NUMBER() OVER(PARTITION BY Category.CategoryId ORDER BY Menu.MenuId DESC) AS RowNum FROM Menu INNER JOIN Category ON Category.CategoryId = Menu.MenuCategoryId WHERE Menu.MenuStatus = 1) AS GroupedMenus WHERE GroupedMenus.RowNum <= 6 ORDER BY GroupedMenus.CategoryName, GroupedMenus.RowNum;";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultMenuWithCategoryDto>(query);
                return values.ToList();
            }
        }

    }
}
