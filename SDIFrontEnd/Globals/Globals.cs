﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Timers;
using ITCLib;

namespace SDIFrontEnd
{
    public static class Globals
    {
        public static string BackupPath = @"\\psychfile\psych$\psych-lab-gfong\SMG\Backend\DailyBackups\VarInfoback\";
        public static string AutoSurveysPath = @"\\psychfile\psych$\psych-lab-gfong\SMG\Access\Reports\Automatic Surveys\";

        // users
        public static UserPrefs CurrentUser;

        // surveys
        public static List<Region> AllRegions;
        public static List<Study> AllStudies;
        public static List<StudyWave> AllWaves;
        public static List<Survey> AllSurveys;
        public static List<LockedSurvey> AllLockedSurveys;

        // varnames
        public static List<VariablePrefix> AllPrefixes;
        public static List<VariableName> AllVarNames;
        public static List<RefVariableName> AllRefVarNames;
        public static List<CanonicalRefVarName> AllCanonVars;
        public static List<string> AllTempPrefixes;

        // wordings
        public static List<Wording> AllPreP;
        public static List<Wording> AllPreI;
        public static List<Wording> AllPreA;
        public static List<Wording> AllLitQ;
        public static List<Wording> AllPstI;
        public static List<Wording> AllPstP;
        public static List<ResponseSet> AllRespOptions;
        public static List<ResponseSet> AllNRCodes;

        // labels and lists
        public static List<Person> AllPeople;
        public static List<Role> AllRoles;
        public static List<ContentLabel> AllContentLabels;
        public static List<TopicLabel> AllTopicLabels;
        public static List<DomainLabel> AllDomainLabels;
        public static List<ProductLabel> AllProductLabels;
        public static List<SurveyCohort> AllCohorts;
        public static List<UserState> AllUserStates;
        public static List<SimilarWords> AllSimilarWords;
        public static List<SurveyMode> AllModes;
        public static List<Language> AllLanguages;

        // comments
        public static List<CommentType> AllCommentTypes;
        public static List<Note> AllNotes;
        public static Timer timer;

        public static void CreateWorld()
        {
            CreateUser();

            CreateSurveys();

            CreateVarNames();

            CreateWordings();

            CreateOtherLists();

            CreateComments();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            AllLockedSurveys = DBAction.GetUserLockedSurveys();
            var locked = AllLockedSurveys.Where(x => x.UnlockedForMin <= 0);
            foreach (LockedSurvey survey in locked)
            {
                DBAction.LockSurvey(survey);
                Globals.AllSurveys.First(x => x.SID.Equals(survey.SID)).Locked = true;
            }
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

            timer = new Timer();

            timer.Interval = (60 * 5000); // 5 min
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Start();
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
            AllRespOptions = DBAction.GetResponseSets("RespOptions");
            AllNRCodes = DBAction.GetResponseSets("NRCodes");
        }

        public static void CreateOtherLists()
        {
            AllPeople = DBAction.GetPeople();
            AllRoles = DBAction.GetRoles();
            
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
            FormStateRecord state = new FormStateRecord();
            FormState currentState = CurrentUser.GetFormState(newState.FormName, newState.FormNum);
            if (currentState == null)
            {
                currentState = new FormState();
                currentState.PersonnelID = CurrentUser.userid;
                currentState.FormNum = newState.FormNum;
                currentState.FormName = newState.FormName;
                state.NewRecord = true;
            }
            else
            {
                state.Dirty = true;
            }
            
            currentState.FilterID = newState.FilterID;
            currentState.RecordPosition = newState.RecordPosition;
            currentState.Filter = newState.Filter;
            
            state.Item = currentState;

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

        public static void AddWording(Wording wording)
        {
            switch (wording.Type)
            {
                case WordingType.PreP:
                    AllPreP.Add(wording);
                    break;
                case WordingType.PreI:
                    AllPreI.Add(wording);
                    break;
                case WordingType.PreA:
                    AllPreA.Add(wording);
                    break;
                case WordingType.LitQ:
                    AllLitQ.Add(wording);
                    break;
                case WordingType.PstI:
                    AllPstI.Add(wording);
                    break;
                case WordingType.PstP:
                    AllPstP.Add(wording);
                    break;
            }
        }

        public static void AddResponseSet(ResponseSet wording)
        {
            switch (wording.Type)
            {
                case ResponseType.RespOptions:
                    AllRespOptions.Add(wording);
                    break;
                case ResponseType.NRCodes:
                    AllNRCodes.Add(wording);
                    break;
            }
        }

        public static void UpdateWordings(List<Wording> wordings)
        {
            foreach (Wording wording in wordings)
            {
                switch (wording.Type)
                {
                    case WordingType.PreP:
                        UpsertWordingList(AllPreP, wording);
                        break;
                    case WordingType.PreI:
                        UpsertWordingList(AllPreI, wording);
                        break;
                    case WordingType.PreA:
                        UpsertWordingList(AllPreA, wording);
                        break;
                    case WordingType.LitQ:
                        UpsertWordingList(AllLitQ, wording);
                        break;
                    case WordingType.PstI:
                        UpsertWordingList(AllPstI, wording);
                        break;
                    case WordingType.PstP:
                        UpsertWordingList(AllPstP, wording);
                        break;
                }
            }
            RefreshWordings?.Invoke(null, new EventArgs());
        }

        private static void UpsertWordingList(List<Wording> list,  Wording wording)
        {
            Wording w = list.FirstOrDefault(x => x.Equals(wording));
            if (w != null)
                w.WordingText = wording.WordingText;
            else
                list.Add(wording);
        }

        public static List<Wording> GetWordingList(string field)
        {
            switch (field)
            {
                case "PreP":
                    return Globals.AllPreP;
                case "PreI":
                    return Globals.AllPreI;
                case "PreA":
                    return Globals.AllPreA;
                case "LitQ":
                    return Globals.AllLitQ;
                case "PstI":
                    return Globals.AllPstI;
                case "PstP":
                    return Globals.AllPstP;
            }
            return null;
        }

        public static List<ResponseSet> GetResponseList(string field)
        {
            switch (field)
            {
                case "RespOptions":
                    return Globals.AllRespOptions;
                case "NRCodes":
                    return Globals.AllNRCodes;
            }
            return null;
        }


        public static EventHandler RefreshPeople;
        public static EventHandler RefreshDomains;
        public static EventHandler RefreshTopics;
        public static EventHandler RefreshContents;
        public static EventHandler RefreshProducts;
        public static EventHandler RefreshWordings;
    }
}
