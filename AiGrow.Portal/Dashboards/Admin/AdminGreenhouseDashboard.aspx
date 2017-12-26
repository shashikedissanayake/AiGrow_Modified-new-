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
        <%
            AiGrow.Portal.DataListResponse dataList = AiGrow.Portal.classes.GreenhouseServices.getGreenhouseDeviceLeastData(AiGrow.SessionHandler.getLoggedInUserID(), AiGrow.SessionHandler.getToken(), HttpContext.Current.Request.QueryString["greenhouse_id"]);
        %>
        <div class="col-md-3 col-sm-6 col-xs-12">
            <div class="info-box">
                <span class="info-box-icon bg-red"><i class="ionicons ion-thermometer"></i></span>

                <div class="info-box-content">
                    <span class="info-box-text">Temperature</span>
                    <span class="info-box-number">
                        <%
                            bool printed = false;
                            if (!dataList.listOfData.Count.Equals(0))
                            {

                                foreach (AiGrow.Portal.DataResponse data in dataList.listOfData)
                                {
                                    printed = false;
                                    if (data.device_type.Equals("TEMPERATURE_SENSOR"))
                                    {
                                        Response.Write(data.data + "<sup>o</sup>c");
                                        printed = true;
                                        break;
                                    }
                                }

                                if (!printed)
                                {
                                    Response.Write("-");
                                }

                            }
                            else
                            {
                                Response.Write("-");
                            }
                   
                        %>
                    </span>
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
                    <span class="info-box-number">
                        <%
                            
                            if (!dataList.listOfData.Count.Equals(0))
                            {

                                foreach (AiGrow.Portal.DataResponse data in dataList.listOfData)
                                {
                                    printed = false;
                                    if (data.device_type.Equals("HUMIDITY_SENSOR"))
                                    {
                                        Response.Write(data.data + "<small>%</small>");
                                        printed = true;
                                        break;
                                    }
                                }

                                if (!printed)
                                {
                                    Response.Write("-");
                                }

                            }
                            else
                            {
                                Response.Write("-");
                            }
                   
                        %>

                    </span>
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

                    <span class="info-box-number">
                        <%
                            if (!dataList.listOfData.Count.Equals(0))
                            {

                                foreach (AiGrow.Portal.DataResponse data in dataList.listOfData)
                                {
                                    printed = false;
                                    if (data.device_type.Equals("CO2_SENSOR"))
                                    {
                                        Response.Write(data.data + "<small>ppm</small>");
                                        printed = true;
                                        break;
                                    }
                                }

                                if (!printed)
                                {
                                    Response.Write("-");
                                }

                            }
                            else
                            {
                                Response.Write("-");
                            }
                   
                        %>

                    </span>

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

                    <span class="info-box-number">
                        <%
                            if (!dataList.listOfData.Count.Equals(0))
                            {

                                foreach (AiGrow.Portal.DataResponse data in dataList.listOfData)
                                {
                                    printed = false;
                                    if (data.device_type.Equals("LIGHT_INTENSITY_SENSOR"))
                                    {
                                        Response.Write(data.data + "<small>W/m<sup>2</sup></small>");
                                        printed = true;
                                        break;
                                    }
                                }

                                if (!printed)
                                {
                                    Response.Write("-");
                                }

                            }
                            else
                            {
                                Response.Write("-");
                            }
                   
                        %>

                    </span>

                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->

    <div class="row">
        <form runat="server">
            <div class="col-md-8">
                <div class="box">
                    <div class="box-header with-border">
                        <h3 class="box-title">Summary Report</h3>

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
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" TabIndex="3" AutoPostBack="True" OnSelectedIndexChanged="period_select">
                                    <asp:ListItem Value="1 DAY">Today </asp:ListItem>
                                    <asp:ListItem Value="1 MONTH"> This Month </asp:ListItem>
                                    <asp:ListItem Value="3 MONTH"> Last 3 Month </asp:ListItem>
                                    <asp:ListItem Value="all" Selected="True"> All </asp:ListItem>
                                </asp:RadioButtonList>
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
                    <div class="box-body" style="height: inherit; width: 100%">
                        <img src="../../img/greenhouse_img1.jpg" style="height: inherit; width: inherit" />
                    </div>

                </div>
            </div>
        </form>
    </div>
    <!-- /.row -->

</asp:Content>
