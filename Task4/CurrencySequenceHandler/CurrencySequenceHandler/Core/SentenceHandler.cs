using CurrencySequenceHandler.Services;

public class SentenceHandler
{
    private readonly ISentenceExtractor _extractor;
    private readonly ISentenceFilter _filter;
    private readonly ISentenceTransformer _transformer;

    public event Action<string>? OnSentenceProcessed;

    /// <summary>
    /// Initializes a new instance of the <see cref="SentenceHandler"/> class.
    /// </summary>
    /// <param name="extractor"></param>
    /// <param name="filter"></param>
    /// <param name="transformer"></param>
    public SentenceHandler(ISentenceExtractor extractor,
                           ISentenceFilter filter,
                           ISentenceTransformer transformer)
    {
        _extractor = extractor;
        _filter = filter;
        _transformer = transformer;
    }

    /// <summary>
    /// Subscribes to the OnSentenceProcessed event.
    /// </summary>
    /// <param name="handler"></param>
    public void Subscribe(Action<string> handler)
    {
        OnSentenceProcessed += handler;
    }

    /// <summary>
    /// Filters sentences from the given text based on the presence of currency.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public List<string> GetFilteredSentences(string text)
    {
        var sentences = _extractor.ExtractSentences(text);
        return sentences.Where(s => _filter.ContainsCurrency(s)).ToList();
    }

    /// <summary>
    /// Processes sentences from the given text and invokes the OnSentenceProcessed event for each filtered sentence.
    /// </summary>
    /// <param name="text"></param>
    public void ProcessSentences(string text)
    {
        var filtered = GetFilteredSentences(text);
        foreach (var sentence in filtered)
        {
            var result = _transformer.Transform(sentence);
            OnSentenceProcessed?.Invoke(result);
        }
    }
}
