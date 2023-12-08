using KodKalendern.Common;
using KodKalendern.Worker.Interfaces;

namespace KodKalendern.Worker;

public partial class DaySeven(
    ILogger<DaySeven> logger,
    IInputRepository inputRepository)
    : IDay
{
    private readonly IInputRepository _inputRepository = inputRepository ?? throw new ArgumentNullException(nameof(inputRepository));
    private readonly ILogger<DaySeven> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task Part1()
    {
        await _inputRepository.GetInputAsync("day.txt");

        var result = _inputRepository.ToList<string>("\n")
            .Select(x => x.Split(" ").Last())
            .Select(int.Parse)
            .GroupBy(x => x)
            //take the group with the most items
            .OrderByDescending(x => x.Count())
            //take the first group
            .First()
            //take the key of the group
            .Key;
            

        _logger.LogInformation("Part 1: {@result}", result);
    }
}