
namespace CustomerContractManagement.ContractManagementDAL.Models
{
    public class Package
    {
        public int ID { get; set; }

        public PackageType PackageType { get; set; }

        public string PackageName { get; set; }

        public int Size  { get; set; }

        public int Utilzation { get; set; }
    }

    public enum PackageType
    {
        Extra,
        Full,
        Partly,
    }
}

