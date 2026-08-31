namespace DiveDeepWebApp.Models
{
    public class Attribute
    {
        public string Name { get; set; } = string.Empty;
        public string Unit {  get; set; } = string.Empty;
        public List<Value> Values { get; set; }
    }
}
