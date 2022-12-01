using Microsoft.AspNetCore.Mvc;
using Dapr.Client;
using APIContagem.Models;
using APIContagem.Logging;

namespace APIContagem.Controllers;

[ApiController]
[Route("[controller]")]
public class ContadorController : ControllerBase
{
    private readonly ILogger<ContadorController> _logger;
    private readonly IConfiguration _configuration;
    private readonly DaprClient _daprClient;

    public ContadorController(ILogger<ContadorController> logger,
        IConfiguration configuration,
        DaprClient daprClient)
    {
        _logger = logger;
        _configuration = configuration;
        _daprClient = daprClient;
    }

    [HttpGet]
    public async Task<ResultadoContador> Get()
    {
        var storeName = _configuration["Dapr:StoreName"];
        var key = _configuration["Dapr:Key"];

        _logger.LogInformation($"Acessando ultimo valor da chave {key}...");
        var valorAtualContador =
            await _daprClient.GetStateAsync<int>(storeName, key);

        valorAtualContador++;
        _logger.LogInformation($"Registrando novo valor para a chave {key}...");
        await _daprClient.SaveStateAsync(storeName, key, valorAtualContador);
        _logger.LogValorAtual(valorAtualContador);

        return new ()
        {
            ValorAtual = valorAtualContador,
            Producer = ContagemExtensions.Local,
            Kernel = ContagemExtensions.Kernel,
            Framework = ContagemExtensions.Framework,
            StoreName = storeName,
            Mensagem = "Utilizando o Dapr state management building block"
        };
    }
}