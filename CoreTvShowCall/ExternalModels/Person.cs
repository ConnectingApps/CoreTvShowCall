namespace CoreTvShowCall.ExternalModels
{
    public class Person
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public Country2 country { get; set; }
        public string birthday { get; set; }
        public object deathday { get; set; }
        public string gender { get; set; }
        public Image2 image { get; set; }
        public Links2 _links { get; set; }
    }
}