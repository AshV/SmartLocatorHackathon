using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EntryForm : System.Web.UI.Page
{
    EntryFormBAL objEntryFormBAL = new EntryFormBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        BAL b = new BAL();
        Response.Write(b.getsm("17.370955", "78.445473")[0]);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        double longi = Convert.ToDouble(tbLong.Text);
        double lati = Convert.ToDouble(tbLatitude.Text);
        objEntryFormBAL.EnterLocation(longi, lati, tbAmntTime.Text, DropDownList1.SelectedValue);
    }
}