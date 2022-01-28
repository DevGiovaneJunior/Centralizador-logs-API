namespace LogElasticAPI.Model
{
    public class LogModel
    {
        public string Id { get; set; }
        public string ApplicationName { get; set; }
        public string Message { get; set; }
        public string InnerMessage { get; set; }
        public string Stacktrace { get; set; }
    }
}
