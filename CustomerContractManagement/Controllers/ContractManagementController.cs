using ContractManagementBL;
using CustomerContractManagement.ContractManagementDAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContractManagementAPI.Controllers;

[ApiController]
[Route("")]
public class ContractManagementController : ControllerBase
{
    private readonly ILogger<ContractManagementController> _logger;

    private readonly IContractManagementRepository _contractManagementRepository;

    public ContractManagementController(ILogger<ContractManagementController> logger, IContractManagementRepository contractManagementRepository)
    {
        _logger = logger;
        _contractManagementRepository = contractManagementRepository;
    }

    [Route("GetCustomer")]
    [HttpGet]
    public IActionResult Get([FromQuery]string id)
    {
        try
        {
            _logger.LogInformation("Got GetCustomer request at {DT}",
           DateTime.UtcNow.ToLongTimeString());

            var res = _contractManagementRepository.GetCustomerInformationById(id);

            _logger.LogInformation("GetCustomer successfully handled {DT}",
         DateTime.UtcNow.ToLongTimeString());

            return Ok(res);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);

            return BadRequest(e.Message);
        }
    }
    
    [Route("CheckCustomer")]
    [HttpGet]
    public IActionResult GetCheckCustomer([FromQuery]string id)
    {
        try
        {
            _logger.LogInformation("Got CheckCustomer request at {DT}",
                DateTime.UtcNow.ToLongTimeString());

            var res = _contractManagementRepository.CheckCustomerExistById(id);

            _logger.LogInformation("CheckCustomer successfully handled {DT}",
                DateTime.UtcNow.ToLongTimeString());

            return Ok(res);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);

            return BadRequest(e.Message);
        }
    }

    [Route("EditCustomer")]
    [HttpPost]
    public IActionResult PostEditCustomer([FromBody] EditCustomerAddressRequest editCustomerAddressRequest)
    {
        try
        {
            _logger.LogInformation("Edit Customer request at {DT}",
           DateTime.UtcNow.ToLongTimeString());
    
            _contractManagementRepository.EditCustomerAddress(editCustomerAddressRequest);
    
            _logger.LogInformation("EditCustomer successfully handled {DT}",
          DateTime.UtcNow.ToLongTimeString());
    
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
    
            return BadRequest(e.Message);
        }
    }
}