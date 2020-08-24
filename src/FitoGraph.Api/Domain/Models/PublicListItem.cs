namespace FitoGraph.Api.Domain.Models
{
    public class PublicListItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public string Image { get; set; }
        public bool Selected { get; set; }
        public bool Enabled { get; set; }
    }
}