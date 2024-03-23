namespace Brimborium.TheMeaningOfLiff;

public record class Meaning(
    Microsoft.Extensions.Logging.EventId EventId,
    string Message) {
    public Meaning(string message, int eventId = 0, string? eventIdName = null)
        : this(EventId: new Microsoft.Extensions.Logging.EventId(id: eventId, name: eventIdName), Message: message) {
    }
}
