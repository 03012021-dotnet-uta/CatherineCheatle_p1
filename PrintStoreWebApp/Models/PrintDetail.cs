namespace Models
{
    public class PrintDetail
    {
        public int PrintID { get; set; }
        public string PrintTitle { get; set; }
        public string ArtistFName { get; set; }
        public string ArtistLName { get; set; }
        public double PrintPrice { get; set; }
        public string PrintImage { get; set; }
        public string PrintDecription { get; set; }
        public int StoreId { get; set; }
        public int PrintQty { get; set; }

    }
}