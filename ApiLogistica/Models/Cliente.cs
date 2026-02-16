namespace ApiLogistica.Models;

public class Cliente
{
    public int Id { get; set; } // O crachá do cliente (1, 2, 3...)
    
    public string Nome { get; set; } = string.Empty; // Ex: Vithor
    
    public string Cpf { get; set; } = string.Empty; // ex: "123.456.78-90"
    
    public string EnderecoPadrao { get; set; } = string.Empty; // Para facilitar a entrega
}