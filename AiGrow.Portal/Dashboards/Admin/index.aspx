<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboardMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AiGrow.Portal.Dashboards.Admin.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #widge {
            position: relative;
        }

        .text {
            font-style: oblique;
            font-weight: bold;
            font-size: larger;
            color: rgba(0, 0, 0, 0.90);
            position: absolute;
            bottom: 100%;
            left: 0;
            right: 0;
            background-color: #23f527;
            opacity: 0.7;
            overflow: hidden;
            width: 100%;
            height: 0;
            transition: .5s ease;
        }

        #widge:hover .text {
            bottom: 0;
            padding-left: 70px;
            padding-right: 70px;
            padding-top: 100px;
            height: 100%;
        }
    </style>


    <div>
        <div class="row">
            <div class="col-md-4">
                <div class="box">
                    <div class="box-header with-border">
                        <h3 class="box-title"></h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="jumbotron">
                                    <center><img src="../../img/logo.png" style="height:150px;width:inherit;" />
                                             <!--class="img-circle"-->
                                          <h3>Hello...</h3>
                                          <p>Welcome to AiGrow.<br /> This is the Administration Dashboard...</p></center>
                                </div>
                            </div>
                            <!-- /.col -->
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- ./box-body -->
                </div>
                <!-- /.box -->
            </div>
            <div class="col-md-8">
                <div class="box">
                    <div class="box-header with-border">
                        <h3 class="box-title">Greenhouse Locations</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="chart" id="map" style="height: 400px; width: 100%;">
                                </div>
                                <script>
                                    function placeMarker(map, location,message) {
                                        var marker = new google.maps.Marker({
                                            position: location,
                                            map: map
                                        });
                                        var infowindow = new google.maps.InfoWindow({
                                            content: message
                                        });
                                        infowindow.open(map,marker);
                                    }

                                    function myMap() {
                                        var mapCanvas = document.getElementById("map");
                                        var myCenter = new google.maps.LatLng(7.2822256,80.5436109);
                                        var mapOptions = { center: myCenter, zoom: 7 };
                                        var map = new google.maps.Map(mapCanvas, mapOptions);

                                         <% AiGrow.Portal.LocationListResponse locations = AiGrow.Portal.classes.GreenhouseServices.getGreenhouseLocationsById(AiGrow.SessionHandler.getLoggedInUserID(), AiGrow.SessionHandler.getToken());
                                            foreach (AiGrow.Portal.LocationResponse lr in locations.listOfLocations)
                                            { %>
                                        var location = new google.maps.LatLng(<%Response.Write(lr.latitude);%>, <%Response.Write(lr.longitude);%>);
                                        placeMarker(map, location,'<%Response.Write(lr.location_unique_id);%>');
                                        <%}  %> 
                                    }   
                                </script>
                                <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB6gFGJOvN4_C9Q4ovUtreYDVvCVZzcmB4&callback=myMap"></script>
                                <!-- /.chart-responsive -->
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- ./box-body -->
                </div>
                <!-- /.box -->
            </div>
        </div>
        <!-- /.map-->
        <div class="row">
            <% System.Data.DataTable greenhouses_dt = new AiGrow.Business.BL_Greenhouse().select();
               foreach (System.Data.DataRow row in greenhouses_dt.Rows)
               {
            %>
            <!-- Greenhouse view in the index page -->
            <div class="col-md-4">
                <!-- Widget: Greenhouse view in the index page -->
                <div class="box box-widget widget-user">
                    <div class="widget-user-header bg-white" id="widge" style="background: url('<% Response.Write(" "+row["pic_url"]); %>'); background-size: 100% 100%; height: 400px; width: inherit;">
                        <div class="text">
                            <h3 class="widget-user-username"><% Response.Write(" " + row["greenhouse_unique_id"]); %></h3>
                            <i class="ionicons ion-ios-contact-outline"><% Response.Write(" " + row["owner"]); %></i><br />
                            <i class="fa fa-map-marker"><% Response.Write(" " + row["location_address"]); %></i>
                            <br />
                        </div>
                    </div>
                    <div class="box-footer">
                        <div class="row">
                            <%  
                                                           string[] boxDetails = { "<i class=\"ionicons ion-thermometer fa-3x\"></i> <br /> <span class=\"description-text\">Temperature</span><h5 class=\"description-header\">", "<i class=\"glyphicon glyphicon-tint fa-3x\"></i> <br /> <span class=\"description-text\">Humidity</span><h5 class=\"description-header\">", "<i class=\"glyphicon glyphicon-cloud fa-3x\"></i> <br /> <span class=\"description-text\">CO<sub>2</sub></span><h5 class=\"description-header\">" };

                                                           AiGrow.Portal.DataListResponse dataList = AiGrow.Portal.classes.GreenhouseServices.getGreenhouseDeviceLeastData(AiGrow.SessionHandler.getLoggedInUserID(), AiGrow.SessionHandler.getToken(), row["greenhouse_id"].ToString());

                                                           foreach (AiGrow.Portal.DataResponse data in dataList.listOfData)
                                                           {%>
                            <div class="col-sm-4 border-right">
                                <div class="description-block">
                                    <%switch (data.device_unique_id)
                                      {
                                          case "TS_001":
                                              Response.Write(boxDetails[0] + data.data + "<sup>o</sup>c</h5>");
                                              break;
                                          case "LI_001":
                                              Response.Write(boxDetails[1] + data.data + "<sup>o</sup>c</h5>");
                                              break;
                                          case "PH_001":
                                              Response.Write(boxDetails[2] + data.data + "<sup>o</sup>c</h5>");
                                              break;
                                          
                                      }%>
                                    
                                </div>
                                <!-- /.description-block -->
                            </div>
                            <% }  %>
                        </div>
                    </div>
                    <a href="AdminGreenhouseDashboard.aspx?greenhouse_id=<% Response.Write(row["greenhouse_unique_id"]);%>" class="btn btn-block btn-social btn-facebook">
                        <i class="ionicons ion-ios-speedometer-outline"></i>Dashboard
                    </a>
                </div>
                <!-- /.widget-user -->
            </div>
            <!--/.column-->

            <% } %>
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBreadcrumbs" runat="server">
</asp:Content>
