namespace StoresAPI.CSharpBase.Repositories
{
    public class ReportsRepository : GenericRepository<Report, CSharpbaseContext>
    {
        public ReportsRepository(CSharpbaseContext context)
            :base(context)
        {

        }
    }
}
