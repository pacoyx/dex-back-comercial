using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
    {
        var companies = await _companyService.GetAll();
        return Ok(companies);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Company>> GetCompanyById(int id)
    {
        var company = await _companyService.GetById(id);
        if (company == null)
        {
            return NotFound();
        }
        return Ok(company);
    }

    [HttpPost]
    public async Task<ActionResult<Company>> CreateCompany(CreateCompanyDto companyDto)
    {
        var company = companyDto.AsCompany();
        await _companyService.Create(company);
        return CreatedAtAction(nameof(GetCompanyById), new { id = company.Id }, company);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany(int id, UpdateCompanyDto companyDto)
    {        
        var resultUpdate = await _companyService.Update(id, companyDto);
        if (!resultUpdate)
        {
            return NotFound();
        }
        return Ok("company updated successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        var resultDelete = await _companyService.Delete(id);
        if (!resultDelete)
        {
            return NotFound();
        }
        return NoContent();
    }
}
