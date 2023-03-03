

using Microsoft.AspNetCore.Mvc;
using OnPeople.API.Data;
using OnPeople.API.Models.Empresas;

namespace OnPeople.API.Controllers.Empresas;

[ApiController]
[Route("api/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly DataContext _context;
    public EmpresaController(DataContext context)
    {
        _context = context;

    }


    [HttpGet]
    public IEnumerable<Empresa> Get()
    {
        return _context.Empresas;
    }

    [HttpGet("{id}")]
    public Empresa GetById(int id)
    {
        return _context.Empresas.FirstOrDefault(empresa => empresa.EmpresaId == id);
    }
}
