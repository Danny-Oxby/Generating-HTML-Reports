namespace DatabaseAccess.Models
{
    //the price information related to a jobs materials, location and date
    public class JobPriceMdl
    {
        public List<MaterialPriceMdl> ListOfMaterials { get; set; } = default!;
        public double CostOfLabour { get; set; } //Wage * total time
        public double CostOfTransport { get; set; } //Fuel
        public string JobLocation { get; set; } = default!; //where the work was for
        public DateTime WorkDateStart { get; set; } //when it started
        public DateTime WorkDateEnd { get; set; } //when it ended
        public string TotalCost { 
            get{ 
                double _runningTotal = CostOfLabour + CostOfTransport;
                foreach (var item in ListOfMaterials)
                    _runningTotal += item.MaterialCost;

                return string.Format("{0:0.00}",double.Round(_runningTotal, 2));
            }
        } //what was the total cost of the job
    }
}
