#pragma checksum "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5be76117cf92816099c5da2d81e787314385ec67"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5be76117cf92816099c5da2d81e787314385ec67", @"/Views/Stock/Confirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"375faf6fef9a67a09f38bc0f843f1a4a52b3bad1", @"/Views/_ViewImports.cshtml")]
    public class Views_Stock_Confirmation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>");
#nullable restore
#line 6 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"
Write(ViewBag.price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<h2>");
#nullable restore
#line 7 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"
Write(ViewBag.quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h3>");
#nullable restore
#line 8 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"
Write(ViewBag.stockId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<h3>");
#nullable restore
#line 9 "D:\IUPUI\FALL_2021\CIT_24200\MyApp\trading-plat\TradingPlat\TradingPlat\Views\Stock\Confirmation.cshtml"
Write(ViewBag.userId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>");
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
