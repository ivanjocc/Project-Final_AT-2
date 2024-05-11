<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webPizzaDatasetLocal.aspx.cs" Inherits="prjWebCsPizzaModele.webPizzaDatasetLocal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color:darkgoldenrod;
            font-weight:bold;

        }
        h1{
            text-align:center;
            color:darkred;
        }
        marquee{
            background-color:green;
            color:red;
        }
        .boite{
            width:200px;
            font-weight:bold;
            color:blue;
            border-radius:5px;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>PIZZA DEL GATICO 😺</h1>
            <hr />
            <marquee>
                La Meilleure pizza en Amerique Nord, faite avec des ingredients
                naturelles importes du Liban, avec de la viande halal, a consommer avec 
                du vin rouge.
            </marquee>
            <hr />
            <a href="webPizzaManage.aspx">go to admin</a>

<table style="margin:auto" >
    <tr>
        <td rowspan="2">
            <asp:Panel ID="panPizza" runat="server" BackColor="#FFBE5E" 
                Font-Bold="True" GroupingText="Informations sur la Commande" 
                Width="500px" Height="460px">

                <table>
                    <tr>
                        <td>Telephone du Client : </td>
                        <td>
                            <asp:TextBox ID="txtTelephone" runat="server" CssClass="boite"></asp:TextBox>
                                                    <asp:Button ID="btnTrouver" runat="server" Text="Trouver" OnClick="btnTrouver_Click"  />
                        </td>
                    </tr>

                    <tr>
                        <td>Nom du Client : </td>
                        <td>
                            <asp:TextBox ID="txtNom" runat="server" CssClass="boite"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Pour Livraison ? : </td>
                        <td>
                            <asp:CheckBox ID="chkLivraison" runat="server" OnCheckedChanged="chkLivraison_CheckedChanged" Font-Bold="True" Text=" Oui" AutoPostBack="True" />
                        </td>
                    </tr>

                    <tr>
                        <td style="vertical-align:top">
                            <asp:Label ID="lblAdresse" runat="server" Text="Adresse de Livraison : " Font-Bold="True"></asp:Label> </td>
                        <td>
                            <asp:TextBox ID="txtAdresse" runat="server" CssClass="boite" TextMode="MultiLine" Height="50px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Votre Pizza :</td>
                        <td>
                            <asp:DropDownList ID="cboPizzas" runat="server" CssClass="boite" AutoPostBack="True" >
                                
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top">Choisir une Taille :</td>
                        <td>
                            <asp:ListBox ID="lstTailles" runat="server" CssClass="boite" AutoPostBack="True" ></asp:ListBox>
                        </td>
                    </tr>

                    <tr>
                        <td style="vertical-align:top">Choisir vos Garnitures :</td>
                        <td>
                            <asp:CheckBoxList ID="lstChkGarnitures" runat="server" AutoPostBack="true" ForeColor="Black"></asp:CheckBoxList>
                        </td>
                    </tr>

                   <tr>
                        <td style="vertical-align:top">Choisir votre Croute :</td>
                        <td>
                            <asp:RadioButtonList ID="lstRadCroutes" runat="server"></asp:RadioButtonList>
                        </td>
                    </tr>



                </table>


            </asp:Panel>

        </td>
        <td style="vertical-align:top">
            <asp:Panel ID="panPrix" runat="server" BackColor="#FFBE5E" 
                Font-Bold="True" GroupingText="Evaluation du prix de la pizza" 
                Width="400px" Height="220px" >

                <asp:Literal ID="litPrix" runat="server"></asp:Literal>
                <br />
                <asp:Button ID="btnCommander" runat="server" Text="Commander" Font-Bold="True" Width="200px" BackColor="#CCFF99" OnClick="btnCommander_Click"  />
            </asp:Panel>

        </td>
    </tr>
    <tr>
       
        <td>
            <asp:Panel ID="panCommande" runat="server" BackColor="#FFBE5E" 
                Font-Bold="True" GroupingText="Informations sur la Commande" 
                Width="400px" Height="240px" >

                <asp:Literal ID="litInfos" runat="server"></asp:Literal>
                
                
            </asp:Panel>
        </td>
    </tr>

</table>

        </div>
    </form>
</body>
</html>