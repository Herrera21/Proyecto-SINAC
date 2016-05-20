using CapaConfiguracion;
using Sistema.CapaConfiguracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema.CapaPresentacion.Html.BombForest
{
    public partial class CPoliza : System.Web.UI.Page
    {

        private void filterBindData()
        {
            BindData(true);
            GridView1.PageIndexChanging += GridView1_PageIndexChanging;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VariablesSeccionControl.Lee<string>("userAreaConserv") == null)
            {
                Response.Redirect("/index.aspx");
            }
            else
            {

                filterBindData();
            }
        }

        protected void activaInactivaModal(string id, bool activar)
        {
            if (activar)
            {
                string script = string.Format("javascript:$('#" + id + "').modal('show');");
                ScriptManager.RegisterStartupScript(this, Page.ClientScript.GetType(), null, script, true);
            }
            else
            {
                string script = string.Format("javascript:$('#" + id + "').modal('hide');");
                ScriptManager.RegisterStartupScript(this, Page.ClientScript.GetType(), null, script, true);
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            filterBindData();
        }


        private void BindData(bool activo)
        {
            PolizaDB temp = new PolizaDB();
            GridView1.DataSource = temp.seleccionar_Dataset_AsignPolizaBom(VariablesSeccionControl.Lee<string>("Bombero"));
            GridView1.DataBind();
        }

        private int seleccionar(int index)
        {
            //
            // Obtengo el id de la entidad que se esta editando
            // en este caso de la entidad Person
            //
            return Convert.ToInt32(GridView1.DataKeys[index].Values["PK_Id_BomberoPoliza"]);
        }

        protected void gvPerson_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //
                // Se obtiene indice de la row seleccionada
                //
                int index = Convert.ToInt32(e.CommandArgument);

                seleccionar(index);
            }

        }

        protected void buttonConsultar_Click(object sender, ImageClickEventArgs e)
        {
            if (GridView1.SelectedRow != null /*&& ButtonMuestra.Text.Equals(buttonName)*/)
            {
                VariablesSeccionControl.Escribe("BomberoPoliza", seleccionar(GridView1.SelectedRow.RowIndex));
                Response.Redirect("CBeneficiarios.aspx");
            }
        }
    }
}