namespace KodKalendern.Common;

public interface IInputRepository
{
    string? Data { get; }

    Task GetInputAsync(string fileName);
    void SetTestData(string testData);
    IEnumerable<IList<TType>> ToEnumerableOfList<TType>(string regex, string separator, int skip = 0);
    IList<TType> ToList<TType>(string regex, int skip = 0);
}