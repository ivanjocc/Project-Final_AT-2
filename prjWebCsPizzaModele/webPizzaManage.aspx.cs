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
    public partial class webPizzaManage : System.Web.UI.Page
    {
        // declaration des variables globales
        static DataSet mySet;
        
        static DataTable tabPizza;
        static int indiceCourant;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                //mySet = CreerEtRemplirDataset();

                mySet = RemplirDataset();

                tabPizza = mySet.Tables["Pizzas"];

                indiceCourant = 0;
                Afficher();

                MontrerBoutons(true, false);
            }
        }

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
            myrow["Telephone"] = "123";
            myrow["Adresse"] = "1124 St-Laurent, Montreal";
            mySet.Tables["Clients"].Rows.Add(myrow);

            myrow = mySet.Tables["Clients"].NewRow();
            myrow["Nom"] = "Sophie Cote";
            myrow["Telephone"] = "321";
            myrow["Adresse"] = "298 Beaubien, Montreal";
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

        private void Afficher()
        {
            txtPizza.Text = tabPizza.Rows[indiceCourant]["Nom"].ToString();
            txtPrix.Text = tabPizza.Rows[indiceCourant]["Prix"].ToString();
            txtDescription.Text = tabPizza.Rows[indiceCourant]["Description"].ToString();
            lblInfo.Text = "Pizza " + (indiceCourant + 1) + " sur un total de " + tabPizza.Rows.Count;
        }

        private DataSet RemplirDataset()
        {
            DataSet unSet = new DataSet();

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ivanj\\Desktop\\AAA\\teccart\\session-4\\at\\final-v4\\prjWebCsPizzaModele\\prjWebCsPizzaModele\\App_Data\\PizzaDB.mdf;Integrated Security=True";
            
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlDataAdapter pizzaAdapter = new SqlDataAdapter("SELECT * FROM Pizzas", connection);
            pizzaAdapter.Fill(unSet, "Pizzas");

            SqlDataAdapter clientsAdapter = new SqlDataAdapter("SELECT * FROM Clients", connection);
            clientsAdapter.Fill(unSet, "Clients");

            SqlDataAdapter taillesAdapter = new SqlDataAdapter("SELECT * FROM Tailles", connection);
            taillesAdapter.Fill(unSet, "Tailles");

            SqlDataAdapter garnituresAdapter = new SqlDataAdapter("SELECT * FROM Garnitures", connection);
            garnituresAdapter.Fill(unSet, "Garnitures");

            SqlDataAdapter croutesAdapter = new SqlDataAdapter("SELECT * FROM Croutes", connection);
            croutesAdapter.Fill(unSet, "Croutes");

            connection.Close();

            return unSet;
        }


        private void MontrerBoutons(bool btnAjModSup, bool btnSauvAnnu)
        {
            btnAjouter.Visible = btnModifier.Visible = BtnSupprimer.Visible = btnAjModSup;
            btnSauvegarder.Visible = btnAnnuler.Visible = btnSauvAnnu;
            btnPremier.Visible = btnSuivant.Visible = btnPrecedent.Visible = btnDernier.Visible = btnAjModSup;

        }

        protected void btnPremier_Click(object sender, EventArgs e)
        {
            indiceCourant = 0;
            Afficher();
        }

        protected void btnSuivant_Click(object sender, EventArgs e)
        {
            if (indiceCourant < (tabPizza.Rows.Count - 1))
            {
                indiceCourant++;
                Afficher();
            }
        }

        protected void btnPrecedent_Click(object sender, EventArgs e)
        {
            if (indiceCourant > 0)
            {
                indiceCourant--;
                Afficher();
            }
        }

        protected void btnDernier_Click(object sender, EventArgs e)
        {
            indiceCourant = tabPizza.Rows.Count - 1;
            Afficher();
        }
    }
}