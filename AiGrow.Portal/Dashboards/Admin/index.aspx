<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboardMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AiGrow.Portal.Dashboards.Admin.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #widge {
            position: relative;
        }

        .text {
            font-style: oblique;
            font-weight: bold;
            font-family: "Times New Roman", Times, serif;
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
                            <div class="col-sm-4 border-right">
                                <div class="description-block">
                                    <i class="ionicons ion-thermometer fa-3x"></i>
                                    <br />
                                    <span class="description-text">Temperature</span>
                                    <h5 class="description-header">29<sup>o</sup>c</h5>
                                </div>
                                <!-- /.description-block -->
                            </div>
                            <div class="col-sm-4 border-right">
                                <div class="description-block">
                                    <i class="glyphicon glyphicon-tint fa-3x"></i>
                                    <br />
                                    <span class="description-text">Humidity</span>
                                    <h5 class="description-header">96<small>%</small></h5>
                                </div>
                                <!-- /.description-block -->
                            </div>
                            <div class="col-sm-4 border-right">
                                <div class="description-block">
                                    <i class="glyphicon glyphicon-cloud fa-3x"></i>
                                    <br />
                                    <span class="description-text">CO<sub>2</sub></span>
                                    <h5 class="description-header">30<small>%</small></h5>
                                </div>
                                <!-- /.description-block -->
                            </div>
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
