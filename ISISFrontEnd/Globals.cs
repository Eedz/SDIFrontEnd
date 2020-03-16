using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITCLib;

namespace ISISFrontEnd
{
    public static class Globals
    {
        public static List<Study> AllStudies;
        public static List<StudyWave> AllWaves;
        public static List<Survey> AllSurveys;
        public static List<Person> AllPeople;

        public static UserPrefs CurrentUser;

        public static void CreateWorld()
        {
            CurrentUser = DBAction.GetUser(Environment.UserName);

            AllStudies = DBAction.GetStudyInfo();
            AllWaves = DBAction.GetWaveInfo();
            AllSurveys = DBAction.GetAllSurveys();
            AllPeople = DBAction.GetPeople();

        }
    }
}
