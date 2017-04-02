using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

/// <summary>
/// Summary description for BAL
/// </summary>
public class BAL
{
    SqlConnection sqlcn;
    SqlCommand sqlcmd;
    SqlDataAdapter sqlda;
    SqlDataReader sqldr;
    DataSet ds;
	public BAL()
	{
      
	}
    public DataSet GetMostVisitedTypes(int num)
    {
        string sqlQuery = "select Type, Sum(noOfVisits) as NumberOfVisit from tbl_visitedPlaces Group By Type Having Sum(noOfVisits) > " +num;
        return ConnectionFactory.GetData(sqlQuery);
    }

    public DataSet GetAllData()
    {
        try
        {
            string sqlQuery = "select Type, Sum(noOfVisits) As NumberOfVisits, Avg(avgStayTime) AS StayedForTime_In_Minut from tbl_visitedPlaces Group By Type;";
            return ConnectionFactory.GetData(sqlQuery);
        }
        catch
        { throw; }
    }

    public DataSet GetTypesByTime(DateTime time)
    {
        try
        {
            string fromTime = time.AddHours(-1).ToString("HH:mm");
            string ToTime = time.AddHours(1).ToString("HH:mm");
            string sqlQuery = "Select Distinct Type, avgVisitingTime as WhenYouVisit from tbl_visitedPlaces where AvgVisitingTime between '" + fromTime + "' and '" + ToTime + "'";
            return ConnectionFactory.GetData(sqlQuery);
        }
        catch
        { throw; }
    }

    public void SaveCurrentLocation(EntryFormBAL objEntryFormBal)
    {
        //string sqlQuery = "select count(*) from tbl_visitedPlaces where place = "+objEntryFormBal.place;
        //ConnectionFactory.NonQuery(sqlQuery);
        //if()
        string sqlQuery = "insert into tbl_visitedPlaces (lat, lan, place, type, description, noOfVisits, avgStayTime, avgVisitingTime) values("+objEntryFormBal.lat+", "+objEntryFormBal.lan+", '"+objEntryFormBal.place+"', '"+objEntryFormBal.type+"', '"+objEntryFormBal.description+"', "+objEntryFormBal.noOfVisits+", "+objEntryFormBal.avgStayTime+", '"+objEntryFormBal.avgVisitingTime+"')";
        ConnectionFactory.NonQuery(sqlQuery);
    }

    public List<nearBySearch> GetPlaceNames(string _lat, string _lng, int radius)
    {
        List<nearBySearch> nearBySearchList = new List<nearBySearch>();

        string apiUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?";
        string key = "AIzaSyAOKdI4jE9E_uUG333bviYqJVJtlx1wik4";
        string location = _lat + "," + _lng;
        string sensor = "false";
        WebClient webClient = new WebClient();
        string result = webClient.DownloadString(string.Format("{0}key={1}&location={2}&sensor={3}&radius={4}", apiUrl, key, location, sensor, radius));
        JObject objJSON = default(JObject);
        objJSON = JObject.Parse(result);
        Array jSonLength = objJSON["results"].ToArray();
        for (int i = 0; i < jSonLength.Length; i++)
        {
            nearBySearch objnearBySearch = new nearBySearch();
            objnearBySearch.id = objJSON["results"][i]["id"].ToString();
            objnearBySearch.lat = objJSON["results"][i]["geometry"]["location"]["lat"].ToString();
            objnearBySearch.lng = objJSON["results"][i]["geometry"]["location"]["lng"].ToString();
            objnearBySearch.name = objJSON["results"][i]["name"].ToString();
            objnearBySearch.types = objJSON["results"][i]["types"][0].ToString();
            objnearBySearch.id = objJSON["results"][i]["vicinity"].ToString();
            nearBySearchList.Add(objnearBySearch);
        }
        return new List<nearBySearch>();
    }

    public string[] getsm(string lat, string lng)
    {
        List<nearBySearch> nearBySearchList = new List<nearBySearch>();

        string apiUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?";
        string key = "AIzaSyAOKdI4jE9E_uUG333bviYqJVJtlx1wik4";
        //string lat = "17.370955";
        //string lng = "78.445473";
        string location = lat + "," + lng;
        string sensor = "false";
        string radius = "1000";
        WebClient webClient = new WebClient();
        string result = webClient.DownloadString(string.Format("{0}key={1}&location={2}&sensor={3}&radius={4}", apiUrl, key, location, sensor, radius));
        //    Response.Write(result);
        JObject objJSON = default(JObject);
        objJSON = JObject.Parse(result);
        string[] s = new string[6];
       s[0] = objJSON["results"][0]["id"].ToString();
       s[1] = objJSON["results"][0]["geometry"]["location"]["lat"].ToString();
     s[2] = objJSON["results"][0]["geometry"]["location"]["lng"].ToString();
        s[3] = objJSON["results"][0]["name"].ToString();
     s[4] = objJSON["results"][0]["types"][0].ToString();
     s[5] = objJSON["results"][0]["vicinity"].ToString();
        //  nearBySearchList.Add(objnearBySearch);

     return s;
    }


    public class nearBySearch
    {
        public string id { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string name { get; set; }
        public string types { get; set; }
        public string vicinity { get; set; }
    }

}