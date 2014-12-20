using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization;

public partial class details_view : System.Web.UI.Page
{
    dal dl = new dal();
    bal_file bl = new bal_file();
    private string x;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DetailsView1.DataSource = bl.bind_grid();
            DetailsView1.DataBind();
            Chart1.DataSource = bl.bind_grid();
            Chart1.DataBind();
          //  Chart1.Series["Series1"].XValueMember = "X";
          // Chart1.DataManipulator.Sort(pointSortOrder)
        }

    }
    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {
        DetailsView1.PageIndex = e.NewPageIndex;
        DetailsView1.DataSource = bl.bind_grid();
        DetailsView1.DataBind();

    }
    protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        DetailsView1.ChangeMode(e.NewMode);
        DetailsView1.DataSource = bl.bind_grid();
        DetailsView1.DataBind();
    }
    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        dl.id = Convert.ToInt16(DetailsView1.DataKey.Value);
        TextBox t1 = (TextBox)DetailsView1.FindControl("TextBox2");
        dl.name = t1.Text;
        bl.update_stud(dl);
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        DetailsView1.DataSource = bl.bind_grid();
        DetailsView1.DataBind();
    }
    protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        TextBox t1 = (TextBox)DetailsView1.FindControl("TextBox2");
        dl.name = t1.Text;
        bl.inser_stud(dl);
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        DetailsView1.DataSource = bl.bind_grid();
        DetailsView1.DataBind();

    }
    protected void DetailsView1_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        dl.id = Convert.ToInt16(DetailsView1.DataKey.Value);
        bl.delete_stud(dl);
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        DetailsView1.DataSource = bl.bind_grid();
     //   Chart1.Series["Series1"].XValueMember = "X";
     //   Chart1.Series["Series1"].Sort(System.Web.UI.DataVisualization.Charting.PointSortOrder.Descending, "Y");
        DetailsView1.DataBind();


    }
    protected void Chart1_DataBound(object sender, EventArgs e)
    {
       // Chart1.Series["Series1"].Sort(System.Web.UI.DataVisualization.Charting.PointSortOrder.Ascending, "X");
       // Chart1.Series["Series1"].Sort(pointSortOrder:)
      Chart1.DataManipulator.Sort(System.Web.UI.DataVisualization.Charting.PointSortOrder.Descending, "Y", "Series1");
       
      Chart1.DataManipulator.FilterTopN(2, "Series1");
    }
    protected void Chart1_DataBinding(object sender, EventArgs e)
    {
       // Chart1.DataManipulator.Sort(pointSortOrder:asc, "Y", "Series1");
        //Chart1.Series["Series1"].Sort(System.Web.UI.DataVisualization.Charting.PointSortOrder.Ascending, "Y" );
    }
}