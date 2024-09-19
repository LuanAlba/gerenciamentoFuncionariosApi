using System.Text.Json.Serialization;

namespace gerenciamentoFuncionariosApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnoEnum
    {
        Manhã = 1,
        Tarde,
        Noite
    }
}