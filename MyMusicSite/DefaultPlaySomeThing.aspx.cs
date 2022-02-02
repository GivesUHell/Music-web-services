using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class DefaultPlaySomeThing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.MySong.Text = "MusicList/song1.mp3";







        //object obj = (object)this.FindControl("dewplayer");
        //Parameter param = this.GetDataItem("flashvars");       
        //param.DefaultValue = "mp3=MusicList/song1.mp3";
            //HtmlControl video = (HtmlControl)this.FindControl("dewplayer");
        //video.Attributes["src"] = "mp3=MusicList/song1.mp3";

    }
}
