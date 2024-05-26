using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OrderLive.Infrastructure.Services
{
    public class OpenAIService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OpenAIService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<OpenAIResponse> Questions(string question)
        {
            var client = _httpClientFactory.CreateClient("OpenAI");            
            var request = new HttpRequestMessage(HttpMethod.Post, "v1/chat/completions");
            request.Content = new StringContent(JsonSerializer.Serialize(new OpenAIRequest
            {
                Model = "gpt-3.5-turbo",
                Messages = new List<MessageRequest>
                {
                    new MessageRequest
                    {
                        Role = "system",
                        Content = "Ты виртуальная гадалка на картах Таро, раскажи"
                    },
                    new MessageRequest
                    {
                        Role = "user",
                        Content = question
                    }
                },
                Temperature = 0,
                MaxTokens = 150,
                TopP = 1,
                FrequencyPenalty = 0,
                PresencePenalty = 0
            }), Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request);
            var responseString = await  response.Content.ReadAsStringAsync();
            var responseBody = JsonSerializer.Deserialize<OpenAIResponse>(responseString);
            return responseBody;
        }
    }

    public class MessageRequest
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    public class OpenAIRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("messages")]
        public List<MessageRequest> Messages { get; set; }
        [JsonPropertyName("temperature")]

        public int Temperature { get; set; }
        [JsonPropertyName("max_tokens")]

        public int MaxTokens { get; set; }
        [JsonPropertyName("top_p")]

        public int TopP { get; set; }
        [JsonPropertyName("frequency_penalty")]
        public int FrequencyPenalty { get; set; }
        [JsonPropertyName("presence_penalty")]
        public int PresencePenalty { get; set; }
    }


    public partial class OpenAIResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("object")]
        public string Object { get; set; }

        [JsonPropertyName("created")]
        public long Created { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("choices")]
        public Choice[] Choices { get; set; }

        [JsonPropertyName("usage")]
        public Usage Usage { get; set; }

        [JsonPropertyName("system_fingerprint")]
        public object SystemFingerprint { get; set; }
    }

    public partial class Choice
    {
        [JsonPropertyName("index")]
        public long Index { get; set; }

        [JsonPropertyName("message")]
        public MessageResponse Message { get; set; }

        [JsonPropertyName("logprobs")]
        public object Logprobs { get; set; }

        [JsonPropertyName("finish_reason")]
        public string FinishReason { get; set; }
    }

    public partial class MessageResponse
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    public partial class Usage
    {
        [JsonPropertyName("prompt_tokens")]
        public long PromptTokens { get; set; }

        [JsonPropertyName("completion_tokens")]
        public long CompletionTokens { get; set; }

        [JsonPropertyName("total_tokens")]
        public long TotalTokens { get; set; }
    }
}
