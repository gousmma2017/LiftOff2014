using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text; 
using LiftOff2014.Common; 

namespace LiftOff2014.DAC
{
    public class LiftOffDAC
    {

        public List<County> GetCounties()
        {
            List<County> counties = new List<County>();

            string sql = "select CountyID, CountyName from Counties";

            try
            {
                SqlCommand command = new SqlCommand(sql, this.Connection);

                SqlDataReader dr = command.ExecuteReader();

                using (dr)
                {

                    while (dr.Read())
                    {
                        County county = new County();

                        county.CountyID = int.Parse(dr["CountyID"].ToString());
                        county.CountyName = dr["CountyName"].ToString();

                        counties.Add(county);
                    }
                }

            }
            catch (SqlException sqlEx)
            {
                throw sqlEx; 
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            return counties; 

        }


        public County GetCounty(int countyID)
        {
            County county = new County(); 

            string sql = "select CountyName, TotalVotes, ProjectedEdVotes from Counties where CountyID = " + countyID.ToString();

            try
            {
                SqlCommand command = new SqlCommand(sql, this.Connection);

                SqlDataReader dr = command.ExecuteReader();

                using (dr)
                {

                    while (dr.Read())
                    {
                        county.CountyID = countyID;
                        county.CountyName = dr["CountyName"].ToString();
                        county.TotalVotes = int.Parse(dr["TotalVotes"].ToString());
                        county.ProjectedVotes = int.Parse(dr["ProjectedEdVotes"].ToString());
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx; 
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            return county;

        }

        public void UpdateCandidateVotes(int countyID, int candidateID, int votes)
        {
            try { 
                SqlCommand command = new SqlCommand(this.UpdateCandidateVotesSQL(countyID, candidateID, votes), this.Connection);

                command.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx; 
            }
            catch (Exception ex)
            {
                throw ex; 
            }

        }

        private string UpdateCandidateVotesSQL(int countyID, int candidateID, int votes)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("update CandidateVotes set Votes = {0} where CandidateID = {1} and CountyID = {2}");
            sql.AppendFormat(votes.ToString(), candidateID.ToString(), countyID.ToString());

            return sql.ToString(); 
        }


        public List<Candidate> GetAllCandidateVotes()
        {
            List<Candidate> candidates = new List<Candidate>();

            string sql = "select cand.CandidateID, cand.DisplayName, isnull(sum(votes.Votes),0) 'Votes' from Candidates cand left join CandidateVotes votes on cand.CandidateID = votes.CandidateID group by cand.CandidateID, cand.DisplayName";

            try
            {
                SqlCommand command = new SqlCommand(sql, this.Connection);

                SqlDataReader dr = command.ExecuteReader();

                using (dr)
                {

                    while (dr.Read())
                    {
                        Candidate candidate = new Candidate();

                        candidate.CandidateID = int.Parse(dr["CandidateID"].ToString());
                        candidate.DisplayName = dr["DisplayName"].ToString();
                        candidate.Votes = int.Parse(dr["Votes"].ToString());

                        candidates.Add(candidate);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return candidates;
        }

        public List<Candidate> GetCandidateVotesForCounty(int countyID)
        {
            List<Candidate> candidates = new List<Candidate>();

            StringBuilder sql = new StringBuilder();

            sql.AppendFormat("select cand.CandidateID, cand.DisplayName, isnull(sum(votes.Votes),0) 'Votes' from Candidates cand left join CandidateVotes votes on cand.CandidateID = votes.CandidateID where votes.CountyID = {0} group by cand.CandidateID, cand.DisplayName", countyID.ToString());

            try { 
            SqlCommand command = new SqlCommand(sql.ToString(), this.Connection);

            SqlDataReader dr = command.ExecuteReader();

                using (dr)
                {

                    while (dr.Read())
                    {
                        Candidate candidate = new Candidate();

                        candidate.CandidateID = int.Parse(dr["CandidateID"].ToString());
                        candidate.DisplayName = dr["DisplayName"].ToString();
                        candidate.Votes = int.Parse(dr["Votes"].ToString());

                        candidates.Add(candidate);
                    }
                }

            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return candidates;
        }



        private SqlConnection _Connection;
        private SqlConnection Connection
        {
            get
            {
                if (this._Connection == null)
                {
                    this._Connection = new SqlConnection(this.ConnectionString);
                    this._Connection.Open(); 

                }

                return this._Connection;
            }
        }

        private string ConnectionString
        {
            get
            {
                return "Server=tcp:ev1hqitrfh.database.windows.net,1433;Database=Mariners;User ID=gousmma2017@ev1hqitrfh;Password=$$$Mariners;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            }              

        }

    }
}