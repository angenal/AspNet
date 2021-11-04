<%@ Register TagPrefix="eo" Namespace="EO.Web" Assembly="EO.Web" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Demos_Rating_Client_Side_Interface_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="demo" runat="Server">
    <script type="text/javascript">
//<!--JS_SAMPLE_BEGIN-->
function GetRatingText(value)
{
    switch (value)
    {
        case 0:
            return "The Worst Possible";
        case 1:
            return "Very Bad";
        case 2:
            return "Bad";
        case 3:
            return "Average";
        case 4:
            return "Good";
        case 5:
            return "Very Good";
    }
}

function on_hovervaluechange(rating)
{
    var e = document.getElementById("panHoverValue");
    e.innerHTML = "Hover Value: " + GetRatingText(rating.getHoverValue());
}

function on_valuechange(rating)
{
    var e = document.getElementById("panValue");
    e.innerHTML = "Value: " + GetRatingText(rating.getValue());
}
//<!--JS_SAMPLE_END-->
    </script>
    <p>
        The following sample demonstrates how to handle the Rating control's <b>ClientSideOnValueChange</b>
        and <b>ClientSideOnHoverValueChange</b> event with JavaScript to display the current "hover value"
        and the current "value". The current "hover value" is the value corresponding to the current
        mouse position. The current "value" is the value confirmed when user clicks the mouse.
    </p>
    <p>
        <eo:Rating runat="server" ID="Rating1" ControlSkinID="None" EmptyStarHoverImageUrl="00108004"
            EmptyStarImageUrl="00108002" FullStarHoverImageUrl="00108003" FullStarImageUrl="00108001"
            Value="3" ClientSideOnValueChange="on_valuechange" 
            ClientSideOnHoverValueChange="on_hovervaluechange">
        </eo:Rating>
    </p>
    <p id="panHoverValue">
    </p>
    <p id="panValue">
    </p>
</asp:Content>
