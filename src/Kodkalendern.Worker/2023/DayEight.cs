using KodKalendern.Common;
using KodKalendern.Worker.Interfaces;

namespace KodKalendern.Worker;

public partial class DayEight(
    ILogger<DayEight> logger,
    IInputRepository inputRepository)
    : IDay
{
    private readonly IInputRepository _inputRepository = inputRepository ?? throw new ArgumentNullException(nameof(inputRepository));
    private readonly ILogger<DayEight> _logger = logger ?? throw new ArgumentNullException(nameof(logger));


    public async Task Part1()
    {
        await _inputRepository.GetInputAsync("day.txt");

        var lines = _inputRepository.ToList<string>("\n")
            .Select(x => x.Split(", ").Select(int.Parse).Sum()).ToList();

        //get unsorted value in the list
        for(var i = 0; i < lines.Count - 1; i++)
        {
            var currentBall = lines[i];
            var nextBall = lines[i + 1];
            //if the next ball is smaller than the current ball, we have found the unsorted ball
            if (nextBall < currentBall)
            {
                _logger.LogInformation("Part 1: {result}", currentBall);
                return;
            }
        }
    }
}

