using KodKalendern.Common;
using KodKalendern.Worker.Interfaces;
using MoreLinq;

namespace KodKalendern.Worker;

public partial class DaySix(
    ILogger<DaySix> logger,
    IInputRepository inputRepository)
    : IDay
{
    private readonly IInputRepository _inputRepository = inputRepository ?? throw new ArgumentNullException(nameof(inputRepository));
    private readonly ILogger<DaySix> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task Part1()
    {
        await _inputRepository.GetInputAsync("day.txt");

        var result = _inputRepository.ToList<string>("\n")
            .Select(x => x.Split(" ").Last())
            .Select(int.Parse)
            .Sum();

        _logger.LogInformation("Part 1: {result}", result);
    }
}