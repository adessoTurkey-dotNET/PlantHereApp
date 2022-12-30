using System.Text.Json.Serialization;

namespace PlantHere.Application.CQRS.Results
{
    public class NoContentResult
    {
        public List<String> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public static NoContentResult Success(int statusCode)
        {
            return new NoContentResult { StatusCode = statusCode };
        }
    }
}
