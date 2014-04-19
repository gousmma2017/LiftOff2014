
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiftOff2014.Common;
using LiftOff2014.DAC;

namespace LiftOff2014.BL
{
    public class LiftOffBL
    {



        public List<County> GetCounties()
        {
            return this.liftOffDAC.GetCounties(); 
        }


        public County GetCounty(int countyID)
        {
            return this.liftOffDAC.GetCounty(countyID); 
        }

        public void UpdateCandidateVotes(int countyID, int candidateID, int votes)
        {
            this.liftOffDAC.UpdateCandidateVotes(countyID, candidateID, votes); 
        }

        public void UpdateCandidatesVotes(int countyID, List<Candidate> candidates)
        {
            foreach (Candidate candidate in candidates)
            {
                this.liftOffDAC.UpdateCandidateVotes(countyID, candidate.CandidateID, candidate.Votes);
            }
        }

        public List<Candidate> GetAllCandidateVotes()
        {
            return this.liftOffDAC.GetAllCandidateVotes(); 
        }

        public List<Candidate> GetCandidateVotesForCounty(int countyID)
        {
            return this.liftOffDAC.GetCandidateVotesForCounty(countyID); 
        }


        private LiftOffDAC _liftOffDAC;
        private LiftOffDAC liftOffDAC
        {
            get
            {
                if (this._liftOffDAC == null) this._liftOffDAC = new LiftOffDAC();

                return this._liftOffDAC;
            }
        }

    }
}