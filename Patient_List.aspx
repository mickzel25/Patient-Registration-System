<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Patient_List.aspx.cs" Inherits="Patient_List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
      
<script type="text/javascript">
    function openViewModal() {
        $('#Modal_View').modal('show');
    }
      function openEditModal() {
          $('#Modal_Edit').modal('show');
      }
    function openDeleteModal() {
        $('#Modal_Delete').modal('show');
    }
</script>
    </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Patient List</h1>
          </div>
          <div class="col-sm-6">
            
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="container-fluid">
        <div class="row">
          <div class="col-12">
            <!-- Default box -->
            <div class="card">
              <div class="card-header">
           

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                    <i class="fas fa-minus"></i>
                  </button>
                  <button type="button" class="btn btn-tool" data-card-widget="remove" title="Remove">
                    <i class="fas fa-times"></i>
                  </button>
                </div>
              </div>
              <div class="card-body">
               <div class="row">
          <div class="col-12">
            <div class="card">
              <div class="card-header">
               

                <div class="card-tools">
                  <div class="input-group input-group-sm" style="width: 150px;">
            
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control float-right " placeholder="Search..." AutoPostBack="true"  OnTextChanged="txtSearch_TextChanged" onkeydown="searchOnEnter(event)"></asp:TextBox>
                    <div class="input-group-append">
                          <asp:LinkButton ID="btn_search" CssClass="btn btn-primary float-right"
                                                        runat="server" OnClick="btn_search_Click"> <i class="fas fa-search"></i></asp:LinkButton>
                     
                    </div>
                  </div>
                </div>
              </div>
              <!-- /.card-header -->
              <div class="card-body table-responsive p-0" style="height: 300px;">
                 

  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
                                        <div class="table-responsive">
                                           
                                            <asp:GridView ID="gv_branch" runat="server"
                                                CssClass="table table-sm table-bordered table-hover"
                                                AutoGenerateColumns="false" AllowPaging="true"
                                                OnPageIndexChanging="OnPaging" OnRowDataBound="gv_branch_RowDataBound" GridLines="None"
                                                PagerSettings-Mode="NumericFirstLast" PageSize="10"
                                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderStyle-BackColor="#f0f5f5">
                                                <PagerStyle HorizontalAlign="Right" />
                                                <Columns>
                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Last Name" ItemStyle-Width="20%" HeaderStyle-ForeColor="Black">
                                                <ItemTemplate>
                                                                 <asp:Label ID="lbl_lname" runat="server" Text=""></asp:Label>
                                                                 </ItemTemplate>
                                                                </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="First Name" ItemStyle-Width="20%" HeaderStyle-ForeColor="Black">
                                                <ItemTemplate>
                                                                 <asp:Label ID="lbl_fname" runat="server" Text=""></asp:Label>
                                                                 </ItemTemplate>
                                                                </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Midddle Name" ItemStyle-Width="20%" HeaderStyle-ForeColor="Black">
                                                <ItemTemplate>
                                                                 <asp:Label ID="lbl_mname" runat="server" Text=""></asp:Label>
                                                                 </ItemTemplate>
                                                                </asp:TemplateField>
                                                  
                                                     
                                                  
                                                    
                                                    <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                             <asp:HiddenField ID="hd_id" Value='<%#Eval("patient_id") %>' runat="server"></asp:HiddenField>
                                                              <asp:HiddenField ID="hd_lname" Value='<%#Eval("lname") %>' runat="server"></asp:HiddenField>
                                                          <asp:HiddenField ID="hd_fname" Value='<%#Eval("fname") %>' runat="server"></asp:HiddenField>
                                                              <asp:HiddenField ID="hd_mname" Value='<%#Eval("mname") %>' runat="server"></asp:HiddenField>
                                           
                                                            <asp:LinkButton ID="btn_view"  CssClass="btn btn-success"  CommandArgument='<%#Eval("patient_id") %>' Tooltip="View" onclick="btn_view_Click" runat="server" >
                                                     <i class="fa-sharp fa-solid fa-pen-to-square"></i>View</asp:LinkButton> 
                                                             <asp:LinkButton ID="LinkButton5"  CssClass="btn btn-primary"  CommandArgument='<%#Eval("patient_id") %>' Tooltip="View" onclick="btn_edit_Click" runat="server" >
                                                     <i class="fa-sharp fa-solid fa-pen-to-square"></i>Edit</asp:LinkButton> 
                                                            <asp:LinkButton ID="LinkButton1"  CssClass="btn btn-danger"  CommandArgument='<%#Eval("patient_id") %>' Tooltip="View" onclick="btn_delete_Click" runat="server" >
                                                     <i class="fa-sharp fa-solid fa-pen-to-square"></i>Delete</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:Label ID="lbl_item" runat="server" Text="" CssClass="form-control-label"></asp:Label>

                                        </div>
                                    
        

       
                  
         </ContentTemplate>

  </asp:UpdatePanel>
          
        
              </div>
              <!-- /.card-body -->
            </div>
            <!-- /.card -->
          </div>
        </div>
              </div>
              <!-- /.card-body -->
              <div class="card-footer">
              
  <button type="button" class="btn btn-block btn-primary">Add New Patient</button>
                    
              </div>
              <!-- /.card-footer-->
            </div>
            <!-- /.card -->
          </div>
        </div>
      </div>
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

                        <div class="modal fade" id="Modal_Edit">
        <div class="modal-dialog modal-xl">
          <div class="modal-content">
            <div class="modal-header">
                <asp:HiddenField ID="hd_idedit" runat="server" />
              <h4 class="modal-title">Edit Patient Info</h4>

              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
                  <div class="card-body">
                  <div class="form-group">
                    <label for="exampleInputEmail1">Last Name</label>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
   
                  </div>
                 <div class="form-group">
                    <label for="exampleInputEmail1">First Name</label>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                  </div>
                     <div class="form-group">
                    <label for="exampleInputEmail1">Middle Name</label>
    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                  </div>
                     <div class="form-group">
                    <label for="exampleInputEmail1">Sex</label>
    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                  </div>
                     <div class="form-group">
                    <label for="exampleInputEmail1">Birth date</label>        
    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" placeholder="" TextMode="Date"></asp:TextBox>
                  </div>
                     <div class="form-group">
                    <label for="exampleInputEmail1">Address</label>
    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" placeholder="" TextMode="MultiLine"></asp:TextBox>
                  </div>
                 
              
                </div>
            </div>
            <div class="modal-footer justify-content-between">
                 <asp:LinkButton ID="LinkButton4" CssClass="btn btn-primary float-right"
                                                        runat="server" OnClick="btn_update_Click">Update</asp:LinkButton>
      
              
            </div>
          </div>

          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>   
                    <div class="modal fade" id="Modal_View">
        <div class="modal-dialog modal-xl">
          <div class="modal-content">
            <div class="modal-header">
<asp:HiddenField ID="hd_idview" runat="server" />
              <h4 class="modal-title">Patient Info</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
                    <div class="card-body">
                  <div class="form-group">
                    <label for="exampleInputEmail1">Last Name</label>
                        <asp:TextBox ID="txt_lname" runat="server" CssClass="form-control" placeholder="" Enabled="False"></asp:TextBox>
   
                  </div>
                 <div class="form-group">
                    <label for="exampleInputEmail1">First Name</label>
                        <asp:TextBox ID="txt_fname" runat="server" CssClass="form-control" placeholder="" Enabled="False"></asp:TextBox>
                  </div>
                     <div class="form-group">
                    <label for="exampleInputEmail1">Middle Name</label>
    <asp:TextBox ID="txt_mname" runat="server" CssClass="form-control" placeholder="" Enabled="False"></asp:TextBox>
                  </div>
                     <div class="form-group">
                    <label for="exampleInputEmail1">Sex</label>
    <asp:TextBox ID="txt_sex" runat="server" CssClass="form-control" placeholder="" Enabled="False"></asp:TextBox>
                  </div>
                     <div class="form-group">
                    <label for="exampleInputEmail1">Birth date</label>        
    <asp:TextBox ID="txt_bdate" runat="server" CssClass="form-control" placeholder="" TextMode="Date" Enabled="False"></asp:TextBox>
                  </div>
                     <div class="form-group">
                    <label for="exampleInputEmail1">Address</label>
    <asp:TextBox ID="txt_address" runat="server" CssClass="form-control" placeholder="" TextMode="MultiLine" Enabled="False"></asp:TextBox>
                  </div>
                 
              
                </div>
            </div>
           
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>  
                  
                        <div class="modal fade" id="Modal_Delete">
        <div class="modal-dialog modal-sm">
          <div class="modal-content">
            <div class="modal-header">
                <asp:HiddenField ID="hd_iddelete" runat="server" />
              <h4 class="modal-title">Small Modal</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Are You Sure You want to Delete This Patient?</p>
            </div>
            <div class="modal-footer justify-content-between">
                   <asp:LinkButton ID="LinkButton2" CssClass="btn btn-danger float-right"
                                                        runat="server" OnClick="btn_softdelete_Click">Delete</asp:LinkButton>
         
              
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div> 
        </ContentTemplate>
        </asp:UpdatePanel>
 </section>
</asp:Content>

