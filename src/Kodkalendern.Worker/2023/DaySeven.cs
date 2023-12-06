using KodKalendern.Common;
using KodKalendern.Worker.Interfaces;
using MoreLinq;

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

        //_logger.LogInformation("Part 1: {result}", result);
    }
}