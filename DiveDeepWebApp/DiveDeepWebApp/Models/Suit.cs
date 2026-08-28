namespace DiveDeepWebApp.Models
{
    public class Suit : Product
    {
        public string Model { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string Type {  get; set; } = string.Empty;
        public string Gender {  get; set; } = string.Empty;
        public double? Thickness { get; set; }
    }
}
