namespace CadastroPrefeitura.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Adicionar mensagem de erro
        public string? ErrorMessage { get; set; }

        // Adicionar código de status HTTP associado ao erro
        public int? StatusCode { get; set; }

        // Indicar se o erro foi interno ou relacionado ao usuário
        public bool IsInternalError => StatusCode >= 500;

        // Adicionar data e hora do erro
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // Método auxiliar para criar mensagens completas
        public string FullMessage => $"{Timestamp:yyyy-MM-dd HH:mm:ss} | Code: {StatusCode} | Message: {ErrorMessage}";
    }
}
