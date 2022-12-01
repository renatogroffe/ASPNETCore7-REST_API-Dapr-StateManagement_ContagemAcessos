namespace APIContagem.Models;

public class ResultadoContador
{
    public int ValorAtual { get; set; }
    public string? Producer { get; set; }
    public string? Kernel { get; set; }
    public string? Framework { get; set; }
    public string? StoreName { get; set; }
    public string? Mensagem { get; set; }
}