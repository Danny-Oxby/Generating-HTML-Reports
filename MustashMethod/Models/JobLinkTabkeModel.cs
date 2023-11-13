namespace MustashMethod.Models
{
    // how the job links to all other user factors
    public class JobLinkTabkeModel
    {
        public int JobNumber { get; set; } //the unique ID
        public int CustomerID { get; set; } //the customer linke
        public int WorkerId { get; set; } // the worker link
        public JobPriceModel JobID { get; set; } = default!; //what job are they linked ot 
    }
}
