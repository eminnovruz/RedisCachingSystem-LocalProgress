using System.ComponentModel;

namespace AzureRedisCachingSystem.CacheMonitoring.Stat;

public class CacheObjectMetrics : INotifyPropertyChanged
{

    public event PropertyChangedEventHandler PropertyChanged;

    public int CacheCount { get; set; }
    public int RequestCount { get; set; }
    public List<long> ResponseFrequencies { get; set; }
    public int LastResponseFrequency { get; set; }
    public DateTime SetDate { get; set; }

    private bool _isUnusedCache;

    public CacheObjectMetrics()
    {
        CacheCount = 1;
        RequestCount = 0;
        ResponseFrequencies = new List<long>();
        LastResponseFrequency = 0;
        SetDate = DateTime.Now;
    }

    public bool IsUnusedCache
    {
        get => _isUnusedCache;

        set 
        {
            if(_isUnusedCache != value)
            {
                _isUnusedCache = value;
                OnPropertyChanged(nameof(IsUnusedCache));

                if(_isUnusedCache)
                {
                    OnIsUnusedCacheChanged();
                }
            }
        }
    }
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void OnIsUnusedCacheChanged()
    {
        Console.WriteLine("IsUnusedCache changed to true");
    }
}
