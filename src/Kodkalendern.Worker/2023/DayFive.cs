using KodKalendern.Common;
using KodKalendern.Worker.Interfaces;

namespace KodKalendern.Worker;

public partial class DayFive(
    ILogger<DayFive> logger,
    IInputRepository inputRepository)
    : IDay
{
    private readonly IInputRepository _inputRepository = inputRepository ?? throw new ArgumentNullException(nameof(inputRepository));
    private readonly ILogger<DayFive> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    private record Bag(int Mark, int Ore, int Ortug, int Pennning)
    {
        public int ToPennning
            => ((Mark * 8 + Ore) * 3 + Ortug) * 8 + Pennning;
    }

    public async Task Part1()
    {
        await _inputRepository.GetInputAsync("day5.txt");

        var result = _inputRepository.ToList<string>("\n")
            .Select(x => x.Split(", "))
            .Select(x => new Bag(int.Parse(x[0]), int.Parse(x[1]), int.Parse(x[2]), int.Parse(x[3])))
            .Select(x => x.ToPennning)
            .Where(x => x >= 1000)
            .Count();

        _logger.LogInformation("Part 1: {result}", result);
    }
}