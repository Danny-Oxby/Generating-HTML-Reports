//for single eaxmaple this is fine but is using mutlpe at once would be a thread safe static
using MustashMethod.Models;

namespace MustashMethod
{
    public static class MockDatabase
    {
        private static readonly List<JobLinkTabkeModel> MockDataAsList = new List<JobLinkTabkeModel>
            {
                new JobLinkTabkeModel()
                {
                    JobId = 1,
                    CustomerID = 1,
                    WorkerId = 1,
                    JobValues = new()
                    {
                        JobLocation = "Lincon",
                        CostOfLabour = 55,
                        CostOfTransport = 24,
                        WorkDateStart = new(2023, 1, 1, 9, 1, 1), //Jan first 9am
                        WorkDateEnd = new(2023, 1, 6, 12, 1, 1), //Jan sixth 12am
                        ListOfMaterials = new List<MaterialPriceModel>{
                        new MaterialPriceModel() {MaterialCost = 4.99, MaterialName = "screws"},
                        new MaterialPriceModel() {MaterialCost = 15.99, MaterialName = "2 2x4 wood planks"},
                        new MaterialPriceModel() {MaterialCost = 3.99, MaterialName = "hinge set"},
                        new MaterialPriceModel() {MaterialCost = 12.99, MaterialName = "paint"},
                        }
                    }
                },
                new JobLinkTabkeModel()
                {
                    JobId = 2,
                    CustomerID = 2,
                    WorkerId = 1,
                    JobValues = new()
                    {
                        JobLocation = "Worksop",
                        CostOfLabour = 25,
                        CostOfTransport = 13,
                        WorkDateStart = new(2023, 3, 1, 9, 1, 1),
                        WorkDateEnd = new(2023, 3, 6, 18, 1, 1),
                        ListOfMaterials = new List<MaterialPriceModel>{
                        new MaterialPriceModel() {MaterialCost = 34.99, MaterialName = "door"},
                        new MaterialPriceModel() {MaterialCost = 3.99, MaterialName = "hinge set"},
                        new MaterialPriceModel() {MaterialCost = 17.99, MaterialName = "lock"},
                        }
                    }
                },
                new JobLinkTabkeModel()
                {
                    JobId = 3,
                    CustomerID = 1,
                    WorkerId = 2,
                    JobValues = new()
                    {
                        JobLocation = "Doncaster",
                        CostOfLabour = 127,
                        CostOfTransport = 56,
                        WorkDateStart = new(2023, 11, 20, 9, 1, 1),
                        WorkDateEnd = new(2023, 12, 2, 17, 30, 1),
                        ListOfMaterials = new List<MaterialPriceModel>{
                        new MaterialPriceModel() {MaterialCost = 4.99, MaterialName = "screws"},
                        new MaterialPriceModel() {MaterialCost = 15.99, MaterialName = "2 2x4 wood planks"},
                        new MaterialPriceModel() {MaterialCost = 3.99, MaterialName = "hinge set"},
                        new MaterialPriceModel() {MaterialCost = 12.99, MaterialName = "paint"},
                        }
                    }
                }
            };

        public static List<JobLinkTabkeModel> ReturnAllModelData()
        {
            return MockDataAsList;
        }

        //Return the found job by Id or Null
        public static JobLinkTabkeModel? ReturnJobData(int JobId)
        {
            return MockDataAsList.Where(o => o.JobId == JobId).FirstOrDefault();
        }
    }
}