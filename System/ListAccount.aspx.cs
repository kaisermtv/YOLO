﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_ListAccount : System.Web.UI.Page
{
    #region declare
    private DataAccount objAccount = new DataAccount();

    public int index = 0;

    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Items["strTitle"] = "DANH SÁCH TÀI KHOẢN";

        if (!Page.IsPostBack)
        {
            getData();
        }
    }
    #endregion

    #region method getData()
    private void getData()
    {
        DataTable objData = objAccount.getList();

        //dtlAccount.DataSource = objData.DefaultView;
        //dtlAccount.DataBind();

        cpAccount.MaxPages = 1000;
        cpAccount.PageSize = 15;
        cpAccount.DataSource = objData.DefaultView;
        cpAccount.BindToControl = dtlAccount;

        dtlAccount.DataSource = cpAccount.DataSourcePaged;
        dtlAccount.DataBind();

        index = 1;
    }
    #endregion

    #region method btnDel_Click
    protected void btnDel_Click(object sender, EventArgs e)
    {
        int id;
        try
        {
            id = int.Parse(idDel.Value);
        }
        catch
        {
            SystemClass objSystemClass = new SystemClass();
            objSystemClass.addMessage("Có lỗi xảy ra!");
            return;
        }

        if (id != 0)
        {
            objAccount.delAccount(id);

            getData();
        }
        else
        {
            SystemClass objSystemClass = new SystemClass();
            objSystemClass.addMessage("Có lỗi xảy ra!");
            return;
        }

        
    }
    #endregion
}