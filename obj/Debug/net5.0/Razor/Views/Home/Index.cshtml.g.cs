#pragma checksum "C:\Users\qudra\source\repos\AccountedOfFamily\AccountedOfFamily\AccountedOfFamily\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69ac6cfe643f102235e8d5c08e1496f6ae4735ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\qudra\source\repos\AccountedOfFamily\AccountedOfFamily\AccountedOfFamily\Views\_ViewImports.cshtml"
using AccountedOfFamily.Models.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\qudra\source\repos\AccountedOfFamily\AccountedOfFamily\AccountedOfFamily\Views\_ViewImports.cshtml"
using AccountedOfFamily.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\qudra\source\repos\AccountedOfFamily\AccountedOfFamily\AccountedOfFamily\Views\_ViewImports.cshtml"
using AccountedOfFamily.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\qudra\source\repos\AccountedOfFamily\AccountedOfFamily\AccountedOfFamily\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69ac6cfe643f102235e8d5c08e1496f6ae4735ca", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3edbb1014574bed2f360133a8137f6f5d45efae0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AppUser>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/a.jpeg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "all", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Economic", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""row"">
    <div class=""col social"">
        <span class=""black-line""></span>
        <h4 class=""social-header"">Домашняя<br /> бухгалтерия</h4>
        <p class=""social-text"">С помощю этого платформа вы можете управлять ваше фынансовий операции. 
        Это очен экономит ваше время и затрати.</p>
    </div>
    <div class=""col"">
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "69ac6cfe643f102235e8d5c08e1496f6ae4735ca5528", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
</div>

<div class=""row"">
    <div class=""col"">
        <div class=""cart"">
            <div class=""cart__logo"">
                <i class=""fa-solid fa-hand-holding-dollar color-aqua""></i>
            </div>
            <div class=""cart__body"">
                <h4>Доходы</h4>
                <p>Ваше все семейное доходы</p>
            </div>
        </div>
        <div class=""cart"">
            <div class=""cart__logo"">
                <i class=""fa-solid fa-money-check-dollar color-blue""></i>
            </div>
            <div class=""cart__body"">
                <h4>Затрати</h4>
                <p>Ваше все семейное затраты</p>
            </div>
        </div>
        <div class=""cart"">
            <div class=""cart__logo"">
                <i class=""fa-solid fa-money-bill-transfer color-yellow""></i>
            </div>
            <div class=""cart__body"">
                <h4>Депозити</h4>
                <p>Если в вашем семя у кого то есть депозитний сумма тогда вы можете");
            WriteLiteral(@"
                найти данных ою этом на этом сайте.</p>
            </div>
        </div>
        <div class=""cart"">
            <div class=""cart__logo"">
                <i class=""fa-solid fa-square-poll-horizontal color-red""></i>
            </div>
            <div class=""cart__body"">
                <h4>Планированний денежний операции</h4>
                <p>Вы можете планировать и очен легко управлять ваше будуще денежной операции</p>
            </div>
        </div>
    </div>
    <div class=""col-5 report"">
        <h4>Ваше финансовый отчёти</h4>
        <p>
            Содыраемся все данный о денежной операции ваше семя. Вы можете управлять, изменять, удалять ненужнии и
            выполнить другий действии
        </p>
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69ac6cfe643f102235e8d5c08e1496f6ae4735ca8414", async() => {
                WriteLiteral("ПОДРОБНЕЕ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div class=\"tableimg\">\r\n\r\n</div>\r\n\r\n<div class=\"blueplace\"></div>\r\n\r\n<div class=\"users\">\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 73 "C:\Users\qudra\source\repos\AccountedOfFamily\AccountedOfFamily\AccountedOfFamily\Views\Home\Index.cshtml"
         foreach (var user in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"user-card\">\r\n                <a>\r\n                    <div class=\"user-img\">\r\n");
#nullable restore
#line 78 "C:\Users\qudra\source\repos\AccountedOfFamily\AccountedOfFamily\AccountedOfFamily\Views\Home\Index.cshtml"
                         if (user.Img != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <img");
            BeginWriteAttribute("src", " src=\"", 2673, "\"", 2688, 1);
#nullable restore
#line 80 "C:\Users\qudra\source\repos\AccountedOfFamily\AccountedOfFamily\AccountedOfFamily\Views\Home\Index.cshtml"
WriteAttributeValue("", 2679, user.Img, 2679, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 81 "C:\Users\qudra\source\repos\AccountedOfFamily\AccountedOfFamily\AccountedOfFamily\Views\Home\Index.cshtml"
                        }
                        else
                        {
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <ul class=\"fa fa-user\"></ul>\r\n");
#nullable restore
#line 86 "C:\Users\qudra\source\repos\AccountedOfFamily\AccountedOfFamily\AccountedOfFamily\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </a>\r\n                <div class=\"user-body\">\r\n                    <h4>");
#nullable restore
#line 90 "C:\Users\qudra\source\repos\AccountedOfFamily\AccountedOfFamily\AccountedOfFamily\Views\Home\Index.cshtml"
                   Write(user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 93 "C:\Users\qudra\source\repos\AccountedOfFamily\AccountedOfFamily\AccountedOfFamily\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AppUser>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
