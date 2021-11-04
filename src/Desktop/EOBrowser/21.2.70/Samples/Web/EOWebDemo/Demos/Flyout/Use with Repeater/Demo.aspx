<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demos_Flyout_Use_with_Repeater_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" Runat="Server">
    <p>
    The following sample demonstrates how to use the Flyout control
    with a standard ASP.NET Repeater control. Move mouse over the images
    to see it in action.
    </p>
    <p style="color:#e47911; font-family:Arial;font-size:11px; font-weight:bold;">
    Bestsellers
    </p>
    <asp:Repeater runat="server" ID="Repeater1">
        <ItemTemplate>            
            <asp:LinkButton runat="server" ID="LinkButton1"><img src='<%#Eval("small_tn_path")%>' style="border:0px" /></asp:LinkButton>
            &nbsp;
            <eo:Flyout runat="server" ID="Flyout1" For="LinkButton1" ExpandDirection="BottomRight">
                <ContentTemplate>
                    <div style="border: solid 1px #404040; padding: 5px; width: 400px; color: Black; background-color:White;">
                        <p style="font-family:Arial; font-size: 22px; line-height: 28px;">
                            <%#Eval("title")%>
                        </p>
                        <p>
                            <%#Eval("cast")%>
                        </p>
                        <div style="position:relative; top:-10px;">
                            <b>Rating: </b>
                            <img src='<%#Eval("rating")%>' style="position:relative; top:2px;" />
                            &nbsp;&nbsp;
                            <b>Format:</b>
                            <img src='<%#Eval("format")%>' style="position:relative; top:6px;" />
                        </div>
                        <div style="position:relative">
                            <img style="position:absolute; z-index:1;" src="../Images/rating_bg.gif" />
                            <img style='position:absolute; z-index:2; clip: rect(auto <%#GetRatingBarWidth(Eval("review_rating"))%> auto auto);' src="../Images/rating_fg.gif" />
                            <div style="position:absolute; left: 100px; top: -3px;">
                            (<a href="javascript:void(0);"><%#Eval("total_reviews")%> customer reviews</a>)
                            </div>
                            &nbsp;
                        </div>
                        <hr size=1 style="border-top: dashed 1px #999999" />
                        <table border="0" cellpadding="2" cellspacing="0">
                            <tr>
                                <td style="color: #666; white-space:nowrap; vertical-align: top" >
                                    List Price:
                                </td>
                                <td style="text-decoration: line-through">
                                    $<%#Eval("list_price", "{0:##.##}")%>
                                </td>
                            </tr>
                            <tr>
                                <td style="color: #666; white-space:nowrap; vertical-align: top" >
                                    Price:
                                </td>
                                <td>
                                    <span style="color: #900; font-size: 18px;">$<%#Eval("price", "{0:##.##}")%></span> & eligible for 
                                    <b>FREE Super Saver Shipping</b> on orders over $25. <a href="javascript:void(0)">Details</a>
                                </td>
                            </tr>
                            <tr>
                                <td style="color: #666; white-space:nowrap; vertical-align: top" >
                                    You Save:
                                </td>
                                <td>
                                    <span style="color: #990000; font-size: 12px">
                                    <%#GetSavings()%>
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </eo:Flyout>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

