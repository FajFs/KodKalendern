using KodKalendern.Common;
using KodKalendern.Worker.Interfaces;

namespace KodKalendern.Worker;

public partial class DayTen(
    ILogger<DayTen> logger,
    IInputRepository inputRepository)
    : IDay
{
    private readonly IInputRepository _inputRepository = inputRepository ?? throw new ArgumentNullException(nameof(inputRepository));
    private readonly ILogger<DayTen> _logger = logger ?? throw new ArgumentNullException(nameof(logger));


    public async Task Part1()
    {
        await _inputRepository.GetInputAsync("day.txt");

        //_logger.LogInformation("Part 1: {result}", result);
    }
}

