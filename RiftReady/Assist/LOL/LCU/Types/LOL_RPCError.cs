using System.Text.Json.Serialization;

namespace LOLUtil.Assist.LOL.LCU.Types
{
    public record LOL_ImplementationDetails
    {
    }

    public record LOL_RPCError
    {
        [JsonPropertyName("errorCode")]
        public required string ErrorCode;

        [JsonPropertyName("httpStatus")]
        public required int HttpStatus;

        [JsonPropertyName("implementationDetails")]
        public required LOL_ImplementationDetails ImplementationDetails;

        [JsonPropertyName("message")]
        public required string Message;
    }

}
