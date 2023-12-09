using KodKalendern.Common;
using KodKalendern.Worker;
using KodKalendern.Worker.Extensions;
using KodKalendern.Worker.Interfaces;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((hostContext, services) =>
{
    services.AddAdventOfCodeCommon();
    services.AddRangeTransient<IDay>();
});

var app = builder.Build();

await app.Services.GetRequiredService<DayTen>().ExecuteAsync();

