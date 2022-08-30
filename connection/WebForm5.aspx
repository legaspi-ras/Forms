<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm5.aspx.vb" Inherits="connection.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.6.347/pdf.min.js"></script>
<link href="https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.6.347/pdf_viewer.min.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        $("[id*=gvFiles] .view").click(function () {

            alert("proceed");

            var fileId = $(this).attr("rel");
            $.ajax({
                type: "POST",
                url: "WebForm5.aspx/GetPDF",
                data: "{fileId: " + fileId + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    LoadPdfFromBlob(r.d.Data);
                },
                error: function () {
                    alert("error");
                }

            });
        });
    });

    var pdfjsLib = window['pdfjs-dist/build/pdf'];
    pdfjsLib.GlobalWorkerOptions.workerSrc = 'https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.6.347/pdf.worker.min.js';
    var pdfDoc = null;
    var scale = 1; //Set Scale for zooming PDF.
    var resolution = 1; //Set Resolution to Adjust PDF clarity.

    function LoadPdfFromBlob(blob) {

        alert("im here loadpdffromblob");

        //Read PDF from BLOB.
        pdfjsLib.getDocument({ data: blob }).promise.then(function (pdfDoc_) {
            pdfDoc = pdfDoc_;

            //Reference the Container DIV.
            var pdf_container = document.getElementById("pdf_container");
            pdf_container.innerHTML = "";
            pdf_container.style.display = "block";

            //Loop and render all pages.
            for (var i = 1; i <= pdfDoc.numPages; i++) {
                RenderPage(pdf_container, i);
            }
        });
    };
    function RenderPage(pdf_container, num) {
        pdfDoc.getPage(num).then(function (page) {
            //Create Canvas element and append to the Container DIV.
            var canvas = document.createElement('canvas');
            canvas.id = 'pdf-' + num;
            ctx = canvas.getContext('2d');
            pdf_container.appendChild(canvas);

            //Create and add empty DIV to add SPACE between pages.
            var spacer = document.createElement("div");
            spacer.style.height = "20px";
            pdf_container.appendChild(spacer);

            //Set the Canvas dimensions using ViewPort and Scale.
            var viewport = page.getViewport({ scale: scale });
            canvas.height = resolution * viewport.height;
            canvas.width = resolution * viewport.width;

            //Render the PDF page.
            var renderContext = {
                canvasContext: ctx,
                viewport: viewport,
                transform: [resolution, 0, 0, resolution, 0, 0]
            };

            page.render(renderContext);
        });
    };
</script>

    <style type="text/css">
    body { font-family: Arial; font-size: 10pt; }
    table { border: 1px solid #ccc; border-collapse: collapse; }
    table th { background-color: #F7F7F7; color: #333; font-weight: bold; }
    table th, table td { padding: 5px; border: 1px solid #ccc; }
    #pdf_container { background: #ccc; text-align: center; display: none; padding: 5px; height: 820px; overflow: auto; }
</style>

    <system.web.extensions>
    <scripting>
        <webServices>
            <jsonSerialization maxJsonLength="819200000">
            </jsonSerialization>
        </webServices>
    </scripting>
</system.web.extensions>

</head>
<body>
    <form id="form1" method="post" runat="server">

       <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />

        <hr />
        
        <asp:GridView ID="gvFiles" runat="server" AutoGenerateColumns="false">
            <Columns>
              <asp:BoundField DataField="departmentArea" HeaderText="Department Area" ItemStyle-Width="150" >
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="formControlnum" HeaderText="Form Control #" ItemStyle-Width="150" >
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="formTitle" HeaderText="Form Title" ItemStyle-Width="150" >
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="applicableSpecs" HeaderText="Applicable Specification" ItemStyle-Width="150" >
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="revisionNum" HeaderText="Revision" ItemStyle-Width="150" >
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="revisionDate" HeaderText="Revition Date" ItemStyle-Width="150" >
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
             
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                         <a class="view" href="javascript:;" rel='<%# Eval("Id") %>'>View PDF</a>
                   </ItemTemplate>
              </asp:TemplateField>
            
            </Columns>
        </asp:GridView>
        
        <hr />
        
        <div id="pdf_container">
        </div>


    </form>
</body>
</html>
