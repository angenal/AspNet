<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AutoFill1.aspx.cs" Inherits="Demos_Splitter_Features_Auto_Fill_Window_AutoFill1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
        <form id="Form1" method="post" runat="server">
            <eo:Splitter runat="server" id="Splitter1" Width="300px" BorderStyle="Solid" DividerSize="10"
                BorderWidth="1px" BorderColor="#B5B5B5" ControlSkinID="None" Height="200px" DividerImage="00080411"
                DividerCenterImage="00080412" AutoFillWindow="True">
                <eo:SplitterPane id="SplitterPane1" runat="server" Width="150px">
                    <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">Left 
                        Pane Contents</DIV>
                </eo:SplitterPane>
                <eo:SplitterPane id="SplitterPane2" runat="server">
                    <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">
                    Resize the Window and see the splitter automatically resizes.
                    </DIV>
                </eo:SplitterPane>
            </eo:Splitter>
        </form>
</body>
</html>
