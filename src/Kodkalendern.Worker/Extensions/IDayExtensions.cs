using KodKalendern.Worker.Interfaces;

namespace KodKalendern.Worker.Extensions;

public static class IDayExtensions
{
    public static async Task ExecuteAsync(this IDay day)
    {
        await day.Part1();
        await day.Part2();
    }
}
