using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiftOff2014.BL;
using LiftOff2014.Common; 

namespace LiftOff2014
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            List<County> counties = this.liftOffBL.GetCounties(); 

        }


        private LiftOffBL _liftOffBL;
        private LiftOffBL liftOffBL
        {
            get
            {
                if (this._liftOffBL == null) this._liftOffBL = new LiftOffBL();

                return this._liftOffBL;
            }
        }
    }
}