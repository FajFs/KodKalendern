using KodKalendern.Common;
using KodKalendern.Worker.Interfaces;

namespace KodKalendern.Worker;

public partial class DayFour(
    ILogger<DayFour> logger,
    IInputRepository inputRepository)
    : IDay
{
    private readonly IInputRepository _inputRepository = inputRepository ?? throw new ArgumentNullException(nameof(inputRepository));
    private readonly ILogger<DayFour> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task Part1()
    {
        await _inputRepository.GetInputAsync("day.txt");

        var northPoleCordinate = 106023;
        var result = _inputRepository.ToList<int>("\n")
            .Select(x => Math.Abs(x - northPoleCordinate))
            .Min();

        _logger.LogInformation("Part 1: {result}", result);
    }
}

