using Microsoft.AspNetCore.Mvc;
using ApiLogistica.Models;

namespace ApiLogistica.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EntregasController : ControllerBase
{
    private static List<Entrega> _entregas = new List<Entrega>();

    // LISTAR: Mostra primeiro o que for prioridade (Logística Eficiente)
    [HttpGet]
    public IActionResult ListarEntregas()
    {
        var lista = _entregas.OrderByDescending(e => e.EhPrioridade)
                             .ThenBy(e => e.Id)
                             .ToList();
        return Ok(lista);
    }

    // CADASTRAR: Com cálculo de frete automático
    [HttpPost]
    public IActionResult CriarEntrega([FromBody] Entrega nova)
    {
        // 1. Validação: A entrega precisa ter um produto e um endereço
        if (string.IsNullOrEmpty(nova.Produto) || string.IsNullOrEmpty(nova.EnderecoEntrega))
            return BadRequest("Dados da entrega incompletos.");

        // 2. Lógica de Preço: Taxa base R$ 20 + R$ 5 por Kg
        decimal taxaBase = 20.00m;
        decimal valorPorPeso = (decimal)nova.PesoKg * 5.00m;
        nova.ValorFrete = taxaBase + valorPorPeso;

        // 3. Regra de Prioridade: Se for urgente, taxa extra de 30%
        if (nova.EhPrioridade)
        {
            nova.ValorFrete *= 1.30m;
            nova.Status = "Prioridade Máxima - Aguardando Coleta";
        }

        // 4. Gerar ID e salvar
        nova.Id = _entregas.Any() ? _entregas.Max(e => e.Id) + 1 : 1001;
        _entregas.Add(nova);

        return CreatedAtAction(nameof(ListarEntregas), new { id = nova.Id }, nova);
    }
}