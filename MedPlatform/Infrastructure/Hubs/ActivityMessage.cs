namespace Infrastructure.Hubs
{
    public class ActivityMessage
    {
        public string Message { get; set; }
        public int CaregiverId { get; set; }
        public string PatientName { get; set; }
    }
}
