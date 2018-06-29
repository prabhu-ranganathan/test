<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DynaRep.ascx.cs" Inherits="Multilevel.DynaRep" %>
<style type="text/css">
    /* menu item styles */
#navcontainer
{
	border-left: solid 0px Gray;
	border-Top: solid 0px Gray;
	border-bottom: solid 1px Gray;	
	border-right: solid 1px Gray;	
	height: 400px;
	width : 200px; 
	overflow:hidden;
}
#menuroot
{
	vertical-align :middle;
	font-family: Segoe UI, Verdana, Tahoma, Helvetica, Arial, sans-serif;
	font-size: 11pt ;
	list-style-type:circle;
	list-style-position: inside; 			
	margin: 0;
	padding: 15px 0 0 5px;
	color : Maroon ;
	line-height: 2em;
	
} 
#menuroot li 
{ 
	padding:3px;
	text-align: left;	
	vertical-align :middle;	
	
} 
#menuroot a
{
	width: 150px;
	line-height: 2em;
	display:block;	
	text-decoration: underline;
	font-weight: bold;  
	line-height: normal;
} 
#menuroot a:link, #menuroot a:visited
{
	color:Black;	
	text-decoration: none;
	font-weight :lighter  ;
	font-size: 10pt ;
	line-height: normal;
} 
#menuroot a:hover
{
	color:Maroon;  	
	text-decoration: none;
	font-size: 10pt ;
	line-height: normal;
}


/* right hand menu second level */
#menusecondlevel
{
	vertical-align :middle;
	font-family: Segoe UI, Verdana, Tahoma, Helvetica, Arial, sans-serif;
	list-style-type:square;
	list-style-position: inside; 			
	margin: 0;
	padding: 0 0 0 10px;
	line-height: 1.5em;
} 
#menusecondlevel li 
{ 
	padding:1px;
	text-align: left;	
	vertical-align :middle;
} 
#menusecondlevel a
{
	width: 150px;
	display:block;	
	font-weight: normal;  
	font-size: 3pt ;
	text-decoration: none;		
} 
#menusecondlevel a:link, #menusecondlevel a:visited
{
	color:Black;	
} 
#menusecondlevel a:hover
{
	color:Maroon;  	
}
</style>
<div>
    <asp:Repeater ID="FirstLevelMenuRepeater" runat="server" OnItemDataBound="FirstLevelMenuRepeater_ItemDataBound">
        <HeaderTemplate>
            <div id="navcontainer">
                <ul id="menuroot">
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink ID="FirstLevelMenu" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Url") %>'
                    Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' ToolTip='<%# DataBinder.Eval(Container.DataItem, "Desc") %>'>
                </asp:HyperLink>
                <asp:Repeater ID="SecondLevelMenuRepeater" runat="server" >
                    <HeaderTemplate>
                            <ul id="menusecondlevel">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink ID="SecondLevelMenu" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Url") %>'
                                Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' ToolTip='<%# DataBinder.Eval(Container.DataItem, "Desc") %>'>
                            </asp:HyperLink>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul></FooterTemplate>
                </asp:Repeater>                
            </li>
        </ItemTemplate>
        <FooterTemplate>
                </ul>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</div>