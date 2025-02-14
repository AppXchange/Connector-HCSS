using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Connector.Client.Equipment360
{
    public class Equipment360PaginatedResponse<T>
    {
        [JsonPropertyName("count")]
        public int Count { get; init; }

        [JsonPropertyName("prev")]
        public int? Prev { get; init; }

        [JsonPropertyName("next")]
        public int? Next { get; init; }

        [JsonPropertyName("timestamp")]
        public int Timestamp { get; init; }

        [JsonPropertyName("data")]
        public IEnumerable<T>? Data { get; init; }
    }
} 