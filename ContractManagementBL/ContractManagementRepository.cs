using ContractManagementDAL.DB;
using CustomerContractManagement.ContractManagementDAL.Models;

namespace ContractManagementBL
{
    public interface IContractManagementRepository
    {
        public Customer GetCustomerInformationById(string id);
        public bool CheckCustomerExistById(string id);
        public void EditCustomerAddress(EditCustomerAddressRequest editCustomerAddressRequest);
    }

    public class ContractManagementRepository : IContractManagementRepository
    {
        private readonly IContractManagementData _contractManagementData;

        private readonly IContractManagementValidator _contractManagementValidator;

        public ContractManagementRepository(IContractManagementData contractManagementData, IContractManagementValidator contractManagementValidator)
        {
            _contractManagementData = contractManagementData;
            _contractManagementValidator = contractManagementValidator;
        }

        public Customer GetCustomerInformationById(string id)
        {
            _contractManagementValidator.ValidateId(id);
            var response = _contractManagementData.GetCustomerInformationById(id);
            if (response == null)
                throw new Exception("Something wrong with DB connection");
            return response;
        }

        public bool CheckCustomerExistById(string id)
        {
            _contractManagementValidator.ValidateId(id);
            var response = _contractManagementData.CheckCustomerExistById(id);
            if (response == null)
                throw new Exception("Something wrong with DB connection");
            return (bool)response;
        }
        
        public void EditCustomerAddress(EditCustomerAddressRequest editCustomerAddressRequest)
        {
            _contractManagementValidator.ValidateCustomer(editCustomerAddressRequest);
            
            var customer = new Customer
            {
                ID = editCustomerAddressRequest.ID,
                Address = new Address
                {
                    City = editCustomerAddressRequest.City,
                    Street = editCustomerAddressRequest.Street,
                    HomeNumber = editCustomerAddressRequest.HomeNumber,
                    PostalCode = editCustomerAddressRequest.PostalCode
                },
            };

            _contractManagementData.EditCustomerAddress(customer);
        }
    }
}
