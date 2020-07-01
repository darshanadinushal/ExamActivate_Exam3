using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace SampleEx2
{
    class Program
    {
        static List<string> lexicographicalArray = new List<string>();

        static void Main(string[] args)
        {

            // Call the function
           // computePoints(String UserId, DateTime StepDate, int Steps)


        }





        public void computePoints(String UserId, DateTime StepDate, int Steps)
        {
            var usePointList = MemoryCache.Default["step_point"] as List<UserStep_point>;
            if (usePointList == null)
            {
                //usePointList.Add(new UserStep_point { Id = 10, EffectiveDate = new DateTime(2019, 01, 01), UserId = "1", MileStone = 5000, Points = 10, TargetSteps = 5000 });
                //usePointList.Add(new UserStep_point { Id = 10, EffectiveDate = new DateTime(2019, 07, 01), UserId = "1", MileStone = 5000, Points = 10, TargetSteps = 5000 });
                // usePointList.Add(new UserStep_point { Id = 10, EffectiveDate = new DateTime(2019, 03, 01), UserId = "1", MileStone = 5000, Points = 10, TargetSteps = 5000 });


                //var model = Getstep_pointFromDatabase();
                // MemoryCache.Default["step_point"] = model;
            }

            var pointCount = 0;


            var userOldRecourdList = usePointList.Where(x => x.UserId == UserId).OrderByDescending(x => x.EffectiveDate).ToArray();

            if (userOldRecourdList.Length > 0)
            {
                var latestStepRecord = userOldRecourdList.FirstOrDefault();

                if (latestStepRecord.EffectiveDate == StepDate)
                {
                    // get the 
                    var latestStepCount = latestStepRecord.TargetSteps + Steps;
                    //var stepPointCount = CalPoint(newStepCount);

                    var newStepCount = InitialCalPoint(latestStepCount);
                    //Update the record  with new record

                }
                else
                {
                    var resultValue = CalPoint(latestStepRecord.TargetSteps, Steps);
                    if (resultValue > 0)
                    {
                        var newStepPoint = resultValue;
                        // Inset to the step_point table 
                    }
                    else
                    {
                        var newStepCount = InitialCalPoint(Steps);

                        //Inset to the step_point table 

                    }
                }
            }
            else
            {
                var value = InitialCalPoint(Steps);

                // Inset to step table 
            }
        }


        public int CalPoint(int lastStepCount, int todayCount)
        {
            if ((todayCount >= 5000 && todayCount < 10000) && (lastStepCount >= 5000 && lastStepCount < 10000))
            {
                return 5;
            }
            else if ((todayCount >= 10000 && todayCount < 30000) && (lastStepCount >= 10000 && lastStepCount < 30000))
            {
                return 5;
            }
            else if ((todayCount > 30000) && (lastStepCount > 30000))
            {
                return 5;
            }
            else
            {
                return -1;
            }

        }



        public int InitialCalPoint(int stepCount)
        {
            if (stepCount >= 5000 && stepCount < 10000)
            {
                return 10;
            }
            else if (stepCount >= 10000 && stepCount < 30000)
            {
                return 20;
            }
            else if (stepCount > 30000)
            {
                return 30;
            }
            else
            {
                return 0;
            }

        }


    }






}






public class UserStep_point
{
    public int Id { get; set; }
    public String UserId { get; set; }
    public int MileStone { get; set; }
    public int TargetSteps { get; set; }
    public int Points { get; set; }
    public DateTime EffectiveDate { get; set; }
}
}
