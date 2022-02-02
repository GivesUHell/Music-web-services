<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DefaultPlaySomeThing.aspx.cs" Inherits="DefaultPlaySomeThing" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  


    <style type="text/css">
        #Object1
        {
            width: 579px;
        }
        #dewplayer
        {
            height: 89px;
            width: 286px;
        }
    </style>
  


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
     
       <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" type="application/x-shockwave-flash" data="medias/dewplayer-bubble-vol.swf" 
            id="dewplayer" name="dewplayer" >
        <param name="movie" value="medias/dewplayer-bubble-vol.swf"  />
        <param name="flashvars" value="mp3=<%=MySong.Text%>" />
        <param name="wmode" value="transparent" />
        <embed src="medias/player_mp3_multi.swf"  
        quality="high"  
        pluginspage="http://www.macromedia.com/go/getflashplayer"  
        type="application/x-shockwave-flash" width="760" height="180"></embed> 
    </object>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
        <asp:Label ID="MySong" runat="server" Text="MusicList/song2.mp3" 
            Visible="False"></asp:Label>
     </p>
     <p>
     
     
     
      <object type="application/x-shockwave-flash" data="medias/player_mp3_multi.swf" id="Object1" name="asafplayer">
            
    <param name="movie" value="asafplayer.swf" />
    <param name="flashvars" value="mp3=MusicList/song2.mp3" />
    <param name="wmode" value="transparent" />
  
     
     </object>
     
     </p>
     <p>
   <%--  <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"  
 
    width="760" height="180" title="">  
    <param name="movie" value="medias/player_mp3_multi.swf" />  
    <param name="quality" value="high" />  
    <embed src="medias/player_mp3_multi.swf"  
        quality="high"  
        pluginspage="http://www.macromedia.com/go/getflashplayer"  
        type="application/x-shockwave-flash" width="760" height="180"></embed>  
</object>--%>
     </p>
         &nbsp;</asp:Content>

