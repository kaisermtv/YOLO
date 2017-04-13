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
    public List<comments> data { get; set; }
    public comments(string _message , string _id = " ", string _from = " ", string _created_time = "")
	{
        this.id = _id;
        this.message = _message;
        this.from = _from;
        this.created_time = _created_time;
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