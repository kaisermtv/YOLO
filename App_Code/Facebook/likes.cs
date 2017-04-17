using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for likes
/// </summary>
public class likes
{
    public string id { get; set; }
    public string name { get; set; }
    public List<likes> data { get; set; }
	public likes( string _id = " " , string _name = " " )
	{
        this.id = _id;
        this.name = _name;
	}
    public likes()
    {
       // this.name = " ";
    }
    public string toString()
    {
        return this.data.Count + "";
    }
}