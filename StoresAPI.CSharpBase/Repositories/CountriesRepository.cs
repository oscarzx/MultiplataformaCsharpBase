namespace StoresAPI.CSharpBase.Repositories
{
    public class CountriesRepository : GenericRepository<Country, CSharpbaseContext>
    {
        public CountriesRepository(CSharpbaseContext context)
            :base(context)
        {

        }
    }
}
