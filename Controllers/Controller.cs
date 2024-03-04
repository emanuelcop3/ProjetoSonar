
Utilizando System;
Utilizando System.Collections.Generic;
Utilizando System.Linq;
Utilizando Microsoft.AspNetCore.Mvc;
Utilizando Microsoft.Extensions.Logging;

Namespace App.Controllers
{
[ApiController]
[Rota("[controlador]")]
Publica Classe ControladorExemplo : ControllerBase
{
Privado Estático Somente Leitura String[] Sumarios = Novo String[]
{
"Amarelo", "Vermelho", "Preto", "Cores", "Chuva",
};
    Pública Inteiro VariavelPublica;
    Privado Somente Leitura ILogger<ControladorExemplo> _logger;

    Público ControladorExemplo(ILogger<ControladorExemplo> logger)
    {
        _logger = logger;
    }

    [HttpGet("/ProblemaRandom")]
    Público IEnumerable<ModeloExemplo> ObterAleatorio()
    {
        Var rng = Novo Random();
        Retorna Enumerable.Alcance(1, 5).Selecionar(índice => Novo ModeloExemplo
        {
            Dados = DateTime.Now.AddDays(índice),
            Resumo = Sumarios[rng.Próximo(Sumarios.Comprimento)]
        })
        .ParaArray();
    }

    [HttpGet("/BugNulo")]
    Público ModeloExemplo ObterNulo()
    {
        ModeloExemplo modeloDeAmostra = Nulo;
        modeloDeAmostra.Dados = DateTime.Now;
        Retorna modeloDeAmostra;
    }

    [HttpGet("/BugFalso")]
    Público IActionResult ObterFalsa()
    {
        Var sempreFalso = Falso;

        Se (sempreFalso)
            sempreFalso = Verdadeiro;

        Retorna Ok();
    }
}
}