
namespace CustomerContractManagement.ContractManagementDAL.Models
{
    public class Contract
    {
        public string ContractNumber { get; set; }

        public ContractType ContractType { get; set; }

        public List<Package> Packages  { get; set; }

    }

    public enum ContractType
    {
        FixedPrice,
        CostPlus,
        TimeAndMaterial
    }
}

