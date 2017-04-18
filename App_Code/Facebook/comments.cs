using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for comments
/// </summary>
public class comments
{
    public string created_time { get; set; }
    public string from { get; set; }
    public string message { get; set; }
    public string id { get; set; }
    public string summary { get; set; }
    public List<comments> data { get; set; }
    public comments(string _message , string _id = " ", string _from = " ", string _created_time = "",string _summary = "0")
	{
        this.id = _id;
        this.message = _message;
        this.from = _from;
        this.summary = _summary;
        this.created_time = _created_time;
	}
    public comments( string _summary )      // chỉ lấy nớ thôi :))
    {
        this.summary = _summary;
    }
    public comments()
    {
     //   this.message = " ";
    }

    public string toString()
    {
        return this.data.Count + "";
    }
}