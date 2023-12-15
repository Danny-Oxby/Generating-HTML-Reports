namespace DatabaseAccess.Models
{
    // how the job links to all other user factors
    public class JobModelMdlLink
    {
        public int JobId { get; set; } //the unique ID
        public int CustomerID { get; set; } //the customer linke
        public int WorkerId { get; set; } // the worker link
        public JobPriceMdl JobValues { get; set; } = default!; //what job are they linked ot 
    }
}
