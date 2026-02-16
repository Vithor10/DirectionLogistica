namespace ApiLogistica.Models;

public class Entrega
{
    public int Id { get; set; } // O Código de Rastreio da encomenda
    
    // --- VÍNCULO COM O CLIENTE ---
    public int ClienteId { get; set; } // Aqui a gente amarra com o Id do Cliente acima
    
    // --- DADOS DO PACOTE ---
    public string Produto { get; set; } = string.Empty; // Ex: "Notebook Gamer"
    public double PesoKg { get; set; } 

    // --- LOGÍSTICA  ---
    public string EnderecoEntrega { get; set; } = string.Empty;
    
    // Status: "Aguardando Coleta", "Em Trânsito", "Entregue"
    public string Status { get; set; } = "Aguardando Coleta"; 
    
    // --- PRIORIDADE ---
    public bool EhPrioridade { get; set; } // Se for True, aparece primeiro na lista do motorista
    public decimal ValorFrete { get; set; } // Quanto custou
}