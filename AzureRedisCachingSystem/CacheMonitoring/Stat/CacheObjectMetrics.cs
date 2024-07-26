using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AzureRedisCachingSystem.CacheMonitoring.Stat
{
    public class CacheObjectMetrics : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int RequestCount { get; set; }
        public List<long> ResponseFrequencies { get; set; }
        public int LastResponseFrequency { get; set; }

        private bool _isUnusedCache;

        public CacheObjectMetrics()
        {
            RequestCount = 0;
            ResponseFrequencies = new List<long>();
            LastResponseFrequency = 0;
        }

        public bool IsUnusedCache
        {
            get => _isUnusedCache;
            set
            {
                if (_isUnusedCache != value)
                {
                    _isUnusedCache = value;
                    OnPropertyChanged(nameof(IsUnusedCache));

                    if (_isUnusedCache)
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

        public void WriteToJson(string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                string jsonString = JsonSerializer.Serialize(this, options);
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while writing to JSON file: {ex.Message}");
            }
        }
    }
}
