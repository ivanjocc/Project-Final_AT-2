<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webPizzaManage.aspx.cs" Inherits="prjWebCsPizzaModele.webPizzaManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style type="text/css">
    #grandtableau{
        width:460px;
        
        margin:auto;
        background-color:burlywood;
        font-weight:bold;
        border-radius:5px;
    }
    #petittableau{
        width:100%;
       
        margin:auto;
        background-color:burlywood;
        font-weight:bold;
        border-radius:5px;

    }
    .boite{
        border-radius:3px;
    }
    .bouton{
        border-radius:8px;
    }

</style>

</head>
<body>
    <form id="form1" runat="server">
        <h1 style="text-align:center">GESTION DATA</h1>
        <hr style="width:800px" />
        <a href="webPizzaDatasetLocal.aspx">go to order</a>
        <div>

            <table id="grandtableau">
                <tr>
                    
                    <td style="vertical-align:top">
                        <table id="petittableau">
                            <tr>
                                <td>Nom Pizza : </td>
                                <td>
                                    <asp:TextBox ID="txtPizza" runat="server" CssClass="boite" Font-Bold="True" ForeColor="Blue" Width="200px" BorderStyle="Solid" BorderWidth="2px"></asp:TextBox>
                                </td>
                                <td rowspan="5" style="vertical-align:top">
                                    <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" CssClass="bouton" Font-Bold="True" Width="100px" OnClick="btnAjouter_Click" /><br />
                                    <asp:Button ID="btnModifier" runat="server" Text="Modifier" CssClass="bouton" Font-Bold="True" Width="100px" OnClick="btnModifier_Click" /><br />
                                    <asp:Button ID="BtnSupprimer" runat="server" Text="Supprimer" CssClass="bouton" Font-Bold="True" Width="100px" OnClick="BtnSupprimer_Click" OnClientClick="return confirm('are you sure you want to delete this?');" /><br />
                                    <asp:Button ID="btnSauvegarder" runat="server" Text="Sauvegarder" CssClass="bouton" Font-Bold="True" Width="100px" OnClick="btnSauvegarder_Click" /><br />
                                    <asp:Button ID="btnAnnuler" runat="server" Text="Annuler" CssClass="bouton" Font-Bold="True" Width="100px" OnClick="btnAnnuler_Click" />
                                </td>
                             </tr>
                            <tr>
                                <td>Prix Unitaire : </td>
                                <td>
                                    <asp:TextBox ID="txtPrix" runat="server" CssClass="boite" Font-Bold="True" ForeColor="Blue" Width="200px" BorderStyle="Solid" BorderWidth="2px"></asp:TextBox>
                                </td>
                                
                             </tr>
                            <tr>
                                <td style="vertical-align:top">Description : </td>
                                <td>
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="boite" Font-Bold="True" ForeColor="Blue" Width="200px" BorderStyle="Solid" BorderWidth="2px" TextMode="MultiLine" Height="50px"></asp:TextBox>
                                </td>
                               
                             </tr>
                            <tr>
                                
                                <td colspan="3" style="text-align:center">
                                    <asp:Button ID="btnPremier" runat="server" Text="Premier" CssClass="bouton" Font-Bold="True" Width="100px" OnClick="btnPremier_Click" />
                                    <asp:Button ID="btnSuivant" runat="server" Text="Suivant" CssClass="bouton" Font-Bold="True" Width="100px"  OnClick="btnSuivant_Click" />
                                    <asp:Button ID="btnPrecedent" runat="server" Text="Precedent" CssClass="bouton" Font-Bold="True" Width="100px" OnClick="btnPrecedent_Click" />
                                    <asp:Button ID="btnDernier" runat="server" Text="Dernier" CssClass="bouton" Font-Bold="True" Width="100px" OnClick="btnDernier_Click" />

                                </td>
                                
                             </tr>

                            <tr>
                               
                                <td colspan="3" style="text-align:center">
                                    <asp:Label ID="lblInfo" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
                                </td>
                                
                             </tr>


                        </table>
    


                    </td>
                </tr>
                


            </table>

            
        </div>
    </form>
</body>
</html>