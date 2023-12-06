using KodKalendern.Common;
using KodKalendern.Worker.Interfaces;

namespace KodKalendern.Worker;

public partial class DayThree(
    ILogger<DayThree> logger,
    IInputRepository inputRepository)
    : IDay
{
    private readonly IInputRepository _inputRepository = inputRepository ?? throw new ArgumentNullException(nameof(inputRepository));
    private readonly ILogger<DayThree> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task Part1()
    {
        await _inputRepository.GetInputAsync("day.txt");

        var input = _inputRepository.ToList<int>("\n");

        var result = input
            .Where(x => x == input.Average())
            .Count();

        _logger.LogInformation("Part 1: {result}", result);
    }
}

