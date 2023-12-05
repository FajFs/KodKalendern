using KodKalendern.Common;
using KodKalendern.Worker.Interfaces;
using MoreLinq;

namespace KodKalendern.Worker;

public partial class DayFive(
    ILogger<DayFive> logger,
    IInputRepository inputRepository)
    : IDay
{
    private readonly IInputRepository _inputRepository = inputRepository ?? throw new ArgumentNullException(nameof(inputRepository));
    private readonly ILogger<DayFive> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task Part1()
    {
        await _inputRepository.GetInputAsync("day5.txt");

        var input = _inputRepository.ToList<string>("\n");

        _logger.LogInformation("Part 1: {result}", input);
    }

    public async Task Part2()
    {
        await _inputRepository.GetInputAsync("day5.txt");

        //_logger.LogInformation("Part 2: {result}", minvalue);
    }
}