using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for suggestbytime
/// </summary>
public class suggestbytimeBAL
{
    BAL objBAL = new BAL();
	public suggestbytimeBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public System.Data.DataSet GetData()
    {
        try
        {
            DataSet ds = objBAL.GetTypesByTime(DateTime.Now);
            string[] arr = new string[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                arr[i] = ds.Tables[0].Rows[i][0].ToString();
            }
            return ds;
        }
        catch
        { throw; }
    }
}