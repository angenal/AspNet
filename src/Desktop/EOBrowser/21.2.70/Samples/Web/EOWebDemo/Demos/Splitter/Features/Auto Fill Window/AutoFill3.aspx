<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AutoFill3.aspx.cs" Inherits="Demos_Splitter_Features_Auto_Fill_Window_AutoFill3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
        <form id="Form1" method="post" runat="server">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3">
                        <div style="HEIGHT:30px" align="center">
                            top margin
                        </div>
                    </td>
                </tr>
                <tr>
                    <td vAlign="middle">
                        <div style="WIDTH:30px">
                            left margin
                        </div>
                    </td>
                    <td>
                        <eo:Splitter runat="server" id="Splitter1" Width="300px" BorderStyle="Solid" DividerSize="10"
                            BorderWidth="1px" BorderColor="#B5B5B5" ControlSkinID="None" Height="200px" DividerImage="00080411"
                            DividerCenterImage="00080412" AutoFillWindow="True" HeightMargin="60" WidthMargin="60">
                            <eo:SplitterPane id="SplitterPane1" runat="server" Width="150px">
                                <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">Left 
                                    Pane Contents</DIV>
                            </eo:SplitterPane>
                            <eo:SplitterPane id="SplitterPane2" runat="server">
                                <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px">
                                    <p>
                                    Resize 
                                    the Window and see the splitter automatically resizes.
                                    </p>
                                    <p>
                                    This sample uses <b>WidthMargin</b> and <b>HeightMargin</b>
                                    to reserve additional space on the right side and the bottom
                                    side of the splitter.
                                    </p>
                                </DIV>
                            </eo:SplitterPane>
                        </eo:Splitter>
                    </td>
                    <td vAlign="middle">
                        <div style="WIDTH:30px">
                            right margin
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">bottom margin</td>
                </tr>
            </table>
        </form>
</body>
</html>
