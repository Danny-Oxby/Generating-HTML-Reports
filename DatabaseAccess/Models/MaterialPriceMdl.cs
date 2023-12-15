namespace DatabaseAccess.Models
{
    //the infomration ralted to the meterails used in a job
    public class MaterialPriceMdl
    {
        public string MaterialName { get; set; } = default!; //what material was needed
        public double MaterialCost { get; set; } = 0.00; //what is is cost
    }
}
