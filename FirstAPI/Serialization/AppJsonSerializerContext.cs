using Amazon.Lambda.APIGatewayEvents;
using System.Text.Json.Serialization;

namespace FirstAPI.Serialization
{
    [JsonSerializable(typeof(APIGatewayProxyRequest))]
    [JsonSerializable(typeof(APIGatewayProxyResponse))]
    internal partial class AppJsonSerializerContext : JsonSerializerContext {}
}
