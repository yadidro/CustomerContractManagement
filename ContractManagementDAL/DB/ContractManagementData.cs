using CustomerContractManagement.ContractManagementDAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Contract = CustomerContractManagement.ContractManagementDAL.Models.Contract;

namespace ContractManagementDAL.DB
{
    public interface IContractManagementData
    {
        public Customer GetCustomerInformationById(string id);
        public bool? CheckCustomerExistById(string id);
    }

    public class ContractManagementData : IContractManagementData
    {
        private readonly IConfiguration _configuration;

        public ContractManagementData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Customer GetCustomerInformationById(string id)
        {
            using var conn =
                new SqlConnection(_configuration.GetConnectionString("DatabaseConnection"));
            using var command = new SqlCommand("GetCustomerInformationById", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = id;
            conn.Open();

            var rdr = command.ExecuteReader();
            var customer = GetCustomerFromRdr(rdr);

            conn.Close();

            return customer;
        }

        public bool? CheckCustomerExistById(string id)
        {
            using var conn =
                new SqlConnection(_configuration.GetConnectionString("DatabaseConnection"));
            using var command = new SqlCommand("CheckCustomerExistById", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = id;
            conn.Open();

            var rdr = command.ExecuteReader();
            if (!rdr.Read())
            {
                return null;
            }

            var count = (int)rdr["count"];

            conn.Close();

            return count == 1;
        }

        private static Customer GetCustomerFromRdr(SqlDataReader? rdr)
        {
            var customer = new Customer();
            var contracts = new Dictionary<int, Contract>();
            if (rdr != null)
            {
                while (rdr.Read())
                {
                    if (string.IsNullOrEmpty(customer.ID)) //only for the first line
                    {
                        customer.ID = (string)rdr["ID"];
                        customer.FirstName = (string)rdr["FirstName"];
                        customer.LastName = (string)rdr["LastName"];
                        customer.Address = new Address
                        {
                            City = (string)rdr["City"],
                            Street = (string)rdr["Street"],
                            HomeNumber = (string)rdr["HomeNumber"],
                            PostalCode = (string)rdr["PostalCode"]
                        };
                    }

                    var contractId = (int)rdr["ContractID"];
                    if (contracts.ContainsKey(contractId))
                    {
                        contracts[contractId].Packages?.Add(new Package()
                        {
                            PackageType = (PackageType)rdr["PackageType"],
                            PackageName = (string)rdr["PackageName"],
                            Size = (int)rdr["Size"],
                            Utilzation = (int)rdr["Utilzation"]
                        });
                    }
                    else
                    {
                        contracts.Add(contractId, new Contract
                            {
                                ContractNumber = (string)rdr["ContractNumber"],
                                ContractType = (ContractType)rdr["ContractType"],
                                Packages = new List<Package>
                                {
                                    new Package()
                                    {
                                        PackageType = (PackageType)rdr["PackageType"],
                                        PackageName = (string)rdr["PackageName"],
                                        Size = (int)rdr["Size"],
                                        Utilzation = (int)rdr["Utilzation"]
                                    }
                                }
                            }
                        );
                    }
                }
            }

            customer.Contracts = contracts.Values.ToList();
            return customer;
        }
    }
}