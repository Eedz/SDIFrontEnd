using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using ITCLib;

namespace ISISFrontEnd
{
    public static class Globals
    {
        public static string BackupPath = @"\\psychfile\psych$\psych-lab-gfong\SMG\Backend\DailyBackups\VarInfoback\";
        public static string AutoSurveysPath = @"\\psychfile\psych$\psych-lab-gfong\SMG\Access\Reports\Automatic Surveys\";

        // users
        public static UserRecord CurrentUser;

        // surveys
        public static List<RegionRecord> AllRegions;
        public static List<StudyRecord> AllStudies;
        public static List<StudyWaveRecord> AllWaves;
        public static List<SurveyRecord> AllSurveys;

        public static List<Survey> RenumberedSurveys;

        // varnames
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

        // comments
        public static List<CommentType> AllCommentTypes;
        public static List<NoteRecord> AllNotes;
        
        public static void CreateWorld()
        {
            CreateUser();

            AllRegions = DBAction.GetRegionInfo();
            AllStudies = DBAction.GetStudyInfo();
            AllWaves = DBAction.GetWaveInfo();
            AllSurveys = DBAction.GetAllSurveysInfo();

            RenumberedSurveys = DBAction.GetRenumberedSurveys();

            foreach (RegionRecord region in AllRegions)
            {
                region.Studies = new BindingList<StudyRecord>(AllStudies.Where(x => x.RegionID == region.ID).ToList());
            }

            foreach (StudyRecord study in AllStudies)
            {
                study.Waves = new BindingList<StudyWaveRecord>(AllWaves.Where(x => x.StudyID == study.ID).ToList());
            }

            foreach (StudyWaveRecord wave in AllWaves)
            {
                wave.Surveys = new BindingList<SurveyRecord>(AllSurveys.Where(x => x.WaveID == wave.ID).ToList());
            }

            AllPeople = DBAction.GetPeople();
            AllContentLabels = DBAction.ListContentLabels();
            AllTopicLabels = DBAction.ListTopicLabels();
            AllDomainLabels = DBAction.ListDomainLabels();
            AllProductLabels = DBAction.ListProductLabels();
            AllCohorts = DBAction.GetCohortInfo();
            AllUserStates = DBAction.GetUserStates();
            AllSimilarWords = DBAction.GetSimilarWordings();
            AllVarNames = DBAction.GetAllVarNames();
            AllRefVarNames = DBAction.GetAllRefVarNames();
            AllCanonVars = DBAction.GetAllCanonVars();
            AllTempPrefixes = new List<string>() { "NW", "NU", "NV", "NX", "NY", "NZ", "NO", "NS", "NM" };
            AllCommentTypes = DBAction.GetCommentTypes();
            AllNotes = DBAction.GetNotes();
            AllPreP = DBAction.GetWordings("PreP");
            AllPreI = DBAction.GetWordings("PreI");
            AllPreA = DBAction.GetWordings("PreA");
            AllLitQ = DBAction.GetWordings("LitQ");
            AllPstI = DBAction.GetWordings("PstI");
            AllPstP = DBAction.GetWordings("PstP");
        }

        public static void CreateUser()
        {
            CurrentUser = DBAction.GetUser(Environment.UserName);
            CurrentUser.LastUsedComment = DBAction.GetLastUsedComments(CurrentUser.userid);
            CurrentUser.SavedComments = DBAction.GetSavedComments(CurrentUser.userid);
            CurrentUser.SavedSources = DBAction.GetSavedSources(CurrentUser.userid);
        }

        public static EventHandler RefreshPeople;
    }
}
