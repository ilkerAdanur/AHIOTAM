namespace AHIOTAM_Api.Repositories.StatisticsRepositories
{
    public interface IStatisticsRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        int MenuCount();
        int ActiveMenuCount();
        int PassiveMenuCount();
        String CategoryNameByMaxMenuCount();

    }
}
