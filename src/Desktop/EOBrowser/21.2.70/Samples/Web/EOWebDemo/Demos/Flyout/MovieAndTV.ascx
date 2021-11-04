<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MovieAndTV.ascx.cs" Inherits="Demos_Flyout_MovieAndTV" %>
<div style="border: solid 1px #404040; padding: 5px; background-color:White;">
    <style type="text/css">
        .image_cell
        {
            padding-left:10px;
            padding-right: 15px;
            padding-top: 3px;
            padding-bottom: 3px;
        }
    
        .demo_item_title
        {
         margin-left: 5px;
         margin-top: 4px;
         font-family: Arial;
         font-size: 13px;
         font-weight: bold;
         color: #004b91;         
        }
        
        .demo_item
        {
            font-family: Verdana;
            font-size: 11px;
            color: #004b91;
        }
    </style>
    <p style="font-size: 14px; font-family: Arial; color:#e47911; font-weight:bold;">
        Browse Movies & TV Store
    </p>
    <asp:Label runat="server" ID="lblMsg"></asp:Label>
    <table border="0" cellpadding="0" cellspacing ="0">
        <tr>
            <td class="image_cell">
                <img src="../Images/deals.gif" />
            </td>
            <td class="image_cell">
                <img src="../Images/on_demand.gif" />
            </td>
            <td class="image_cell">
                <img src="../Images/deal_of_the_day.gif" />
            </td>
        </tr>
        <tr>
            <td valign="top">
                <div class="demo_item_title">
                    Today's deal
                </div>
                <ul style="margin-left:18px; margin-top:5px; margin-bottom: 5px; padding: 0px;">
                    <li><a class="demo_item" href="http://www.essentialobjects.com">TV Shows</a></li>
                    <li><a class="demo_item" href="http://www.essentialobjects.com">Exercise & Fitness</a></li>
                    <li><a class="demo_item" href="http://www.essentialobjects.com">Deals Under $10</a></li>
                </ul>
            </td>
            <td valign="top">
                <div class="demo_item_title">
                    Disc+ On Demand
                </div>
                <ul style="margin-left:18px; margin-top:5px; margin-bottom: 5px; padding: 0px;">
                    <li><a class="demo_item" href="http://www.essentialobjects.com">DVD</a></li>
                    <li><a class="demo_item" href="http://www.essentialobjects.com">Blu-ray</a></li>
                    <li><a class="demo_item" href="http://www.essentialobjects.com">Shop All</a></li>
                </ul>
            </td>
            <td valign="top">
                <div class="demo_item_title">
                    Cast Your Vote
                </div>
                <ul style="margin-left:18px; margin-top:5px; margin-bottom: 5px; padding: 0px;">
                    <li><a class="demo_item" href="http://www.essentialobjects.com">Choose from this list</a></li>
                    <li><a class="demo_item" href="http://www.essentialobjects.com">Sign in to vote</a></li>
                    <li><a class="demo_item" href="http://www.essentialobjects.com">Shop the Gold Box</a></li>
                </ul>
            </td>
        </tr>
    </table>
</div>