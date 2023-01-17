using CustomerContractManagement.ContractManagementDAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Contract = CustomerContractManagement.ContractManagementDAL.Models.Contract;

namespace ContractManagementDAL.DB
{
    public interface IContractManagementData
    {
        public Customer? GetCustomerInformationById(string id);
        public bool? CheckCustomerExistById(string id);
        public void EditCustomerAddress(Customer Customer);
    }

    public class ContractManagementData : IContractManagementData
    {
        private readonly IConfiguration _configuration;

        public ContractManagementData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Customer? GetCustomerInformationById(string id)
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

        public void EditCustomerAddress(Customer customer)
        {
            using var conn =
                new SqlConnection(_configuration.GetConnectionString("DatabaseConnection"));
            using var command = new SqlCommand("EditCustomerAddress", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = customer.ID;
            command.Parameters.Add("@City", SqlDbType.VarChar).Value = customer.Address.City;
            command.Parameters.Add("@Street", SqlDbType.VarChar).Value = customer.Address.Street;
            command.Parameters.Add("@HomeNumber", SqlDbType.VarChar).Value = customer.Address.HomeNumber;
            command.Parameters.Add("@PostalCode", SqlDbType.VarChar).Value = customer.Address.PostalCode;
            
            conn.Open();
            command.ExecuteReader();
            conn.Close();
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
                            City = rdr["City"] != DBNull.Value ? (string)rdr["City"] : "",
                            Street = rdr["Street"] != DBNull.Value ? (string)rdr["Street"] : "",
                            HomeNumber = rdr["HomeNumber"] != DBNull.Value ? (string)rdr["HomeNumber"] : "",
                            PostalCode = rdr["PostalCode"] != DBNull.Value ? (string)rdr["PostalCode"] : ""
                        };
                    }

                    var contractId = rdr["ContractID"];
                    if (contractId != DBNull.Value)
                    {
                        if (contracts.ContainsKey((int)contractId))
                        {
                            contracts[(int)contractId].Packages?.Add(new Package()
                            {
                                PackageType = (PackageType)rdr["PackageType"],
                                PackageName = (string)rdr["PackageName"],
                                Size = (int)rdr["Size"],
                                Utilzation = (int)rdr["Utilzation"]
                            });
                        }
                        else
                        {
                            contracts.Add((int)contractId, new Contract
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
            }

            customer.Contracts = contracts.Values.ToList();
            return customer;
        }
    }
}