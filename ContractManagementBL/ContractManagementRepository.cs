using ContractManagementDAL.DB;
using CustomerContractManagement.ContractManagementDAL.Models;

namespace ContractManagementBL
{
    public interface IContractManagementRepository
    {
        public Customer GetCustomerInformationById(string id);
        public bool CheckCustomerExistById(string id);
    }

    public class ContractManagementRepository : IContractManagementRepository
    {
        private readonly IContractManagementData _contractManagementData;

        public ContractManagementRepository(IContractManagementData contractManagementData)
        {
            _contractManagementData = contractManagementData;
        }

        public Customer GetCustomerInformationById(string id)
        {
            var response = _contractManagementData.GetCustomerInformationById(id);
            if (response == null)
                throw new Exception("something wrong with DB connection");
            return response;
        }

        public bool CheckCustomerExistById(string id)
        {
            var response = _contractManagementData.CheckCustomerExistById(id);
            if (response == null)
                throw new Exception("something wrong with DB connection");
            return (bool)response;
        }
    }
}
