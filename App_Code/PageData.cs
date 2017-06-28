using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PageData
/// </summary>
public class PageData
{
	private string name;
    private string link;
    private bool active;

    public PageData(string name, string link = "",bool active = false)
    {
        this.name = name;
        this.link = link;
    }

          public string Name {
             get {
                return name;
             }
          }

          public string Link
          {
             get {
                 return link;
             }
          }

          public bool Active
          {
              get
              {
                  return active;
              }
          }
}