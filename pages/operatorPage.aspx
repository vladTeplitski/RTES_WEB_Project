<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="operatorPage.aspx.cs" Inherits="operatorPage" %>

<asp:Content ID="homeContent" ContentPlaceHolderID="home" runat="Server">
    <script src="../json/infoTexts.json"></script>
    <script src="../inc/funcLib.js"></script>
    <script src="../inc/angularScript.js"></script>

</asp:Content>


<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="container-fluid" ng-controller="operatorController">

        <!--START Operator Page-->
        <div class="row bodyRow operatorWindow">
            <form runat="server" id="writeMessageBox">

            <div class="col-lg-3 col-lg-offset-1 col-md-4 col-md-offset-0 col-xs-8 col-xs-offset-2">
                <div class="getStartedBox" style="position: relative; margin-top: 8px; margin-bottom: 8px;">
     
                <div class="btnInfo btn1">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-folder-open"></i></div>
                    Existing Reports Folder
                </div>

               <div class="btnInfo btn2">
                   <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-pencil"></i></div>
                   Send Message To Client
               </div>
  
                <div class="btnInfo btn3">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-folder-open"></i></div>
                    View Users Details
                </div>
                
                <a href="clientMainPage.aspx">
                <div class="btnInfo btn4">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-th-large"></i></div>
                    Client CP
                </div>
                </a>
                </div>
            </div>

            <div class="col-lg-6 col-lg-offset-1 col-md-6 col-md-offset-1 col-xs-12">
            <div class="mainWindow">
                <div class="textContainer chapter1">
                    operator Home.
                </div>
                <div class="textContainer chapter2" style="overflow:auto;">

                <div runat="server" id="reportsInSystem" class="personalDetailsClass">
                   <i Style="font-size:23px;" class="glyphicon glyphicon-list-alt"></i>
                   <span style="margin-left:10px;">Existing reports in system</span>
                </div><br />

               <asp:ScriptManager runat="server" ID="sm1">
               </asp:ScriptManager>
               <asp:updatepanel runat="server">
               <ContentTemplate>
                         <div runat="server" id="InfoLable" class="infoTableClass opRepLabelJs">
                           <div class="reportLabelHead">
                                 <b>Report Information</b>
                                <asp:LinkButton runat="server" CssClass="x" Text="x" OnClick="closeFrame"/>
                            </div>
                             <div style="margin-top:5px;">
                         <asp:Label runat="server" ID="moreInfoLabel"></asp:Label>
                             </div>
                         </div>
                             
               <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="rowClick">
               <HeaderTemplate>
                   <table class="table table - striped" style="font-size:small;">
                        <tr>
                            <th>Report ID</th>
                            <th>Client ID</th>
                            <th>Case ID</th>
                            <th>Date</th>
                            <th>Hour</th>
                            <th>Location</th>
                            <th>Towing Dest</th>
                        </tr>
               </HeaderTemplate>
               <ItemTemplate>
                       <tr>
                             <td>
                               <%#Eval("reportID")%>
                             </td>
                              <td>
                                <%#Eval("clientAbstractUserId")%>
                             </td>
                              <td>
                                <%#Eval("caseCaseId")%>
                             </td>
                           <td>
                                <%#Eval("date")%>
                             </td>
                           <td>
                                <%#Eval("hour")%>
                             </td>
                           <td>
                                <%#Eval("location")%>
                             </td>
                           <td>
                                <%#Eval("towing_destination")%>
                             </td>
                           <td>
                                <asp:LinkButton ID="Button1" CommandName="click" Text="More" runat="server" CssClass="button101"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "reportID") %>'/>
                           </td>
                      </tr>
                   

               </ItemTemplate>
               <FooterTemplate>
                  </table>
               </FooterTemplate>
               </asp:Repeater>
                            </ContentTemplate>
                            </asp:updatepanel>
                </div>
                <div class="textContainer chapter3">
                    
                         <div runat="server" id="Div1" class="personalDetailsClass">
                             <i Style="font-size:23px;" class="glyphicon glyphicon-user"></i>
                             <span style="margin-left:10px;">Send message to client</span>
                         </div><br/>
                         <div runat="server" id="Div2" class="personalDetailsClass">
                             <i Style="font-size:23px;" class="glyphicon glyphicon-user"></i>
                             <span style="margin-left:10px;">Choose client:</span>
                              <asp:DropDownList ID="dropList" runat="server" ToolTip="Choose the wanted user ID" Style="margin-left:10px;width:200px;color:black;height:40px;border-radius:5px;"></asp:DropDownList>
                         </div><br/>
                    <asp:TextBox id="Textbox1" TextMode="multiline" Columns="50" Rows="5" runat="server" Style="width:100%;margin:auto"/>
                    <asp:Button runat="server" ID="sendMsgBtn" onclick="sendMessage" CssClass="btn btn-default settingsBtn" Text="Send" Style="margin-top:5px; margin-left:2%;" />

                    
                </div>
                <div class="textContainer chapter4"  style="overflow:auto;">

                <div runat="server" id="userDetailsPanel" class="personalDetailsClass">
                   <i Style="font-size:23px;" class="glyphicon glyphicon-user"></i>
                   <span style="margin-left:10px;">Users List</span>
                </div><br />


               <asp:updatepanel runat="server">
               <ContentTemplate>
                         <div runat="server" id="userListLable" class="infoTableClass opRepLabelJs">
                           <div class="reportLabelHead">
                                 <b>Client Information</b>
                                <asp:LinkButton runat="server" CssClass="x" Text="x" OnClick="closeClientList"/>
                            </div>
                             <div style="margin-top:5px;">
                         <asp:Label runat="server" ID="clientListLabel"></asp:Label>
                             </div>
                         </div>

               <asp:Repeater ID="Repeater2" runat="server"  OnItemCommand="clientListClick">
               <HeaderTemplate>
                   <table class="table table - striped" style="font-size:small;">
                        <tr>
                            <th>Rank</th>
                            <th>User ID</th>
                            <th>First Name</th>
                            <th>Family Name</th>

                        </tr>
               </HeaderTemplate>
               <ItemTemplate>
                       <tr>
                           <td>
                                <%#Eval("role")%>
                             </td>
                             <td>
                               <%#Eval("id")%>
                             </td>
                              <td>
                                <%#Eval("name")%>
                             </td>
                              <td>
                                <%#Eval("familyName")%>
                             </td>
                             <td>
                                <asp:LinkButton ID="Button2" CommandName="click" Text="Info" runat="server" CssClass="button101"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>'/>
                             </td>
                      </tr>
               </ItemTemplate>
               <FooterTemplate>
                  </table>
               </FooterTemplate>
               </asp:Repeater>
                            </ContentTemplate>
                            </asp:updatepanel>
                </div>
            </div>

            </div>
        </form>
        </div>



    </div>

</asp:Content>
