<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" MasterPageFile="~/MainMaster.master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<style type="text/css">
html { height: 100% }
body { height: 100%; margin: 0; padding: 0 }
#map_canvas { height: 100% }
</style>
<script type="text/javascript"
src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC6v5-2uaq_wusHDktM9ILcqIrlPtnZgEk&sensor=false">
</script>
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false&libraries=places">
</script>
<script type="text/javascript">
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(success);
    } else {
        alert("Geo Location is not supported on yohour current browser!");
    }
    function success(position) {
        var lat ='<%= Session["lati"].ToString() %>';
        var long = '<%= Session["longi"].ToString()%>';
        var city = position.coords.locality;
        var myLatlng = new google.maps.LatLng(lat, long);
        var myOptions = {
            center: myLatlng,
            zoom: 12,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
        var marker = new google.maps.Marker({
            position: myLatlng,
            title: "lat: " + lat + " long: " + long
        });

        marker.setMap(map);
        var infowindow = new google.maps.InfoWindow({ content: "<b>User Address</b><br/> Latitude:" + lat + "<br /> Longitude:" + long + "" });
        infowindow.open(map, marker);
    }
</script>--%>
    <style type="text/css">
html { height: 100% }
body { height: 100%; margin: 0; padding: 0 }
#map_canvas { height: 100% }
</style>
<script type="text/javascript"
src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC6v5-2uaq_wusHDktM9ILcqIrlPtnZgEk&sensor=false">
</script>
<script type="text/javascript">
    function initialize() {
        var lat = '<%= Session["lati"].ToString() %>';
        var long = '<%= Session["longi"].ToString()%>';
        var myLatlng = new google.maps.LatLng(lat, long);
        var mapOptions = {
            center: myLatlng,
            zoom: 12,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            marker: true
        };
        var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
        var marker = new google.maps.Marker({
            position: myLatlng,
            icon: 'Map-Marker.png',
            title: "My Location"
        });
        marker.setMap(map);
    }
</script>
<body onload="initialize()">
    <div id="body">
			<div>
				<div>
					<div class="featured">
				<table width="100%" height="100%">
                    <tr>
                        <td>
                        <table width="100%">
                            <tr>
                                <td>
                                     <div id="img" runat="server" ></div>
                                </td>
                            </tr>
                        </table>
                           
                        </td>
                        <td>
<table width="100%">
    <tr>
        <td colspan="2">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
         <b> Lattitude ::&nbsp; &nbsp;<asp:TextBox ID="txtlat" runat="server" ></asp:TextBox>
        </td><td>
         <b> Longitude :: <asp:TextBox ID="txtlongitude" runat="server" align="right"></asp:TextBox>
        </td>
        </tr>
    <tr>
        <td>
         <b> Time Spent ::</b> <asp:TextBox ID="txttimespent" runat="server"></asp:TextBox>
        </td><td>
         <b> Current Time ::</b> <asp:DropDownList ID="ddlcurrenttime" runat="server" >
              <asp:ListItem Value="07:00">Morning</asp:ListItem>
                        <asp:ListItem Value="14:00">Afternoon</asp:ListItem>
                        <asp:ListItem Value="12:00">Noon</asp:ListItem>
                        <asp:ListItem Value="18:00">Evening</asp:ListItem>
                        <asp:ListItem Value="20:00">Night</asp:ListItem>
                        <asp:ListItem Value="10:00">Late Night</asp:ListItem>
                                 </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td colspan="2" align="center" >
            <asp:Button ID="btnsubmit" runat="server" Text="Show" OnClick="btnsubmit_Click" />
        </td>
    </tr>
</table>
                       <div id="map_canvas" style="width: 500px; height: 300px"></div> </td>
                    </tr>
				</table>
					</div>
                    </div>
                </div>
        </div>
    
</asp:Content>
