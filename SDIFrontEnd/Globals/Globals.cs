using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using ITCLib;

namespace SDIFrontEnd
{
    public static class Globals
    {
        public static string BackupPath = @"\\psychfile\psych$\psych-lab-gfong\SMG\Backend\DailyBackups\VarInfoback\";
        public static string AutoSurveysPath = @"\\psychfile\psych$\psych-lab-gfong\SMG\Access\Reports\Automatic Surveys\";

        // users
        public static UserRecord CurrentUser;

        // surveys
        public static List<Region> AllRegions;
        public static List<Study> AllStudies;
        public static List<StudyWave> AllWaves;
        public static List<Survey> AllSurveys;

        // varnames
        public static List<VariablePrefix> AllPrefixes;
        public static List<VariableName> AllVarNames;
        public static List<RefVariableName> AllRefVarNames;
        public static List<CanonicalVariableRecord> AllCanonVars;
        public static List<string> AllTempPrefixes;

        // wordings
        public static List<Wording> AllPreP;
        public static List<Wording> AllPreI;
        public static List<Wording> AllPreA;
        public static List<Wording> AllLitQ;
        public static List<Wording> AllPstI;
        public static List<Wording> AllPstP;

        // labels and lists
        public static List<PersonRecord> AllPeople;
        public static List<ContentLabel> AllContentLabels;
        public static List<TopicLabel> AllTopicLabels;
        public static List<DomainLabel> AllDomainLabels;
        public static List<ProductLabel> AllProductLabels;
        public static List<SurveyCohortRecord> AllCohorts;
        public static List<UserStateRecord> AllUserStates;
        public static List<SimilarWordsRecord> AllSimilarWords;
        public static List<SurveyMode> AllModes;
        public static List<Language> AllLanguages;

        // comments
        public static List<CommentType> AllCommentTypes;
        public static List<Note> AllNotes;

        public static void CreateWorld()
        {
            CreateUser();

            CreateSurveys();

            CreateVarNames();

            CreateWordings();

            CreateOtherLists();

            CreateComments();

        }

        public static void CreateUser()
        {
            CurrentUser = DBAction.GetUser(Environment.UserName);
        }

        public static void CreateSurveys()
        {
            AllRegions = DBAction.GetRegionInfo();
            AllStudies = DBAction.GetStudyInfo();
            AllWaves = DBAction.GetWaveInfo();
            AllSurveys = DBAction.GetAllSurveysInfo();

            foreach (Region region in AllRegions)
            {
                region.Studies = new List<Study>(AllStudies.Where(x => x.RegionID == region.ID).ToList());
            }

            foreach (Study study in AllStudies)
            {
                study.Waves = new List<StudyWave>(AllWaves.Where(x => x.StudyID == study.ID).ToList());
            }

            foreach (StudyWave wave in AllWaves)
            {
                wave.Surveys = new List<Survey>(AllSurveys.Where(x => x.WaveID == wave.ID).ToList());
            }
        }

        public static void CreateVarNames()
        {
            AllPrefixes = DBAction.GetVariablePrefixes();
            AllVarNames = DBAction.GetAllVarNames();
            AllRefVarNames = DBAction.GetAllRefVarNames();
            AllCanonVars = DBAction.GetAllCanonVars();
            AllTempPrefixes = new List<string>() { "NW", "NU", "NV", "NX", "NY", "NZ", "NO", "NS", "NM" };
        }

        public static void CreateWordings()
        {
            AllPreP = DBAction.GetWordings("PreP");
            AllPreI = DBAction.GetWordings("PreI");
            AllPreA = DBAction.GetWordings("PreA");
            AllLitQ = DBAction.GetWordings("LitQ");
            AllPstI = DBAction.GetWordings("PstI");
            AllPstP = DBAction.GetWordings("PstP");
        }

        public static void CreateOtherLists()
        {
            AllPeople = DBAction.GetPeople();
            
            AllContentLabels = DBAction.ListContentLabels();
            AllTopicLabels = DBAction.ListTopicLabels();
            AllDomainLabels = DBAction.ListDomainLabels();
            AllProductLabels = DBAction.ListProductLabels();
            AllCohorts = DBAction.GetCohortInfo();
            AllModes = DBAction.GetModeInfo();
            AllModes.Insert(0, new SurveyMode());

            AllUserStates = DBAction.GetUserStates();
            AllSimilarWords = DBAction.GetSimilarWordings();

            AllLanguages = DBAction.ListLanguages();
        }

        public static void CreateComments()
        {
            AllCommentTypes = DBAction.GetCommentTypes();
            AllNotes = DBAction.GetNotes();
        }

        public static void UpdateUserFormState(FormState newState)
        {

            FormStateRecord state = CurrentUser.FormStates.Where(x => x.FormName.Equals(newState.FormName) && x.FormNum == newState.FormNum).FirstOrDefault();
            state.FilterID = newState.FilterID;
            state.RecordPosition = newState.RecordPosition;
            state.Dirty = true;
            state.SaveRecord();
            
        }

        public static string GetTempVarPrefix (Survey survey)
        {
            var region = AllRegions.FirstOrDefault(r => r.Studies.Any(s => s.Waves.Any(w => w.Surveys.Any(su => su.SID.Equals(survey.SID)))));
            if (region == null)
                return "unknown";
            else
                return region.TempVarPrefix;
        }

        public static int GetQuestionID(string survey, string varname)
        {
            int qid = DBAction.GetQuestionID(survey, varname);
            
            return qid;
        }

        public static EventHandler RefreshPeople;
        public static EventHandler RefreshDomains;
        public static EventHandler RefreshTopics;
        public static EventHandler RefreshContents;
        public static EventHandler RefreshProducts;
    }
}
