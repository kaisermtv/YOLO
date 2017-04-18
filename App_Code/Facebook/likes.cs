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
    public string summary { get; set; }
    public List<likes> data { get; set; }
	public likes( string _id = " " , string _name = " " ,string _summary = "0")
	{
        this.id = _id;
        this.name = _name;
        this.summary = _summary;    
    }
    public likes(string _summary)           // chưa dùng mấy thứ còn lại
    {
      
        this.summary = _summary;
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