namespace turplanlegger.Models
{
    public abstract class BaseResponse
    {
        public int Id { get; set; }
        public string Endret { get; set; }
        public string Navn { get; set; }
    }
}