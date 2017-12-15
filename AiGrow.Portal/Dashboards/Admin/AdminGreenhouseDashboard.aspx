<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboardMaster.Master" AutoEventWireup="true" CodeBehind="AdminGreenhouseDashboard.aspx.cs" Inherits="AiGrow.Portal.Dashboards.Admin.AdminGreenhouseDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphH1Main" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphH1Small" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbs" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    
    <!-- Info boxes -->
    <div class="row">

        <div class="col-md-3 col-sm-6 col-xs-12">
            <div class="info-box">
                <span class="info-box-icon bg-red"><i class="ionicons ion-thermometer"></i></span>

                <div class="info-box-content">
                    <span class="info-box-text">Temperature</span>
                    <span class="info-box-number">29<sup>0</sup>C</span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- /.col -->

        <div class="col-md-3 col-sm-6 col-xs-12">
            <div class="info-box">
                <span class="info-box-icon bg-aqua"><i class="glyphicon glyphicon-tint"></i></span>

                <div class="info-box-content">
                    <span class="info-box-text">Humidity</span>
                    <span class="info-box-number">90<small>%</small></span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- /.col -->


        <!-- fix for small devices only -->
        <div class="clearfix visible-sm-block"></div>

        <div class="col-md-3 col-sm-6 col-xs-12">
            <div class="info-box">
                <span class="info-box-icon bg-green"><i class="glyphicon glyphicon-cloud"></i></span>

                <div class="info-box-content">
                    <span class="info-box-text">CO<sub>2</sub></span>
                    <span class="info-box-number">30<small>%</small></span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class="col-md-3 col-sm-6 col-xs-12">
            <div class="info-box">
                <span class="info-box-icon bg-yellow"><i class="ionicons ion-ios-partlysunny"></i></span>

                <div class="info-box-content">
                    <span class="info-box-text">Light Intensttivity</span>
                    <span class="info-box-number">76<small>W/m<sup>2</sup></small></span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->

    <div class="row">
        <div class="col-md-8">
            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">Daily Recap Report</h3>

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
                            <p class="text-center">
                                <strong>Date : <%DateTime time = new DateTime(); time = DateTime.Now.Date; Response.Write(time.ToString("D")); %></strong>
                            </p>
                            <script type="text/javascript" src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>
                            <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
                            <div class="chart" id="chart" style="height: 400px; width: 100%;">
                                <!-- Sales Chart Canvas -->

                            </div>


                            <!-- /.chart-responsive -->
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
        <!-- /.col -->
        <div class="col-md-4">
            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">Green House View</h3>

                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                            <i class="fa fa-minus"></i>
                        </button>
                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <div class="box-body" style="height :inherit; width : 100%">
                    <img src="../../img/greenhouse_img1.jpg" style="height:inherit; width:inherit" />
                </div>

            </div>
        </div>

    </div>
    <!-- /.row -->

</asp:Content>
