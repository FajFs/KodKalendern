using KodKalendern.Common;
using KodKalendern.Worker.Interfaces;

namespace KodKalendern.Worker;

public partial class DayNine(
    ILogger<DayNine> logger,
    IInputRepository inputRepository)
    : IDay
{
    private readonly IInputRepository _inputRepository = inputRepository ?? throw new ArgumentNullException(nameof(inputRepository));
    private readonly ILogger<DayNine> _logger = logger ?? throw new ArgumentNullException(nameof(logger));


    public async Task Part1()
    {
        await _inputRepository.GetInputAsync("day.txt");

        var result = _inputRepository.ToList<string>("\n")
            .First()
            //remove satelite
            .Replace("/*", "")
            //remove UFO
            .Replace("*U", "")
            .Count(x => x == '*');

        _logger.LogInformation("Resultatet är {result}", result);
    }
}

