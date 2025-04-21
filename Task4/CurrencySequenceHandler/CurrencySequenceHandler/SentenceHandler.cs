using CurrencySequenceHandler;

public class SentenceHandler
{
    private readonly ISentenceExtractor _extractor;
    private readonly ISentenceFilter _filter;
    private readonly ISentenceTransformer _transformer;

    public event Action<string>? OnSentenceProcessed;

    public SentenceHandler(ISentenceExtractor extractor,
                           ISentenceFilter filter,
                           ISentenceTransformer transformer)
    {
        _extractor = extractor;
        _filter = filter;
        _transformer = transformer;
    }

    public void Subscribe(Action<string> handler)
    {
        OnSentenceProcessed += handler;
    }

    public List<string> GetFilteredSentences(string text)
    {
        var sentences = _extractor.ExtractSentences(text);
        return sentences.Where(s => _filter.ContainsCurrency(s)).ToList();
    }

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
