namespace StoresAPI.CSharpBase.Repositories
{
    public class BranchesRepository : GenericRepository<Branch, CSharpbaseContext>
    {
        public BranchesRepository(CSharpbaseContext context)
            :base(context)
        {
        }
    }
}
