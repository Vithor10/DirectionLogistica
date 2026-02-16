using Microsoft.AspNetCore.Mvc;
using ApiLogistica.Models;

namespace ApiLogistica.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private static List<Cliente> _clientes = new List<Cliente>();

    // 1. LISTAR TODOS (Com verificação se está vazio)
    [HttpGet]
    public IActionResult ListarTodos()
    {
        if (_clientes.Count == 0) return NoContent(); // Retorna 204 se não houver ninguém
        return Ok(_clientes);
    }

    // 2. BUSCAR POR ID (detalhar o cliente específico)
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var cliente = _clientes.FirstOrDefault(c => c.Id == id);
        if (cliente == null) return NotFound($"Cliente com ID {id} não encontrado no sistema.");
        
        return Ok(cliente);
    }

    // 3. CADASTRAR (Com validação real)
    [HttpPost]
    public IActionResult Cadastrar([FromBody] Cliente novoCliente)
    {
        // Validação de segurança básica
        if (string.IsNullOrEmpty(novoCliente.Nome)) 
            return BadRequest("O nome do cliente é obrigatório para o cadastro.");

        if (string.IsNullOrEmpty(novoCliente.Cpf) || novoCliente.Cpf.Length < 11)
            return BadRequest("CPF inválido. Verifique os dados.");

        // Lógica de ID automático
        novoCliente.Id = _clientes.Any() ? _clientes.Max(c => c.Id) + 1 : 1;
        
        _clientes.Add(novoCliente);

        //  retornamos o link de onde o recurso foi criado
        return CreatedAtAction(nameof(BuscarPorId), new { id = novoCliente.Id }, novoCliente);
    }
}