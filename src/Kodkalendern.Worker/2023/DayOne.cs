using KodKalendern.Common;
using KodKalendern.Worker.Interfaces;

namespace KodKalendern.Worker;

public partial class DayOne(
    ILogger<DayOne> logger,
    IInputRepository inputRepository)
    : IDay
{
    private readonly IInputRepository _inputRepository = inputRepository ?? throw new ArgumentNullException(nameof(inputRepository));
    private readonly ILogger<DayOne> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    private static int CountBetween(int start, int end)
    {
        var result = 0;
        for (var i = start; i <= end; i++)
            result += i;
        return result;
    }

    public async Task Part1()
    {
        await _inputRepository.GetInputAsync("day.txt");

        var result = CountBetween(127, 267) + CountBetween(1110, 1378) + CountBetween(3239293, 3239330);

        _logger.LogInformation("Part 1: {result}", result);
    }
}

