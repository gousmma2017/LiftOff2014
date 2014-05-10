using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiftOff2014.Common
{
    public class Candidate
    {

        public int CandidateID { get; set;  }

        public string DisplayName { get; set;  }

        private int _Votes = 0; 
        public int Votes { 
            get{ return this._Votes; }
            set{ this._Votes = value; }
        }

        private int _ProjectedVotes = 0; 
        public int ProjectedVotes { 
            get{ return this._ProjectedVotes; }
            set{ this._ProjectedVotes = value; }
        }
       
        private int _TotalVotesAvailable = 0; 
        public int TotalVotesAvailable { 
            get{ return this._TotalVotesAvailable; }
            set{ this._TotalVotesAvailable = value; }
        }

        private int _TotalVotesCast = 0; 
        public int TotalVotesCast { 
            get{ return this._TotalVotesCast; }
            set{ this._TotalVotesCast = value; }
        }

        public decimal PercentOfProjectedVotes { 
            
            get{ 
                decimal percentOfProjectedVotes = 0; 

                if( this.ProjectedVotes > 0){

                    percentOfProjectedVotes = decimal.Divide( this.Votes, this.ProjectedVotes ); 
                }

                return percentOfProjectedVotes; 
            }
        }

        public decimal PercentOfTotalVotesCast
        {

            get
            {
                decimal percentOfTotalVotesCast = 0;

                if (this.ProjectedVotes > 0)
                {

                    percentOfTotalVotesCast = decimal.Divide(this.Votes, this.TotalVotesCast);
                }

                return percentOfTotalVotesCast;
            }
        }

        public decimal PercentOfTotalVotesAvailable
        {

            get
            {
                decimal percentOfTotalVotesAvailable = 0;

                if (this.ProjectedVotes > 0)
                {

                    percentOfTotalVotesAvailable = decimal.Divide(this.Votes, this.TotalVotesAvailable);
                }

                return percentOfTotalVotesAvailable;
            }
        }

    }
}