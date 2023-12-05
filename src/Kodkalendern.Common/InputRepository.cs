using System.Text.RegularExpressions;

namespace KodKalendern.Common;

public class InputRepository
    : IInputRepository
{
    public string? Data { get; private set; }

    public IEnumerable<IList<TType>> ToEnumerableOfList<TType>(string regex, string separator, int skip = 0)
        => Split(regex, skip)
            .Select(x => x.Split(separator).Select(y => (TType)Convert.ChangeType(y, typeof(TType))).ToList());

    public IList<TType> ToList<TType>(string regex, int skip = 0)
        => Split(regex, skip)
            .Select(x => (TType)Convert.ChangeType(x, typeof(TType))).ToList();

    private IEnumerable<string> Split(string regex, int skip = 0)
        => Regex.Split(Data!, regex, RegexOptions.Multiline)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Trim())
            .Skip(skip);

    public async Task GetInputAsync(string fileName)
        => Data = await LoadDataFromFile(fileName) ?? throw new Exception("No data found locally");

    private async Task<string?> LoadDataFromFile(string fileName)
        => File.Exists(fileName)
        ? await File.ReadAllTextAsync(fileName)
        : null;

    public void SetTestData(string testData)
        => Data = testData.Replace("\r", "");
}

