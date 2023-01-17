
namespace CustomerContractManagement.ContractManagementDAL.Models
{
    public class Customer
    {
        public string ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }

        public List<Contract> Contracts { get; set; }
    }
}

