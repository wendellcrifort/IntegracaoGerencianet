namespace Domain.Entities
{
    public class CobrancaResponse : CobrancaRequest
    {
        public CobrancaResponse()
        {
            loc = new Location();
        }

        public string txid { get; set; }
        public int revisao { get; set; }
        public Location loc { get; set; }
        public string location { get; set; }
        public string status { get; set; }
    }

    public class Location
    {
        public int id { get; set; }
        public string location { get; set; }
        public string tipoCob { get; set; }        
    }
    
}