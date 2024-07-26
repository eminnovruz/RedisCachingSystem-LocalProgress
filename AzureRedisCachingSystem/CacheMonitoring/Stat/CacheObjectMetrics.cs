using System.ComponentModel;

namespace AzureRedisCachingSystem.CacheMonitoring.Stat;

public class CacheObjectMetrics : INotifyPropertyChanged
{
    private bool _isUnusedCache;

    public int CacheCount { get; set; }
    public int RequestCount { get; set; }
    public List<int> ResponseFrequencies { get; set; }
    public int LastResponseFrequency { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

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
