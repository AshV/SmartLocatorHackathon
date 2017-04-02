<%@ Page Language="C#" AutoEventWireup="true" CodeFile="suggestall.aspx.cs" Inherits="suggestall" MasterPageFile="~/MainMaster.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script>
         alert("This Page Shows all his Favorite Types of Places user visites alot and suggest where is nearby location of same Type.");
    </script>
    <style type="text/css">
html { height: 100% }
body { height: 100%; margin: 0; padding: 0 }
#map_canvas { height: 100% }
</style>
<script type="text/javascript" src = "https://maps.googleapis.com/maps/api/js?key=AIzaSyC6v5-2uaq_wusHDktM9ILcqIrlPtnZgEk&sensor=false">
</script>
<script type="text/javascript">
    function initialize() {
        var markers = JSON.parse('<%=ConvertDataTabletoString( Session["lati"].ToString(),Session["longi"].ToString(), 1000) %>');
        var mapOptions = {
            center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
            zoom: 16,
            mapTypeId: google.maps.MapTypeId.ROADMAP
            //  marker:true
        };

        var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
        for (i = 0; i < markers.length + 1; i++) {
            if (i != markers.length) {
                var data = markers[i];
                var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    title: markers[i].name + "  Distance: " + markers[i].distance
                });
                (function (marker, data) {

                    // Attaching a click event to the current marker
                    google.maps.event.addListener(marker, "click", function (e) {
                        var infoWindow = new google.maps.InfoWindow({ content: "<b>User Address</b><br/> Latitude:" + data.lat + "<br /> Longitude:" + data.lng + "" });
                        infoWindow.setContent(data.description);
                        infoWindow.open(map, marker);
                    });
                })(marker, data);
            }
            else {
                var data = null;
                var myLatlng = new google.maps.LatLng(markers[0].lat, markers[0].lng);
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    icon: 'Map-Marker.png',
                    title: "Ameerpet"
                });
                (function (marker, data) {

                    // Attaching a click event to the current marker
                    google.maps.event.addListener(marker, "click", function (e) {
                        var infoWindow = new google.maps.InfoWindow({ content: "<b>User Address</b><br/> Latitude:" + markers[0].lat + "<br /> Longitude:" + markers[0].lng + "" });
                        infoWindow.setContent(data.description);
                        infoWindow.open(map, marker);
                    });
                })(marker, data);
            }
            (function (marker, data) {

                // Attaching a click event to the current marker
                google.maps.event.addListener(marker, "click", function (e) {
                    // var infoWindow = new google.maps.InfoWindow({ content: "<b>User Address</b><br/> Latitude:" + data.lat + "<br /> Longitude:" + data.lng + "" });
                    infoWindow.setContent(data.description);
                    infoWindow.open(map, marker);
                });
            })(marker, data);
        }
    }
</script>
    <body onload="initialize()"> 
     <div id="body" >
			<div>
				<div>
					<div class="featured">
				            <table align="center" width="100%" height="100%">
                    <tr>
                        <td>
                            <div id="map_canvas" style="width: 500px; height: 400px"></div>

                            </div>
                        </td>
                        <td>
                            <asp:GridView ID="gvsuggestall" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" >
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                <FooterStyle BackColor="Tan" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                            </asp:GridView>
                        </td>
                    </tr>
				</table>
					</div>
                    </div>
                </div>
        </div>
        </body>
</asp:Content>
