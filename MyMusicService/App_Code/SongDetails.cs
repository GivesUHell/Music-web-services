using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SongDetails
/// </summary>
public class SongDetails
{
    protected int SongCode;
    protected string SongName;
    protected DateTime DateOfUpload;
    protected string SongStyle;
    protected string SongArtist;
    protected string SongAlbum;
    protected string SongFile;
    protected int AlbumCode;
    protected int ArtistCode;
    protected int StyleCode;

	public SongDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string songname
    {
        get
        {
            return SongName;
        }
        set
        {
            this.SongName = value;
        }
    }
    public DateTime date
    {
        get
        {
            return DateOfUpload;
        }
        set
        {
            this.DateOfUpload = date;
        }
    }
    public string songstyle
    {
        get
        {
            return this.SongStyle;
        }
        set
        {
            this.SongStyle = value;
        }
    }
    public string songartist
    {
        get { return SongArtist; }
        set { this.SongArtist = value; }
    }
    public string songalbum
    {
        get { return SongAlbum; }
        set { this.SongAlbum = value; }
    }
    public int albumcode
    {
        get { return AlbumCode; }
        set { this.AlbumCode = value; }
    }
    public int artistcode
    {
        get { return ArtistCode; }
        set { this.ArtistCode = value; }
    }
    public int stylecode
    {
        get { return StyleCode; }
        set { this.StyleCode = value; }
    }
    public string songfile
    {
        get { return SongFile; }
        set { this.SongFile = value; }
    }
}