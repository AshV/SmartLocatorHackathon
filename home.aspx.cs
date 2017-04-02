using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class home : System.Web.UI.Page
{
    EntryFormBAL objEntryFormBAL = new EntryFormBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        
       
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        double longi = Convert.ToDouble(txtlongitude.Text);
        double lati = Convert.ToDouble(txtlat.Text);
        objEntryFormBAL.EnterLocation(longi, lati, txttimespent.Text, ddlcurrenttime.SelectedValue);
        Session["longi"] = txtlongitude.Text;
        Session["lati"] = txtlat.Text;
    }
}