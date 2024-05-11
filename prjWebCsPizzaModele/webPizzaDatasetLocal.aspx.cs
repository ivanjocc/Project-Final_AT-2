using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsPizzaModele
{
    public partial class webPizzaDatasetLocal : System.Web.UI.Page
    {

        static DataSet setPizza;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (IsPostBack == false)
            {
                txtAdresse.Visible = false;
                lblAdresse.Visible = false;
                panPrix.Visible = false;
                panCommande.Visible = false;

                // vous devez creer cette fonction
                setPizza = ConnecterBD_RemplirDataset();

                //setPizza = CreerEtRemplirDataset();

                RemplirPizza(setPizza.Tables["Pizzas"]);
                RemplirTailles(setPizza.Tables["Tailles"]);
                RemplirGarnitures(setPizza.Tables["Garnitures"]);
                RemplirCroutes(setPizza.Tables["Croutes"]);

            }
            else
            {
                if (cboPizzas.SelectedIndex != 0)
                {
                    CalculerPrix();
                    panPrix.Visible = true;
                    panCommande.Visible = false;
                }
                else
                {
                    panPrix.Visible = false;
                }

            }

        }

        private DataSet ConnecterBD_RemplirDataset()
        {
            // create dataset
            DataSet dataSet = new DataSet();

            // route of database
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ivanj\\Desktop\\AAA\\teccart\\session-4\\at\\final-v4\\prjWebCsPizzaModele\\prjWebCsPizzaModele\\App_Data\\PizzaDB.mdf;Integrated Security=True";

            // connection
            SqlConnection connection = new SqlConnection(connectionString);

            // adapter and fill dataset
            SqlDataAdapter pizzaAdapter = new SqlDataAdapter("SELECT * FROM Pizzas", connection);
            pizzaAdapter.Fill(dataSet, "Pizzas");

            SqlDataAdapter taillesAdapter = new SqlDataAdapter("SELECT * FROM Tailles", connection);
            taillesAdapter.Fill(dataSet, "Tailles");

            SqlDataAdapter croutesAdapter = new SqlDataAdapter("SELECT * FROM Croutes", connection);
            croutesAdapter.Fill(dataSet, "Croutes");

            SqlDataAdapter garnituresAdapter = new SqlDataAdapter("SELECT * FROM Garnitures", connection);
            garnituresAdapter.Fill(dataSet, "Garnitures");

            SqlDataAdapter clientsAdapter = new SqlDataAdapter("SELECT * FROM Clients", connection);
            clientsAdapter.Fill(dataSet, "Clients");

            // close connection
            connection.Close();

            return dataSet;
        }

        private void CalculerPrix()
        {
            decimal prixBase = 0, liv = 0, sousTot = 0, taxe = 0, total = 0, Garniture = 0;
            decimal croute = 0;
            prixBase = Convert.ToDecimal(cboPizzas.SelectedItem.Value);
            prixBase = prixBase * Convert.ToDecimal(lstTailles.SelectedItem.Value);
            Int32 posT = lstRadCroutes.SelectedItem.Value.IndexOf("-");
            croute = Convert.ToDecimal(lstRadCroutes.SelectedItem.Value.Substring(posT + 1));
            prixBase = prixBase + croute;
            liv = (chkLivraison.Checked) ? 5 : 0;
            foreach (ListItem elm in lstChkGarnitures.Items)
            {
                if (elm.Selected)
                {
                    Garniture = Garniture + Convert.ToDecimal(elm.Value);
                }
            }
            sousTot = prixBase + liv + Garniture;
            taxe = (sousTot * 14) / 100;
            total = sousTot + taxe; litPrix.Text = "<strong>Prix de base   " + prixBase + " $<br /></strong>";
            litPrix.Text += "<strong>Livraison  " + liv + " $<br /></strong>";
            litPrix.Text += "<strong>Garnitures  " + Garniture + " $<br /></strong>"; litPrix.Text += "<strong><hr></strong>";
            litPrix.Text += "<strong>SousTotal  " + sousTot + " $<br /></strong>";
            litPrix.Text += "<strong>Taxe (14%)  " + taxe + " $<br /></strong>";
            litPrix.Text += "<strong><hr></strong>";
            litPrix.Text += "<strong>Total  " + total + " $</strong>";
        }

        private void RemplirCroutes(DataTable tabCroute)
        {
            // version databinding
            //lstRadCroutes.DataSource = tabCroute;
            //lstRadCroutes.DataTextField = "Nom";
            //lstRadCroutes.DataValueField = "Prix";
            //lstRadCroutes.DataBind();


            //version foreach

            lstRadCroutes.Items.Clear();

            foreach (DataRow row in tabCroute.Rows)
            {
                string nom = row["Nom"].ToString();
                string prix = row["Prix"].ToString();
                ListItem item = new ListItem(nom, prix);
                lstRadCroutes.Items.Add(item);
            }

            lstRadCroutes.SelectedIndex = 0;


            //version linq

            //var items = from DataRow row in tabCroute.Rows
            //            select new
            //            {
            //                Nom = row["Nom"].ToString(),
            //                Prix = row["Prix"].ToString()
            //            };

            //lstRadCroutes.DataSource = items.ToList();
            //lstRadCroutes.DataTextField = "Nom";
            //lstRadCroutes.DataValueField = "Prix";
            //lstRadCroutes.DataBind();

            //lstRadCroutes.SelectedIndex = 0;
        }

        private void RemplirGarnitures(DataTable tabGarni)
        {
            foreach (DataRow myrow in tabGarni.Rows)
            {
                ListItem elm = new ListItem();
                elm.Text = myrow["Nom"].ToString();
                elm.Value = myrow["Prix"].ToString();
                lstChkGarnitures.Items.Add(elm);
            }

            // Projet 2, Remplir la liste des garnitures
            //Faites les versions
            // 1) la methode databinding avec datatable
            // 2) la methode databinding avec LINQ sur dataset
        }

        private void RemplirTailles(DataTable tabTailles)
        {
            foreach (DataRow myrow in tabTailles.Rows)
            {
                ListItem elm = new ListItem();
                elm.Text = myrow["Nom"].ToString();
                elm.Value = myrow["Ratio"].ToString();
                lstTailles.Items.Add(elm);
            }
            lstTailles.SelectedIndex = 0;
            // Projet 2, Remplir la liste des tailles
            //Faites les versions
            // 1) la methode databinding avec datatable
            // 2) la methode databinding avec LINQ sur dataset
        }

        private void RemplirPizza(DataTable tabPizzas)
        {
            cboPizzas.Items.Add(new ListItem("Faites votre choix", "0"));
            // Version boucle
            foreach (DataRow myrow in tabPizzas.Rows)
            {
                ListItem elm = new ListItem();
                elm.Text = myrow["Nom"].ToString();
                elm.Value = myrow["Prix"].ToString();
                cboPizzas.Items.Add(elm);
            }

            // Projet 2, Remplir la liste des pizzas
            //Faites les versions
            // 1) la methode databinding avec datatable
            // 2) la methode databinding avec LINQ sur dataset
            cboPizzas.SelectedIndex = 0;


        }

        //hide from this part
        private DataSet CreerEtRemplirDataset()
        {
            DataSet mySet = new DataSet();

            // Creation Table Clients et ajouter clients
            DataTable myTb = new DataTable("Clients");
            DataColumn myCol = new DataColumn("RefClient", typeof(Int32));
            myCol.AutoIncrement = true;
            myCol.AutoIncrementSeed = 1;
            myCol.AutoIncrementStep = 1;
            myTb.Columns.Add(myCol);
            myCol = new DataColumn("Nom", typeof(String));
            myTb.Columns.Add(myCol);
            myCol = new DataColumn("Telephone", typeof(String));
            myTb.Columns.Add(myCol);
            myCol = new DataColumn("Adresse", typeof(String));
            myTb.Columns.Add(myCol);
            mySet.Tables.Add(myTb);

            // Creation Table Pizzas
            myTb = new DataTable("Pizzas");
            myCol = new DataColumn("Nom", typeof(String));
            myTb.Columns.Add(myCol);
            myCol = new DataColumn("Prix", typeof(Decimal));
            myTb.Columns.Add(myCol);
            myCol = new DataColumn("Description", typeof(String));
            myTb.Columns.Add(myCol);
            mySet.Tables.Add(myTb);

            // Creation Table Tailles
            myTb = new DataTable("Tailles");
            myCol = new DataColumn("Nom", typeof(String));
            myTb.Columns.Add(myCol);
            myCol = new DataColumn("Ratio", typeof(Single));
            myTb.Columns.Add(myCol);
            mySet.Tables.Add(myTb);

            // Creation Table Garnitures
            myTb = new DataTable("Garnitures");
            myCol = new DataColumn("Nom", typeof(String));
            myTb.Columns.Add(myCol);
            myCol = new DataColumn("Prix", typeof(Decimal));
            myTb.Columns.Add(myCol);
            mySet.Tables.Add(myTb);

            // Creation Table Croutes
            myTb = new DataTable("Croutes");
            myCol = new DataColumn("Nom", typeof(String));
            myTb.Columns.Add(myCol);
            myCol = new DataColumn("Prix", typeof(Decimal));
            myTb.Columns.Add(myCol);
            mySet.Tables.Add(myTb);

            // Remplir les tables
            // Ajouter les clients
            DataRow myrow = mySet.Tables["Clients"].NewRow();
            myrow["Nom"] = "Bill Gates";
            myrow["Telephone"] = "321";
            myrow["Adresse"] = "321 prueba, Montreal";
            mySet.Tables["Clients"].Rows.Add(myrow);

            myrow = mySet.Tables["Clients"].NewRow();
            myrow["Nom"] = "Sophie Cote";
            myrow["Telephone"] = "123";
            myrow["Adresse"] = "123 test, Montreal";
            mySet.Tables["Clients"].Rows.Add(myrow);

            // Ajouter les pizzas
            myrow = mySet.Tables["Pizzas"].NewRow();
            myrow["Nom"] = "L'Italienne";
            myrow["Prix"] = 12;
            mySet.Tables["Pizzas"].Rows.Add(myrow);

            myrow = mySet.Tables["Pizzas"].NewRow();
            myrow["Nom"] = "La Hawaienne";
            myrow["Prix"] = 10;
            mySet.Tables["Pizzas"].Rows.Add(myrow);

            myrow = mySet.Tables["Pizzas"].NewRow();
            myrow["Nom"] = "La Mexicaine";
            myrow["Prix"] = 11;
            mySet.Tables["Pizzas"].Rows.Add(myrow);

            myrow = mySet.Tables["Pizzas"].NewRow();
            myrow["Nom"] = "La Quebecoise";
            myrow["Prix"] = 13;
            mySet.Tables["Pizzas"].Rows.Add(myrow);

            myrow = mySet.Tables["Pizzas"].NewRow();
            myrow["Nom"] = "La Toute Garnie";
            myrow["Prix"] = 14;
            mySet.Tables["Pizzas"].Rows.Add(myrow);

            // Ajouter les tailles
            myrow = mySet.Tables["Tailles"].NewRow();
            myrow["Nom"] = "Petite";
            myrow["Ratio"] = 1;
            mySet.Tables["Tailles"].Rows.Add(myrow);

            myrow = mySet.Tables["Tailles"].NewRow();
            myrow["Nom"] = "Moyenne";
            myrow["Ratio"] = 1.5;
            mySet.Tables["Tailles"].Rows.Add(myrow);

            myrow = mySet.Tables["Tailles"].NewRow();
            myrow["Nom"] = "Grande";
            myrow["Ratio"] = 2;
            mySet.Tables["Tailles"].Rows.Add(myrow);

            // Ajouter les croutes
            myrow = mySet.Tables["Croutes"].NewRow();
            myrow["Nom"] = "Mince";
            myrow["Prix"] = 0;
            mySet.Tables["Croutes"].Rows.Add(myrow);

            myrow = mySet.Tables["Croutes"].NewRow();
            myrow["Nom"] = "Normale";
            myrow["Prix"] = 1;
            mySet.Tables["Croutes"].Rows.Add(myrow);

            myrow = mySet.Tables["Croutes"].NewRow();
            myrow["Nom"] = "Epaisse";
            myrow["Prix"] = 2;
            mySet.Tables["Croutes"].Rows.Add(myrow);

            // Ajouter les garnitures
            myrow = mySet.Tables["Garnitures"].NewRow();
            myrow["Nom"] = "Bacon Jambon (2$)";
            myrow["Prix"] = 2;
            mySet.Tables["Garnitures"].Rows.Add(myrow);

            myrow = mySet.Tables["Garnitures"].NewRow();
            myrow["Nom"] = "Extra Fromage (2.5$)";
            myrow["Prix"] = 2.5;
            mySet.Tables["Garnitures"].Rows.Add(myrow);

            myrow = mySet.Tables["Garnitures"].NewRow();
            myrow["Nom"] = "Peperoni Halal (2.75$)";
            myrow["Prix"] = 2.75;
            mySet.Tables["Garnitures"].Rows.Add(myrow);

            myrow = mySet.Tables["Garnitures"].NewRow();
            myrow["Nom"] = "Champignons (3$)";
            myrow["Prix"] = 3;
            mySet.Tables["Garnitures"].Rows.Add(myrow);

            return mySet;
        }
        //hide until this part

        protected void btnCommander_Click(object sender, EventArgs e)
        {
            panCommande.Visible = true;
            string info;
            info = "M. ou Mme " + txtNom.Text + ", <br />";
            info += "Votre commande d'une " + lstTailles.SelectedItem.Text +
            " pizza, " + cboPizzas.SelectedItem.Text + " sur une croute " +
            lstRadCroutes.SelectedItem.Text + ", <br />";
            if (chkLivraison.Checked)
            {
                info += "A etre livrée au " + txtAdresse.Text +
                "<br />Telephone " + txtTelephone.Text + "<br />";
            }
            else
            {
                info += "A etre ramassée au comptoir <br />";
            }
            info += "Garnitures<ul>";
            foreach (ListItem elm in lstChkGarnitures.Items)
            {
                if (elm.Selected)
                {
                    info += "<li>" + elm.Text + "</li>";
                }
            }
            if (lstChkGarnitures.SelectedIndex == -1)
            {
                info += "<li>aucune</li>";
            }
            info += "</ul>A été transmise avec succés";
            litInfos.Text = info;
        }

        protected void btnTrouver_Click(object sender, EventArgs e)
        {
            string telephone = txtTelephone.Text;

            //do with foreach (method)

            foreach (DataRow row in setPizza.Tables["Clients"].Rows)
            {
                if (row["Telephone"].ToString() == telephone)
                {
                    txtNom.Text = row["Nom"].ToString();
                    txtAdresse.Text = row["Adresse"].ToString();

                    return;
                }
            }

            //do with select (method)

            //DataRow[] foundRows = setPizza.Tables["Clients"].Select("Telephone = '" + telephone + "'");

            //if (foundRows.Length > 0)
            //{
            //    txtNom.Text = foundRows[0]["Nom"].ToString();
            //    txtAdresse.Text = foundRows[0]["Adresse"].ToString();
            //}


            //do with linq

            //var query = from DataRow client in setPizza.Tables["Clients"].Rows
            //            where client["Telephone"].ToString() == telephone
            //            select client;

            ////return first client
            //DataRow foundClient = query.FirstOrDefault();

            //if (foundClient != null)
            //{
            //    txtNom.Text = foundClient["Nom"].ToString();
            //}
            //else
            //{
            //    txtNom.Text = "client not found";
            //}


            //do with find

            //int clientId = int.Parse(txtTelephone.Text);

            //DataRow foundClient = setPizza.Tables["Clients"].Rows.Find(clientId);

            //if (foundClient != null)
            //{
            //    txtNom.Text = foundClient["Nom"].ToString();
            //}
            //else
            //{
            //    txtNom.Text = "client not found";
            //}
        }

        protected void chkLivraison_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLivraison.Checked)
            {
                txtAdresse.Visible = true;
                lblAdresse.Visible = true;
                txtAdresse.Focus();
            }
            else
            {
                txtAdresse.Visible = false;
                lblAdresse.Visible = false;
            }
            
        }
    }
}