using EFProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EFProject
{
    public partial class InsertingWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MunipacilityDropDown.Enabled = true;
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
        }


        protected void InsertRegion_Click(object sender, EventArgs e)
        {
            if(RegionTextBox.Text != "")
            {
                Label1.Visible = false;
                Model tempContext = new Model();

                var regionDB = tempContext.Regions.Where(x => x.RegionName.ToLower() == RegionTextBox.Text.ToLower()).FirstOrDefault();

                RegionClass regionClass = new RegionClass();
                if (regionDB == null)
                {
                    regionClass.RegionName = RegionTextBox.Text;
                    tempContext.Regions.Add(regionClass);
                    RegionListBox1.Items.Add(regionClass.RegionName);
                    RegionListBox2.Items.Add(regionClass.RegionName);
                    tempContext.SaveChanges();
                }
                else
                {
                    regionClass = regionDB;
                    Label1.Text = "Region already exists";
                    Label1.Visible = true;
                }
                RegionTextBox.Text = "";
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Insert a valid Region!";
            }
            
        }

        protected void InsertMunicipality_Click(object sender, EventArgs e)
        {
            if(MunipacilityTextBox.Text != "")
            {
                Model tempContext = new Model();

                var municipalityDB = tempContext.Municipalities.Where(x => x.MunicipalityName.ToLower() == MunipacilityTextBox.Text.ToLower()).FirstOrDefault();
                RegionClass regionClass = new RegionClass();
                MunicipalityClass municipalityClass1 = new MunicipalityClass();
                if (municipalityDB == null)
                {
                    municipalityClass1.MunicipalityName = MunipacilityTextBox.Text;
                    municipalityClass1.RegionClass = (RegionClass)tempContext.Regions.Where(x => x.RegionName == (string)RegionListBox1.SelectedValue.ToString()).FirstOrDefault();
                    MunipacilityDropDown.Items.Add(municipalityClass1.MunicipalityName);
                    tempContext.Municipalities.Add(municipalityClass1);
                }
                else
                {
                    municipalityClass1 = municipalityDB;
                }
                tempContext.SaveChanges();
                MunipacilityTextBox.Text = "";
            }
            else
            {
                Label2.Visible = true;
                Label2.Text = "Insert a valid Municipality!";
            }
            
        }
        [WebMethod]
        protected void InsertSettlement_Click(object sender, EventArgs e)
        {
            if(SettlementTextBox.Text != "")
            {
                Model tempContext = new Model();
                var settlementDB = tempContext.Settlements.Where(x => x.SettlementName.ToLower() == SettlementTextBox.Text.ToLower()).FirstOrDefault();
                SettlementClass settlementClass1 = new SettlementClass();
                MunicipalityClass municipalityClass1 = new MunicipalityClass();

                if (settlementDB == null)
                {
                    settlementClass1.SettlementName = SettlementTextBox.Text;
                    settlementClass1.MunicipalityClass = (MunicipalityClass)tempContext.Municipalities.Where(x => x.MunicipalityName == (string)MunipacilityDropDown.SelectedValue.ToString()).FirstOrDefault();
                    tempContext.Settlements.Add(settlementClass1);
                }
                else
                {
                    settlementClass1 = settlementDB;
                }
                //tempContext.Settlements.Add(settlementClass1);
                tempContext.SaveChanges();
                SettlementTextBox.Text = "";
            }
            else
            {
                Label3.Visible = true;
                Label3.Text = "Insert a valid Settlement!";
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void Backwards_Click(object sender, EventArgs e)
        {

        }

        protected void RegionListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selecteditemtext = RegionListBox2.SelectedItem.ToString();
            Model tempContext = new Model();
            //MunicipalityClass municipality = new MunicipalityClass();

            List<string> abc = new List<string>();
            //Here i should get the text from the dropdown

            MunipacilityDropDown.Items.Clear();
            foreach (var item in tempContext.Municipalities)
            {
                if (item.RegionClass.RegionName == selecteditemtext)
                {
                    abc.Add(item.MunicipalityName);
                    MunipacilityDropDown.Items.Add(item.MunicipalityName);
                }
            }
        }
    }
}