using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SongInList
/// </summary>
public class SongInList : SongDetails
{
    protected int SongsInListCode;
    protected int placeinlist;
	public SongInList()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //public SongInList(int songcode,int placeinlist,string songname, DateTime date,string SongStyle,string SongArtist, string SongAlbum)
    //    : base(songcode,songname, date, SongStyle,SongArtist,SongAlbum) 
    //{
    //    this.placeinlist = placeinlist;
    //}
    public SongInList(int SongsInListCode,int placeinlist, string songname, DateTime date, string SongStyle, string SongArtist, string SongAlbum,string SongUploader)
        : base(songname, date, SongStyle, SongArtist, SongAlbum,SongUploader)
    {
        this.songinlistcode = SongsInListCode;
        this.placeinlist = placeinlist;
    }
    public SongInList(int SongCode, string SongName, string NameStyle, string SongArtist, string SongAlbum, string FileName)
        : base(SongCode, SongName, NameStyle, SongArtist, SongAlbum, FileName)
    {
    }

    public int Placeinlist
    {
        get
        {
            return placeinlist;
        }
        set
        {
            this.placeinlist = value;
        }
    }
    public int songinlistcode
    {
        get { return SongsInListCode; }
        set{ this.SongsInListCode=value;}
    }
}