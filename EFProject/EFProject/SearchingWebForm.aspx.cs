using EFProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EFProject
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(SearchDropDown.SelectedValue == "Name")
            {
                RegionListBox.Items.Clear();
                MunicipalityListBox.Items.Clear();
                SettlementsListBox.Items.Clear();
                string DropDownResult = DropDownList.SelectedValue;
                Model tempContext = new Model();

                if (DropDownResult == "Region")
                {
                    //RegionClass regionClass = new RegionClass();
                    using (var ctx = new Model())
                    {
                        ctx.Configuration.UseDatabaseNullSemantics = true;
                        var thing = ctx.Regions.Where
                            (s => s.RegionName == SearchTextBox.Text).FirstOrDefault<RegionClass>();
                        
                        var RegionlinqQuery = from regions
                                              in ctx.Regions
                                              where regions.RegionName == SearchTextBox.Text
                                              select regions;

                        string sqlQuery = RegionlinqQuery.ToString();
                        RegionLabel.Text = sqlQuery;

                        if (thing == null)
                        {
                            Label1.Text = "this name cannot be found!!";
                        }
                        else
                        {
                            RegionListBox.Items.Add(thing.RegionName);

                            var thing2 = ctx.Municipalities.Where
                                (s => s.RegionClass.RegionName == SearchTextBox.Text).ToList<MunicipalityClass>();
                            foreach (var item in thing2)
                            {
                                MunicipalityListBox.Items.Add(item.MunicipalityName);
                            }

                            var MunicipalityLinqQuery = from Municipalities
                                                        in ctx.Municipalities
                                                        where Municipalities.RegionClass.RegionName 
                                                        == SearchTextBox.Text
                                                        select Municipalities;

                            string MunisqlQuery = MunicipalityLinqQuery.ToString();
                            MunicipalityLabel.Text = MunisqlQuery;

                            var thing9 = ctx.Settlements.Where
                                (s => s.MunicipalityClass.RegionClass.RegionName == SearchTextBox.Text).ToList<SettlementClass>();

                            var SettlementLinqQuery = from settlements
                                                      in ctx.Settlements
                                                      where settlements.MunicipalityClass.RegionClass.RegionName
                                                      == SearchTextBox.Text
                                                      select settlements;
                            string SettSqlQuery = SettlementLinqQuery.ToString();
                            SettlementLabel.Text = SettSqlQuery;

                            foreach (var item in thing9)
                            {
                                SettlementsListBox.Items.Add(item.SettlementName);
                            }
                        }
                    }
                }

                if (DropDownResult == "Municipality")
                {
                    using (var ctx = new Model())
                    {
                        ctx.Configuration.UseDatabaseNullSemantics = true;
                        var linqQuery = from municipalities
                                        in ctx.Municipalities
                                        where municipalities.MunicipalityName == SearchTextBox.Text
                                        select municipalities;

                        string sqlQuery = linqQuery.ToString();
                        MunicipalityLabel.Text = sqlQuery;

                        var thing3 = ctx.Municipalities.Where(s => s.MunicipalityName == SearchTextBox.Text).FirstOrDefault<MunicipalityClass>();

                        MunicipalityListBox.Items.Add(thing3.MunicipalityName);

                        var linqQuery2 = from regions
                                        in ctx.Municipalities
                                        where regions.MunicipalityName == SearchTextBox.Text
                                        select regions;

                        string sqlQuery2 = linqQuery2.ToString();
                        RegionLabel.Text = sqlQuery2;

                        RegionListBox.Items.Add(thing3.RegionClass.RegionName);

                        var thing4 = ctx.Settlements.Where(s => s.MunicipalityClass.MunicipalityName == SearchTextBox.Text).ToList<SettlementClass>();
                        foreach (var item in thing4)
                        {
                            SettlementsListBox.Items.Add(item.SettlementName);
                        }
                        var linqQuery3 = from settlements
                                        in ctx.Settlements
                                         where settlements.MunicipalityClass.MunicipalityName == SearchTextBox.Text
                                         select settlements;

                        string sqlQuery3 = linqQuery3.ToString();
                        SettlementLabel.Text = sqlQuery3;
                    }
                }
                //continue from here
                if (DropDownResult == "Settlement")
                {
                    SettlementClass settlement = new SettlementClass();
                    using (var ctx = new Model())
                    {
                        ctx.Configuration.UseDatabaseNullSemantics = true;
                        MunicipalityClass thing9 = new MunicipalityClass();
                        //var thing5.Municipalities = new MunicipalityClass();
                        var thing5 = ctx.Settlements.Where(s => s.SettlementName 
                                                                == SearchTextBox.Text).FirstOrDefault();
                        var linqQuery3 = from settlements
                                        in ctx.Settlements
                                         where settlements.SettlementName == SearchTextBox.Text
                                         select settlements;

                        string sqlQuery3 = linqQuery3.ToString();
                        SettlementLabel.Text = sqlQuery3;


                        var thing6 = ctx.Municipalities.Where(s => s.Id == thing5.Municipality_Id).FirstOrDefault<MunicipalityClass>();

                        var linqQuery1 = from settlements
                                        in ctx.Settlements
                                         where settlements.Municipality_Id == thing9.Id
                                         select settlements.MunicipalityClass.MunicipalityName;

                        string sqlQuery1 = linqQuery1.ToString();
                        MunicipalityLabel.Text = sqlQuery1;


                        var linqQuery2 = from municipalities
                                         in ctx.Municipalities
                                         where municipalities.RegionClass.RegionName == thing6.RegionClass.RegionName
                                         select municipalities.RegionClass.RegionName;

                        string sqlQuery2 = linqQuery2.ToString();
                        RegionLabel.Text = sqlQuery2;

                        var linqQuery4 = from regions
                                         in ctx.Regions
                                         where regions.RegionName == thing6.RegionClass.RegionName
                                         select regions;

                        string sqlQuery4 = linqQuery4.ToString();
                        RegionLabel.Text = sqlQuery4;

                        RegionListBox.Items.Add(thing6.RegionClass.RegionName);
                        MunicipalityListBox.Items.Add(thing6.MunicipalityName);
                        SettlementsListBox.Items.Add(thing5.SettlementName);
                    }
                }
            }
            if(SearchDropDown.SelectedValue == "StartsWith")
            {
                RegionListBox.Items.Clear();
                MunicipalityListBox.Items.Clear();
                SettlementsListBox.Items.Clear();
                string DropDownResult = DropDownList.SelectedValue;
                Model tempContext = new Model();

                if (DropDownResult == "Region")
                {
                    //RegionClass regionClass = new RegionClass();
                    using (var ctx = new Model())
                    {
                        ctx.Configuration.UseDatabaseNullSemantics = true;
                        var thing = ctx.Regions.Where(s => s.RegionName.StartsWith(SearchTextBox.Text)).FirstOrDefault<RegionClass>();
                        if (thing == null)
                        {
                            Label1.Text = "this name cannot be found!!";
                        }
                        else
                        {
                            RegionListBox.Items.Clear();
                            MunicipalityListBox.Items.Clear();
                            SettlementsListBox.Items.Clear();
                            RegionListBox.Items.Add(thing.RegionName);
                            //////////////////////////////////////////
                            //the sql code of this stuff
                            var linqQuery1 = from regions
                                            in ctx.Regions
                                             where regions.RegionName.StartsWith(SearchTextBox.Text)
                                             select regions;

                            string sqlQuery1 = linqQuery1.ToString();
                            RegionLabel.Text = sqlQuery1;


                            var MunicipalityLinqQuery = from Municipalities
                                                        in ctx.Municipalities
                                                        where Municipalities.RegionClass.RegionName.
                                                        StartsWith(SearchTextBox.Text)
                                                        select Municipalities;

                            string MunisqlQuery = MunicipalityLinqQuery.ToString();
                            MunicipalityLabel.Text = MunisqlQuery;

                            var SettlementLinqQuery = from settlements
                              in ctx.Settlements
                                                      where settlements.MunicipalityClass.RegionClass.RegionName.
                                                      StartsWith(SearchTextBox.Text)
                                                      select settlements;
                            string SettSqlQuery = SettlementLinqQuery.ToString();
                            SettlementLabel.Text = SettSqlQuery;
                            /////////////////////////////////////////////

                            var thing2 = ctx.Municipalities.Where(s => s.RegionClass.RegionName.StartsWith(SearchTextBox.Text)).ToList<MunicipalityClass>();

                            foreach (var item in thing2)
                            {
                                MunicipalityListBox.Items.Add(item.MunicipalityName);
                            }

                            var thing9 = ctx.Settlements.Where(s => s.MunicipalityClass.RegionClass.RegionName.StartsWith(SearchTextBox.Text)).ToList<SettlementClass>();

                            foreach (var item in thing9)
                            {
                                SettlementsListBox.Items.Add(item.SettlementName);
                            }
                        }
                    }
                }

                if (DropDownResult == "Municipality")
                {
                    using (var ctx = new Model())
                    {
                        ctx.Configuration.UseDatabaseNullSemantics = true;
                        var thing3 = ctx.Municipalities.Where(s => s.MunicipalityName.StartsWith(SearchTextBox.Text)).FirstOrDefault<MunicipalityClass>();

                        
                        if (thing3 != null)
                        {
                            RegionListBox.Items.Clear();
                            MunicipalityListBox.Items.Clear();
                            SettlementsListBox.Items.Clear();
                            MunicipalityListBox.Items.Add(thing3.MunicipalityName);
                            RegionListBox.Items.Add(thing3.RegionClass.RegionName);
                            var thing4 = ctx.Settlements.Where
                                (s => s.MunicipalityClass.MunicipalityName.StartsWith(SearchTextBox.Text)).ToList<SettlementClass>();
                            foreach (var item in thing4)
                            {
                                SettlementsListBox.Items.Add(item.SettlementName);
                            }
                            ///////////////////////////////////////
                            var linqQuery = from municipalities
                                        in ctx.Municipalities
                                            where municipalities.MunicipalityName.StartsWith(SearchTextBox.Text)
                                            select municipalities;

                            string sqlQuery = linqQuery.ToString();
                            MunicipalityLabel.Text = sqlQuery;

                            var linqQuery2 = from regions
                                           in ctx.Municipalities
                                             where regions.MunicipalityName.StartsWith(SearchTextBox.Text)
                                             select regions;

                            string sqlQuery2 = linqQuery2.ToString();
                            RegionLabel.Text = sqlQuery2;

                            var linqQuery3 = from settlements
                                            in ctx.Settlements
                                             where settlements.MunicipalityClass.MunicipalityName.
                                             StartsWith(SearchTextBox.Text)
                                             select settlements;

                            string sqlQuery3 = linqQuery3.ToString();
                            SettlementLabel.Text = sqlQuery3;
                            //////////////////////////////////////////////
                        }
                        else
                        {
                            Label1.Text = "this name cannot be found!!";
                        }
                    }
                }

                if (DropDownResult == "Settlement")
                {
                    SettlementClass settlement = new SettlementClass();
                    MunicipalityClass thing9 = new MunicipalityClass();
                    using (var ctx = new Model())
                    {
                        ctx.Configuration.UseDatabaseNullSemantics = true;
                        //SettlementClass thing5 = new SettlementClass();
                        //var thing5.Municipalities = new MunicipalityClass();
                        var thing5 = ctx.Settlements.Where
                            (s => s.SettlementName.StartsWith(SearchTextBox.Text)).ToList();
                        var thing10 = ctx.Settlements.Where
                            (s => s.SettlementName.StartsWith(SearchTextBox.Text)).FirstOrDefault();
                        var thing6 = ctx.Municipalities.Where(s => s.Id == thing10.Municipality_Id).
                                                            FirstOrDefault<MunicipalityClass>();

                        var linqQuery3 = from settlements
                                        in ctx.Settlements
                                         where settlements.SettlementName.StartsWith(SearchTextBox.Text)
                                         select settlements;

                        string sqlQuery3 = linqQuery3.ToString();
                        SettlementLabel.Text = sqlQuery3;

                        var linqQuery1 = from settlements
                                        in ctx.Settlements
                                         where settlements.Municipality_Id == thing9.Id
                                         select settlements.MunicipalityClass.MunicipalityName;


                        string sqlQuery1 = linqQuery1.ToString();
                        MunicipalityLabel.Text = sqlQuery1;

                        var linqQuery4 = from regions
                                        in ctx.Regions
                                         where regions.RegionName == thing6.RegionClass.RegionName
                                         select regions;

                        string sqlQuery4 = linqQuery4.ToString();
                        RegionLabel.Text = sqlQuery4;

                        if (thing5 != null)
                        {
                            RegionListBox.Items.Clear();
                            MunicipalityListBox.Items.Clear();
                            SettlementsListBox.Items.Clear();
                            foreach (var item in thing5)
                            {
                                var thing11 = ctx.Municipalities.Where
                                    (s => s.Id == item.Municipality_Id).ToList<MunicipalityClass>();


                                foreach(var item2 in thing11)
                                {
                                    RegionListBox.Items.Add(item2.RegionClass.RegionName);

                                    MunicipalityListBox.Items.Add(item.MunicipalityClass.MunicipalityName);
                                    SettlementsListBox.Items.Add(item.SettlementName);
                                }
                            }
                            
                        }
                        else
                        {
                            Label1.Text = "this name cannot be found!!";
                        }

                    }
                }
            }
            if (SearchDropDown.SelectedValue == "Contains")
            {
                RegionListBox.Items.Clear();
                MunicipalityListBox.Items.Clear();
                SettlementsListBox.Items.Clear();
                string DropDownResult = DropDownList.SelectedValue;
                Model tempContext = new Model();
                if (DropDownResult == "Region")
                {
                    //RegionClass regionClass = new RegionClass();
                    using (var ctx = new Model())
                    {
                        ctx.Configuration.UseDatabaseNullSemantics = true;
                        var thing = ctx.Regions.Where(s => s.RegionName.Contains(SearchTextBox.Text)).FirstOrDefault<RegionClass>();
                        if (thing == null)
                        {
                            Label1.Text = "this name cannot be found!!";
                        }
                        else
                        {
                            RegionListBox.Items.Clear();
                            MunicipalityListBox.Items.Clear();
                            SettlementsListBox.Items.Clear();
                            RegionListBox.Items.Add(thing.RegionName);
                            var thing2 = ctx.Municipalities.Where(s => s.RegionClass.RegionName.Contains(SearchTextBox.Text)).ToList<MunicipalityClass>();
                            /////////////////////////////////////////////////////
                            var linqQuery1 = from regions
                                        in ctx.Regions
                                             where regions.RegionName.Contains(SearchTextBox.Text)
                                             select regions;

                            string sqlQuery1 = linqQuery1.ToString();
                            RegionLabel.Text = sqlQuery1;


                            var MunicipalityLinqQuery = from Municipalities
                                                        in ctx.Municipalities
                                                        where Municipalities.RegionClass.RegionName.
                                                        Contains(SearchTextBox.Text)
                                                        select Municipalities;

                            string MunisqlQuery = MunicipalityLinqQuery.ToString();
                            MunicipalityLabel.Text = MunisqlQuery;

                            var SettlementLinqQuery = from settlements
                              in ctx.Settlements
                                                      where settlements.MunicipalityClass.RegionClass.RegionName.
                                                      Contains(SearchTextBox.Text)
                                                      select settlements;
                            string SettSqlQuery = SettlementLinqQuery.ToString();
                            SettlementLabel.Text = SettSqlQuery;
                            /////////////////////////////////////////////////////
                            foreach (var item in thing2)
                            {
                                MunicipalityListBox.Items.Add(item.MunicipalityName);
                            }
                            var thing9 = ctx.Settlements.Where(s => s.MunicipalityClass.RegionClass.RegionName.Contains(SearchTextBox.Text)).ToList<SettlementClass>();
                            foreach (var item in thing9)
                            {
                                SettlementsListBox.Items.Add(item.SettlementName);
                            }
                        }
                    }
                }
                if (DropDownResult == "Municipality")
                {
                    using (var ctx = new Model())
                    {
                        ctx.Configuration.UseDatabaseNullSemantics = true;
                        var thing3 = ctx.Municipalities.Where
                            (s => s.MunicipalityName.Contains(SearchTextBox.Text)).FirstOrDefault<MunicipalityClass>();
                        ctx.Database.Log = Console.Write;
                        if (thing3 != null)
                        {
                            RegionListBox.Items.Clear();
                            MunicipalityListBox.Items.Clear();
                            SettlementsListBox.Items.Clear();
                            MunicipalityListBox.Items.Add(thing3.MunicipalityName);
                            RegionListBox.Items.Add(thing3.RegionClass.RegionName);
                            var thing4 = ctx.Settlements.Where
                                (s => s.MunicipalityClass.MunicipalityName.Contains(SearchTextBox.Text)).ToList<SettlementClass>();

                            /////////////////////////////////////////////////
                            var linqQuery = from municipalities
                                        in ctx.Municipalities
                                        where municipalities.MunicipalityName.Contains(SearchTextBox.Text)
                                        select municipalities;

                            string sqlQuery = linqQuery.ToString();
                            MunicipalityLabel.Text = sqlQuery;

                            var linqQuery2 = from regions
                                           in ctx.Municipalities
                                             where regions.MunicipalityName.Contains(SearchTextBox.Text)
                                             select regions;

                            string sqlQuery2 = linqQuery2.ToString();
                            RegionLabel.Text = sqlQuery2;

                            var linqQuery3 = from settlements
                                             in ctx.Settlements
                                             where settlements.MunicipalityClass.MunicipalityName.
                                             Contains(SearchTextBox.Text)
                                             select settlements;

                            string sqlQuery3 = linqQuery3.ToString();
                            SettlementLabel.Text = sqlQuery3;
                            ////////////////////////////////////////////
                            foreach (var item in thing4)
                            {
                                SettlementsListBox.Items.Add(item.SettlementName);
                            }
                        }
                        else
                        {
                            Label1.Text = "this name cannot be found!!";
                        }
                    }
                }
                if(DropDownResult == "Settlement")
                {
                    SettlementClass settlement = new SettlementClass();
                    using (var ctx = new Model())
                    {
                        //SettlementClass thing5 = new SettlementClass();
                        //var thing5.Municipalities = new MunicipalityClass();
                        var thing5 = ctx.Settlements.Where
                            (s => s.SettlementName.Contains(SearchTextBox.Text)).ToList();
                        var thing13 = ctx.Settlements.Where
                            (s => s.SettlementName.Contains(SearchTextBox.Text)).FirstOrDefault();
                        var thing12 = ctx.Municipalities.Where(s => s.Id == thing13.Municipality_Id).
                                                           FirstOrDefault<MunicipalityClass>();
                        ctx.Configuration.UseDatabaseNullSemantics = true;
                        if (thing5 != null)
                        {
                            RegionListBox.Items.Clear();
                            MunicipalityListBox.Items.Clear();
                            SettlementsListBox.Items.Clear();
                            ////////////////////////////////////////////
                            var linqQuery3 = from settlements
                                             in ctx.Settlements
                                             where settlements.SettlementName.Contains(SearchTextBox.Text)
                                             select settlements;

                            string sqlQuery3 = linqQuery3.ToString();
                            SettlementLabel.Text = sqlQuery3;
                            MunicipalityClass thing9 = new MunicipalityClass();
                            var linqQuery1 = from settlements
                                             in ctx.Settlements
                                             where settlements.Municipality_Id == thing9.Id
                                             select settlements.MunicipalityClass.MunicipalityName;

                            string sqlQuery1 = linqQuery1.ToString();
                            MunicipalityLabel.Text = sqlQuery1;

                            var linqQuery4 = from regions
                                        in ctx.Regions
                                             where regions.RegionName == thing12.RegionClass.RegionName
                                             select regions;

                            string sqlQuery4 = linqQuery4.ToString();
                            RegionLabel.Text = sqlQuery4;
                            //////////////////////////////////////////////////
                            foreach (var item in thing5)
                            {
                                var thing6 = ctx.Municipalities.Where
                                    (s => s.Id == item.Municipality_Id).ToList<MunicipalityClass>();
                                foreach (var item2 in thing6)
                                {
                                    RegionListBox.Items.Add(item2.RegionClass.RegionName);
                                    MunicipalityListBox.Items.Add(item.MunicipalityClass.MunicipalityName);
                                    SettlementsListBox.Items.Add(item.SettlementName);
                                }
                            }
                        }
                        else
                        {
                            Label1.Text = "this name cannot be found!!";
                        }

                    }
                }
            }

        }
    }
}