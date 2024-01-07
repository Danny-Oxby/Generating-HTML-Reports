//for single eaxmaple this is fine but is using mutlpe at once would be a thread safe static
using DatabaseAccess.Models;

namespace DatabaseAccess
{
    public static class MockDatabase
    {
        private static readonly List<JobModelMdlLink> MockDataAsList = new List<JobModelMdlLink>
            {
                new JobModelMdlLink()
                {
                    JobId = 1,
                    CustomerID = 1,
                    WorkerId = 1,
                    JobValues = new()
                    {
                        JobLocation = "Lincon",
                        CostOfLabour = 55.55,
                        CostOfTransport = 24.21,
                        WorkDateStart = new(2023, 1, 1, 9, 1, 1), //Jan first 9am
                        WorkDateEnd = new(2023, 1, 6, 12, 1, 1), //Jan sixth 12am
                        ListOfMaterials = new List<MaterialPriceMdl>{
                        new MaterialPriceMdl() {MaterialCost = 4.99, MaterialName = "Screws"},
                        new MaterialPriceMdl() {MaterialCost = 15.99, MaterialName = "2 2x4 Wood planks"},
                        new MaterialPriceMdl() {MaterialCost = 3.99, MaterialName = "Hinge set"},
                        new MaterialPriceMdl() {MaterialCost = 12.99, MaterialName = "Paint"},
                        }
                    }
                },
                new JobModelMdlLink()
                {
                    JobId = 2,
                    CustomerID = 2,
                    WorkerId = 1,
                    JobValues = new()
                    {
                        JobLocation = "Worksop",
                        CostOfLabour = 25.09,
                        CostOfTransport = 13.82,
                        WorkDateStart = new(2023, 3, 1, 9, 1, 1),
                        WorkDateEnd = new(2023, 3, 6, 18, 1, 1),
                        ListOfMaterials = new List<MaterialPriceMdl>{
                        new MaterialPriceMdl() {MaterialCost = 34.99, MaterialName = "Door"},
                        new MaterialPriceMdl() {MaterialCost = 3.99, MaterialName = "Hinge set"},
                        new MaterialPriceMdl() {MaterialCost = 17.99, MaterialName = "Lock"},
                        }
                    }
                },
                new JobModelMdlLink()
                {
                    JobId = 3,
                    CustomerID = 1,
                    WorkerId = 2,
                    JobValues = new()
                    {
                        JobLocation = "Doncaster",
                        CostOfLabour = 127.33,
                        CostOfTransport = 56.78,
                        WorkDateStart = new(2023, 11, 20, 9, 1, 1),
                        WorkDateEnd = new(2023, 12, 2, 17, 30, 1),
                        ListOfMaterials = new List<MaterialPriceMdl>{
                        new MaterialPriceMdl() {MaterialCost = 4.99, MaterialName = "Screws"},
                        new MaterialPriceMdl() {MaterialCost = 15.99, MaterialName = "2 2x4 Wood planks"},
                        new MaterialPriceMdl() {MaterialCost = 3.99, MaterialName = "Hinge set"},
                        new MaterialPriceMdl() {MaterialCost = 12.99, MaterialName = "Paint"},
                        }
                    }
                }
            };

        public static List<JobModelMdlLink> ReturnAllModelData()
        {
            return MockDataAsList;
        }

        //Return the found job by Id or Null
        public static JobModelMdlLink? ReturnJobData(int JobId)
        {
            return MockDataAsList.Where(o => o.JobId == JobId).FirstOrDefault();
        }
    }
}