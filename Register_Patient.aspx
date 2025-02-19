<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register_Patient.aspx.cs" Inherits="Register_Patient" %>
  
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
      
<script type="text/javascript">
      function openModal() {
          $('#Modal_Add').modal('show');
      }
</script>
    </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>

     <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Add Patient</h1>
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
            <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Patient Info</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
              <form>
                <div class="card-body">
                  <div class="form-group">
                    <label for="exampleInputEmail1">Last Name</label>
                        <asp:TextBox ID="txt_lname" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
   
                  </div>
                 <div class="form-group">
                    <label for="exampleInputEmail1">First Name</label>
                        <asp:TextBox ID="txt_fname" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                  </div>
                     <div class="form-group">
                    <label for="exampleInputEmail1">Middle Name</label>
    <asp:TextBox ID="txt_mname" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                  </div>
                     <div class="form-group">
                    <label for="exampleInputEmail1">Sex</label>
    <asp:TextBox ID="txt_sex" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                  </div>
                     <div class="form-group">
                    <label for="exampleInputEmail1">Birth date</label>        
    <asp:TextBox ID="txt_bdate" runat="server" CssClass="form-control" placeholder="" TextMode="Date"></asp:TextBox>
                  </div>
                     <div class="form-group">
                    <label for="exampleInputEmail1">Address</label>
    <asp:TextBox ID="txt_address" runat="server" CssClass="form-control" placeholder="" TextMode="MultiLine"></asp:TextBox>
                  </div>
                 
              
                </div>
                <!-- /.card-body -->
                    
                <div class="card-footer">
                     
                 
                      <asp:LinkButton ID="LinkButton4" CssClass="btn btn-primary float-right"
                                                        runat="server" OnClick="btn_submit_Click">Submit</asp:LinkButton>
                   
                </div>
                 
              </form>
                
            </div>
            <!-- /.card -->

                  
          </div>
           
        </div>
            
      </div>
      
 </section>
        </ContentTemplate>
        </asp:UpdatePanel>
     <div class="modal fade" id="Modal_Add">
        <div class="modal-dialog modal-sm">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Small Modal</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <p>Successfully Save&hellip;</p>
            </div>
            <div class="modal-footer justify-content-between">
              <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
              
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div> 
</asp:Content>
 

