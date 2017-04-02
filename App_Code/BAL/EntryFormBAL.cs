using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EntryFormBAL
/// </summary>
public class EntryFormBAL
{
    BAL objBal = new BAL();
	public EntryFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
        public double lat{get;set;}

        public double lan { get; set; }
        
        public string place{get;set;}
        
        public string type{get;set;}
        
        public string description{get; set;}
        
        public int noOfVisits{get; set;}
        
        public int avgStayTime{get; set;}
        
        public string avgVisitingTime{get; set;}
        
    //public double GetDifferenceOfLatLong(double lon1, double lat1, double lon2, double lat2)
    //{
    //    const double PIx = 3.141592653589793;
    //    const double RADIUS = 6378.16;
    //    double dlon = (lon2 - lon1) * PIx / 180;
    //    double dlat = (lat2 - lat1) * PIx / 180;

    //    double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos((lat1) * PIx / 180) * Math.Cos((lat2) * PIx / 180) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
    //    double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
    //    return angle * RADIUS;
    //}



    public void EnterLocation(double longi, double lati, string tbAmntTime, string time)
    {
    

        EntryFormBAL objEntryFormBAL = new EntryFormBAL();
        objEntryFormBAL.lat = Convert.ToDouble(objBal.getsm(lati.ToString(), longi.ToString())[1]);
        objEntryFormBAL.lan = Convert.ToDouble(objBal.getsm(lati.ToString(), longi.ToString())[2]);
        objEntryFormBAL.place = objBal.getsm(lati.ToString(), longi.ToString())[3];
        objEntryFormBAL.type = objBal.getsm(lati.ToString(), longi.ToString())[4];
        objEntryFormBAL.description = objBal.getsm(lati.ToString(), longi.ToString())[5];
        objEntryFormBAL.avgStayTime = Convert.ToInt32(tbAmntTime);
        objEntryFormBAL.avgVisitingTime = time;
        //actually it should be increamental from DB
        objEntryFormBAL.noOfVisits = 20;
        objBal.SaveCurrentLocation(objEntryFormBAL);
       
    }
}