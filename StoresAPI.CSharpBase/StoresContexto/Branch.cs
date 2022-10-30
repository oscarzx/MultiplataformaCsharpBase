using System;
using System.Collections.Generic;

namespace StoresAPI.CSharpBase.StoresContexto
{
    public partial class Branch
    {
        public int BranchId { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;

        public Branch()
        {

        }

        public Branch(int branchId, string name, string location)
        {
            BranchId = branchId;
            Name = name;
            Location = location;
        }
    }
}
