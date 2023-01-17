using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace ContractManagementBL
{
    public interface IContractManagementValidator
    {
        public void ValidateId(string id);
        public void ValidateCustomer(EditCustomerAddressRequest editCustomerAddressRequest);
    }

    public class ContractManagementValidator : IContractManagementValidator
    {
        public void ValidateCustomer(EditCustomerAddressRequest editCustomerAddressRequest)
        {
            ValidateId(editCustomerAddressRequest.ID);

            if (!Regex.IsMatch(editCustomerAddressRequest.City, @"^$|^[a-zA-ZÀ-ÖØ-öø-ÿ0-9 ]+$"))
                throw new ArgumentException("City contains special characters");

            if (!Regex.IsMatch(editCustomerAddressRequest.Street, @"^$|^[a-zA-ZÀ-ÖØ-öø-ÿ0-9 ]+$"))
                throw new ArgumentException("Street contains special characters");

            if (!Regex.IsMatch(editCustomerAddressRequest.PostalCode, @"^$|^[a-zA-ZÀ-ÖØ-öø-ÿ0-9 ]+$"))
                throw new ArgumentException("PostalCode contains special characters");

            if (!Regex.IsMatch(editCustomerAddressRequest.HomeNumber, @"^$|^[a-zA-ZÀ-ÖØ-öø-ÿ0-9 ]+$"))
                throw new ArgumentException("passenger name contains special characters");
        }

        public void ValidateId(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("ID cannot be empty");

            if (!Regex.IsMatch(id, @"^$|^[0-9 ]+$"))
                throw new ArgumentException("ID value is not valid");
        }
    }
}