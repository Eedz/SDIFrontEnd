using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ISISFrontEnd
{
    public class User
    {
        // user info
        int userid;
        public string username;
        int accessLevel;
        // reporting preferences
        string reportPath;
        bool reportPrompt;
        // other preferences
        bool wordingNumbers;

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISISConnectionString"].ConnectionString);

        public bool ReportPrompt { get => reportPrompt; set => reportPrompt = value; }

        public User()
        {
            try
            {
                initializeUser();
            }
            catch (Exception e)
            {
                userid = 0;
                username = "generic";
                accessLevel = 2;
                return;
            }
            
        }

        private void initializeUser()
        {
            DataTable data = new DataTable() ;
            DataRow row;
            // TODO create SP to return all these fields
            String query = "SELECT TOP (1) P.ID, PersonnelID, username, ReportFolder, ReportPrompt, AccessLevel, WordingNumbers FROM qryUserPrefs INNER JOIN qryPersonnel AS P ON qryUserPrefs.PersonnelID = P.ID WHERE username = @user";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@user", SqlDbType.VarChar);
            cmd.Parameters["@user"].Value = Environment.UserName;
            
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            
            
            adapter.Fill(data);
            
            if (data.Rows.Count == 0)
            {
                throw new Exception("Cannot find user.");
            }
            else
            {
                row = data.Rows[0];

                userid =(int) row["PersonnelID"];
                username = (string) row["username"];
                accessLevel = (int) row["AccessLevel"];

                reportPath = (string)row["ReportFolder"];
                reportPrompt = (bool)row["ReportPrompt"];

                wordingNumbers = (bool)row["WordingNumbers"];

            }

            
            
            
        }

        
    }
}
