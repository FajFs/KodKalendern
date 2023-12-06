using KodKalendern.Common;
using KodKalendern.Worker.Interfaces;

namespace KodKalendern.Worker;

public partial class DayTwo(
    ILogger<DayTwo> logger,
    IInputRepository inputRepository)
    : IDay
{
    private readonly IInputRepository _inputRepository = inputRepository ?? throw new ArgumentNullException(nameof(inputRepository));
    private readonly ILogger<DayTwo> _logger = logger ?? throw new ArgumentNullException(nameof(logger));


    public async Task Part1()
    {
        await _inputRepository.GetInputAsync("day.txt");

        var result = _inputRepository.ToList<int>("\n")
            .Select(x => x * 28)
            .Where(x => x >= 2000 && x <= 3000)
            .Count();

        _logger.LogInformation("Part 1: {result}", result);
    }
}

