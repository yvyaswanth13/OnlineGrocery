#pragma checksum "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7014721e6930e643a125a19fbd66e4bd36ade545"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_showBill), @"mvc.1.0.view", @"/Views/Orders/showBill.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\_ViewImports.cshtml"
using OnlineStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\_ViewImports.cshtml"
using OnlineStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7014721e6930e643a125a19fbd66e4bd36ade545", @"/Views/Orders/showBill.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a85bb3a1f5b42cee7936e01fe8aebb63edeff1ce", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_showBill : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Remove", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
  
    ViewData["Title"] = "Edit";
    List<Order> orders = ViewData["Order"] as List<Order>;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7014721e6930e643a125a19fbd66e4bd36ade5455222", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"css/bill.css\">\r\n    <link rel=\"icon\" href=\"https://upload.wikimedia.org/wikipedia/commons/thumb/d/df/Shopping_cart_icon.svg/938px-Shopping_cart_icon.svg.png\">\r\n    <title>Bill</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7014721e6930e643a125a19fbd66e4bd36ade5456420", async() => {
                WriteLiteral("\r\n\r\n    <h3>Online Grocery Store</h3>\r\n    <hr>\r\n\r\n    <div class=\"left-div\"><h3>Name: ");
#nullable restore
#line 18 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                               Write(orders.LastOrDefault().Email);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </h3></div>\r\n    <div class=\"right-div-right\"><h3>");
#nullable restore
#line 19 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                                Write(orders.LastOrDefault().Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("  </h3></div>\r\n    <div class=\"right-div\"><h3>Mobile Number: ");
#nullable restore
#line 20 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                                         Write(orders.LastOrDefault().MobileNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </h3></div>\r\n\r\n    <div class=\"left-div\"><h3>Order Date: ");
#nullable restore
#line 22 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                                     Write(orders.LastOrDefault().OrderDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3></div>\r\n    <div class=\"right-div-right\"><h3>Payment Method: ");
#nullable restore
#line 23 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                                                Write(orders.LastOrDefault().PaymentMethod);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </h3></div>\r\n    <div class=\"right-div\"><h3>Expected Delivery:  ");
#nullable restore
#line 24 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                                              Write(orders.LastOrDefault().DeliveryDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3></div>\r\n\r\n    <div class=\"right-div-right\"><h3>City: ");
#nullable restore
#line 26 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                                      Write(orders.LastOrDefault().City);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </h3></div>\r\n    <div class=\"right-div\"><h3>Address: ");
#nullable restore
#line 27 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                                   Write(orders.LastOrDefault().Address);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3></div>\r\n    <div class=\"left-div\"><h3>State: ");
#nullable restore
#line 28 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                                Write(orders.LastOrDefault().State);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </h3></div>\r\n    <div class=\"right-div-right\"><h3>Country: ");
#nullable restore
#line 29 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                                         Write(orders.Last().Country);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h3></div>

    <hr>
    <br>
    <table id=""customers"">

        <thead>
            <tr>
                <th scope=""col"">S.No</th>
                <th scope=""col"">Product Name</th>
                <th scope=""col"">Category</th>
                <th scope=""col""><i class=""fa fa-inr""></i> price</th>
                <th scope=""col"">Quantity</th>
                <th scope=""col"">Sub Total</th>
            </tr>
        </thead>
        <tbody>


");
#nullable restore
#line 48 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
              
                var count = 0;
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                 foreach (var item in orders)
                {

                    count = count + 1;

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td id=\"middle\">");
#nullable restore
#line 55 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                                   Write(count);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n                        <td id=\"middle\">\r\n                            ");
#nullable restore
#line 58 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                       Write(item.Pname);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td id=\"middle\">\r\n                            <i class=\"fa fa-inr\"></i>\r\n                            ");
#nullable restore
#line 62 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                       Write(item.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td id=\"middle\">\r\n                            ");
#nullable restore
#line 65 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                       Write(item.Quantity);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td id=\"middle\">\r\n                            <i class=\"fa fa-inr\"></i>\r\n                            ");
#nullable restore
#line 69 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                        Write(item.Price*item.Quantity);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td id=\"middle\">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7014721e6930e643a125a19fbd66e4bd36ade54513013", async() => {
                    WriteLiteral("Remove <i class=\'fas fa-trash-alt\'></i>");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 71 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                                                                                       WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</td>\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 74 "C:\Users\Admin\source\repos\OnlineStore\OnlineStore\Views\Orders\showBill.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </tbody>\r\n\r\n    </table>\r\n    <h3>Total:${total} </h3>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7014721e6930e643a125a19fbd66e4bd36ade54515978", async() => {
                    WriteLiteral("<button class=\"button left-button\">Continue Shopping</button>");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <a onclick=\"window.print();\"><button class=\"button right-button\">Print</button></a>\r\n    <br><br><br><br>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591