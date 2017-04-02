using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

public partial class suggestall : System.Web.UI.Page
{

    suggestallBAL objsuggestallBAL = new suggestallBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        string lng = Session["longi"].ToString();
        string lat = Session["lati"].ToString();
        try
        {
            DataSet ds = objsuggestallBAL.GetData();
            gvsuggestall.DataSource = ds;
            gvsuggestall.DataBind();
        }
        catch
        {Response.Write("No Data");
        }
    }
    public string ConvertDataTabletoString(string _lat, string _lng, int radius, params string[] types)
    {
        List<nearBySearch> nearBySearchList = new List<nearBySearch>();
            string apiUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?";
            string key = "AIzaSyAOKdI4jE9E_uUG333bviYqJVJtlx1wik4";
            string location = _lat + "," + _lng;
            string sensor = "false";
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString(string.Format("{0}key={1}&location={2}&sensor={3}&radius={4}", apiUrl, key, location, sensor, radius));
            //   Response.Write(result);
            JObject objJSON = default(JObject);
            objJSON = JObject.Parse(result);
            Array jSonLength = objJSON["results"].ToArray();

            for (int i = 0; i < jSonLength.Length; i++)
            {
                WebClient objWebClient = new WebClient();
                string distance = objWebClient.DownloadString(string.Format("https://maps.googleapis.com/maps/api/distancematrix/json?origins={0},{1}&destinations={2},{3}&sensor=false", _lat, _lng, objJSON["results"][i]["geometry"]["location"]["lat"].ToString(), objJSON["results"][i]["geometry"]["location"]["lng"].ToString()));
                JObject objJSON1 = default(JObject);
                objJSON1 = JObject.Parse(distance);

                nearBySearch objnearBySearch = new nearBySearch();
                objnearBySearch.id = objJSON["results"][i]["id"].ToString();
                objnearBySearch.lat = objJSON["results"][i]["geometry"]["location"]["lat"].ToString();
                objnearBySearch.lng = objJSON["results"][i]["geometry"]["location"]["lng"].ToString();
                objnearBySearch.name = objJSON["results"][i]["name"].ToString();
                objnearBySearch.types = objJSON["results"][i]["types"][0].ToString();
                objnearBySearch.vicinity = objJSON["results"][i]["vicinity"].ToString();
                objnearBySearch.distance = objJSON1["rows"][0]["elements"][0]["distance"]["text"].ToString();
                nearBySearchList.Add(objnearBySearch);
            }
        
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(nearBySearchList);
    }
}
public class nearBySearch
{
    public string id { get; set; }
    public string lat { get; set; }
    public string lng { get; set; }
    public string name { get; set; }
    public string types { get; set; }
    public string vicinity { get; set; }
    public string distance { get; set; }
}