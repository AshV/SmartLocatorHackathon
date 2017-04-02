using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Suggesion : System.Web.UI.Page
{
    SuggesionByRankBAL objSuggesionByRankBAL = new SuggesionByRankBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        //DataSet ds = objSuggesionByRankBAL.GetData();
        //gv.DataSource = ds;
        //gvsuggestbytime.DataBind();
    }
}