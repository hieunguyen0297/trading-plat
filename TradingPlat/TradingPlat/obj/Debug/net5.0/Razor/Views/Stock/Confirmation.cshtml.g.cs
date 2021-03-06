#pragma checksum "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab2c25334d8ac9f73aa17ae4122c6bbb584ffc6b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Stock_Confirmation), @"mvc.1.0.view", @"/Views/Stock/Confirmation.cshtml")]
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
#line 1 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\_ViewImports.cshtml"
using TradingPlat;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\_ViewImports.cshtml"
using TradingPlat.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab2c25334d8ac9f73aa17ae4122c6bbb584ffc6b", @"/Views/Stock/Confirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"375faf6fef9a67a09f38bc0f843f1a4a52b3bad1", @"/Views/_ViewImports.cshtml")]
    public class Views_Stock_Confirmation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 6 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"
 if (ViewBag.error != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"container\">\r\n        <h2>Ops, Something went wrong!</h2>\r\n        <p><span class=\"badge badge-danger\">Sorry, ");
#nullable restore
#line 10 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"
                                              Write(ViewBag.error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></p>\r\n        <p>Please try again!</p>\r\n        <p><a href=\"/stock/watchlist\">Retry</a></p>\r\n    </div>\r\n");
#nullable restore
#line 14 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"

}
else if (ViewBag.order == "Buy")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""container m-3 p-3"">
        <h1>Confirmation</h1>
        <h6>Congratulation! Your buy order has been processed successfully.</h6>
        <h3 class=""mt-3 p-3"">Order Details</h3>
        <h5 class=""mt-2 p-3"">Status: Filled</h5>
        <h5 class=""mt-3 p-3"">Buy Order For: <span>");
#nullable restore
#line 23 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"
                                             Write(ViewBag.symbol);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></h5>\r\n        <h5 class=\"mt-3 p-3\">Price: $");
#nullable restore
#line 24 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"
                                Write(Math.Round(ViewBag.price, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <h5 class=\"mt-3 p-3\">Quantity: ");
#nullable restore
#line 25 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"
                                  Write(ViewBag.quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <h4 class=\"mt-3 p-3\">Your total cost: $");
#nullable restore
#line 26 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"
                                          Write(Math.Round(ViewBag.totalCost, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n    </div>\r\n");
#nullable restore
#line 28 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"


}
else if (ViewBag.order == "Sell")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""container m-3 p-3"">
        <h1>Confirmation</h1>
        <h6>Congratulation! Your sell order has been processed successfully.</h6>
        <h3 class=""mt-3 p-3"">Order Details</h3>
        <h5 class=""mt-2 p-3"">Status: Filled</h5>
        <h5 class=""mt-3 p-3"">Sell Order For: <span>");
#nullable restore
#line 38 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"
                                              Write(ViewBag.symbol);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></h5>\r\n        <h5 class=\"mt-3 p-3\">Price: $");
#nullable restore
#line 39 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"
                                Write(Math.Round(ViewBag.price, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <h5 class=\"mt-3 p-3\">Quantity: ");
#nullable restore
#line 40 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"
                                  Write(ViewBag.quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <h4 class=\"mt-3 p-3\">Your total cost: $");
#nullable restore
#line 41 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"
                                          Write(Math.Round(ViewBag.totalCreditReceive, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n    </div>\r\n");
#nullable restore
#line 43 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
