#pragma checksum "C:\Users\Ale\Desktop\PL\LabMVC\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b7da890b77d79a9a7c884fca8a11133a24ef636"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#line 1 "C:\Users\Ale\Desktop\PL\LabMVC\Views\_ViewImports.cshtml"
using LabMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ale\Desktop\PL\LabMVC\Views\_ViewImports.cshtml"
using LabMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b7da890b77d79a9a7c884fca8a11133a24ef636", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74bddf53308d941e3931bd38254126b43d3a21a5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-spy", new global::Microsoft.AspNetCore.Html.HtmlString("scroll"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-target", new global::Microsoft.AspNetCore.Html.HtmlString(".navbar-collapse"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-offset", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b7da890b77d79a9a7c884fca8a11133a24ef6364588", async() => {
                WriteLiteral("\r\n\r\n    <title>UCR_RP-Info_Emp</title>\r\n    <!--\r\n\r\n    Known Template\r\n\r\n    https://templatemo.com/tm-516-known\r\n\r\n    -->\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\">\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 282, "\"", 292, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n    <meta name=\"keywords\"");
                BeginWriteAttribute("content", " content=\"", 321, "\"", 331, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n    <meta name=\"author\"");
                BeginWriteAttribute("content", " content=\"", 358, "\"", 368, 0);
                EndWriteAttribute();
                WriteLiteral(@">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">

    <link rel=""stylesheet"" href=""css/bootstrap.min.css"">
    <link rel=""stylesheet"" href=""css/font-awesome.min.css"">
    <link rel=""stylesheet"" href=""css/owl.carousel.css"">
    <link rel=""stylesheet"" href=""css/owl.theme.default.min.css"">
    <link rel=""shortcut icon"" type=""image/x-icon"" href=""/images/favicon.ico"" />

    <!-- MAIN CSS -->
    <link rel=""stylesheet"" href=""css/templatemo-style.css"">

");
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
            WriteLiteral("\r\n<div class=\"container\">\r\n    <main role=\"main\" class=\"pb-3\">\r\n        ");
#nullable restore
#line 32 "C:\Users\Ale\Desktop\PL\LabMVC\Views\Shared\_Layout.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </main>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b7da890b77d79a9a7c884fca8a11133a24ef6367200", async() => {
                WriteLiteral(@"

    <!-- PRE LOADER -->
    <section class=""preloader"">
        <div class=""spinner"">

            <span class=""spinner-rotate""></span>

        </div>
    </section>


    <!-- MENU -->
    <section class=""navbar custom-navbar navbar-fixed-top"" role=""navigation"">
        <div class=""container"">

            <div class=""navbar-header"">
                <button class=""navbar-toggle"" data-toggle=""collapse"" data-target="".navbar-collapse"">
                    <span class=""icon icon-bar""></span>
                    <span class=""icon icon-bar""></span>
                    <span class=""icon icon-bar""></span>
                </button>

                <!-- lOGO TEXT HERE -->
                <a href=""#"" class=""navbar-brand"">❁ Informatica Empresarial ❁</a>
            </div>

            <!-- MENU LINKS -->
            <div class=""collapse navbar-collapse"">
                <ul class=""nav navbar-nav navbar-nav-first"">
                    <li><a href=""#top"" class=""smoothScroll"">Inicio</a></l");
                WriteLiteral(@"i>
                    <li><a href=""#about"" class=""smoothScroll"">Registro</a></li>
                </ul>

                <ul class=""nav navbar-nav navbar-right"">
                    <li><a href=""#""><i class=""fa fa-phone-square""></i> +506 2511-7550</a></li>
                </ul>
            </div>

        </div>
    </section>


    <!-- HOME -->
    <section id=""home"">
        <div class=""row"">

            <div class=""owl-carousel owl-theme home-slider"">
                <div class=""item item-first"">
                    <div class=""caption"">
                        <div class=""container"">
                            <div class=""col-md-6 col-sm-12"">
                                <h1>Universidad de Costa Rica, Recinto de Paraíso</h1>
                                <h3>Bienvenido a la carrerra de Informática empresarial, aquí descubrirás todo lo relacionado a tecnología y mundo laboral actual.</h3>
                                <a href=""#feature"" class=""section-btn btn btn-default ");
                WriteLiteral(@"smoothScroll"">Leer más</a>
                            </div>
                        </div>
                    </div>
                </div>

                <div class=""item item-second"">
                    <div class=""caption"">
                        <div class=""container"">
                            <div class=""col-md-6 col-sm-12"">
                                <h1>Inicia la carrera en esta gran institución</h1>
                                <h3>Ahora la carrera de informática empresarial esta acreditada por SINAES.</h3>
                            </div>
                        </div>
                    </div>
                </div>

                <div class=""item item-third"">
                    <div class=""caption"">
                        <div class=""container"">
                            <div class=""col-md-6 col-sm-12"">
                                <h1>Contamos con los mejores profesores</h1>
                                <h3>Si necesitas connsultar textos acade");
                WriteLiteral(@"micos, artículos o revistas academicas puedes ingresar aquí. Visita <a rel=""nofollow"" href=""http://sibdi.ucr.ac.cr/"">SIBDI</a></h3>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <!-- FEATURE -->
    <section id=""feature"">
        <div class=""container"">
            <div class=""row"">

                <div class=""col-md-4 col-sm-4"">
                    <div class=""feature-thumb"">
                        <span>01</span>
                        <h3>Conoce el plan de estudio.</h3>
                        <p>En este <a href=""https://www.srp.ucr.ac.cr/sites/default/files/Planesdeestudios/FichaProfesiograficaInformaticaEmpresarial.pdf"" target=""_blank"">documento </a> obtendras información acerca de nuestras habilidades, destrezas, mercado laboral, etc</p>
                    </div>
                </div>

                <div class=""col-md-4 col-sm-4"">
                   ");
                WriteLiteral(@" <div class=""feature-thumb"">
                        <span>02</span>
                        <h3>Un poco de historia </h3>
                        <p>A lo largo de este <a href=""https://www.scielo.sa.cr/scielo.php?script=sci_arttext&pid=S1409-47032018000100033"" target=""_blank"">documento</a> podras leer por parte de dos de nuestros profesores un poco de historia acerca del recinto</p>
                    </div>
                </div>

                <div class=""col-md-4 col-sm-4"">
                    <div class=""feature-thumb"">
                        <span>03</span>
                        <h3>Transporte</h3>
                        <p>En el siguiente <a href=""https://yoviajocr.com/bus/cartago-orosi"" target=""_blank"">link</a> podras consultar el horario de autobuses, porque nos preocupamos para que llegues a tiempo :)</p>
                    </div>
                </div>

            </div>
        </div>
    </section>


    <!-- ABOUT -->
    <section id=""about"">
        <div class=""co");
                WriteLiteral(@"ntainer"">
            <div class=""row"">

                <div class=""col-md-6 col-sm-12"">
                    <div class=""entry-form"">
                        <!--<form action=""#"" method=""post"">-->

                        <h2>Registrate</h2>
                        <input type=""text"" name=""studentCard"" id=""studentCard"" class=""form-control"" placeholder=""Carné estudiantil""");
                BeginWriteAttribute("required", " required=\"", 6576, "\"", 6587, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n                        <input type=\"text\" name=\"full name\" id=\"name\" class=\"form-control\" placeholder=\"Nombre\"");
                BeginWriteAttribute("required", " required=\"", 6704, "\"", 6715, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n                        <input type=\"text\" name=\"lastName\" id=\"lastName\" class=\"form-control\" placeholder=\"Apellidos\"");
                BeginWriteAttribute("required", " required=\"", 6838, "\"", 6849, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n                        <input type=\"text\" name=\"email\" id=\"email\" class=\"form-control\" placeholder=\"Correo electrónico\"");
                BeginWriteAttribute("required", " required=\"", 6975, "\"", 6986, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n                        <input type=\"text\" name=\"phone\" id=\"phone\" class=\"form-control\" placeholder=\"Teléfono\"");
                BeginWriteAttribute("required", " required=\"", 7102, "\"", 7113, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n                        <input type=\"text\" name=\"address\" id=\"address\" class=\"form-control\" placeholder=\"Dirección\"");
                BeginWriteAttribute("required", " required=\"", 7234, "\"", 7245, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n                        <input type=\"password\" name=\"password\" id=\"password\" class=\"form-control\" placeholder=\"Contraseña\"");
                BeginWriteAttribute("required", " required=\"", 7373, "\"", 7384, 0);
                EndWriteAttribute();
                WriteLiteral(@">

                        <div>
                            <button class=""submit-btn form-control"" onclick=""return Add()"" id=""form-submit"">Registrar</button>
                        </div>
                        <div id=""incorrectLabel"" class=""hide"" role=""alert"">Error</div>
                        <div id=""correctLabel"" class=""hide"" role=""alert"">Saved information</div>


                        <!--</form>-->
                    </div>
                </div>

                <div class=""col-md-offset-1 col-md-4 col-sm-12"">
                    <div class=""entry-form"">
                        <!--<form action=""#"" method=""post"">-->

                        <h2>Inicia sesión</h2>
                        <input type=""text"" name=""full name"" id=""name"" class=""form-control"" placeholder=""Nombre de usuario""");
                BeginWriteAttribute("required", " required=\"", 8213, "\"", 8224, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n                        <input type=\"password\" name=\"password\" id=\"password\" class=\"form-control\" placeholder=\"Contraseña\"");
                BeginWriteAttribute("required", " required=\"", 8352, "\"", 8363, 0);
                EndWriteAttribute();
                WriteLiteral(@">

                        <div>
                            <button class=""submit-btn form-control"" onclick=""return Add()"" id=""form-submit"">Iniciar sesión</button>
                        </div>


                        <div id=""incorrectLabel"" class=""hide"" role=""alert"">Error</div>
                        <div id=""correctLabel"" class=""hide"" role=""alert"">Saved information</div>


                        <!--</form>-->
                    </div>
                </div>

            </div>
        </div>
    </section>


   


    <!-- FOOTER -->
    <footer id=""footer"">
        <div class=""container"">
            <div class=""row"">

                <div class=""col-md-4 col-sm-6"">
                    <div class=""footer-info"">
                        <div class=""section-title"">
                            <h2>Dirección</h2>
                        </div>
                        <address>
                            <p>1.5 km al sur del parque de Paraíso,<br> Paraíso, Cartago Prov");
                WriteLiteral(@"ince, Costa Rica</p>
                        </address>

                        <div class=""copyright-text"">
                            <p>Copyright &copy; 2021</p>
                            <p>Design: ALDIFA Soft.</p>
                            <p>aldifasoft0@gmail.com</p>
                        </div>
                    </div>
                </div>

                <div class=""col-md-4 col-sm-6"">
                    <div class=""footer-info"">
                        <div class=""section-title"">
                            <h2>Contáctanos</h2>
                        </div>
                        <ul class=""social-icon"">
                            <li><a href=""https://www.facebook.com/asip.ucr/"" class=""fa fa-facebook-square"" attr=""facebook icon"" target=""_blank""></a></li>
                            <li><a href=""https://www.instagram.com/asip.ucr/"" class=""fa fa-instagram"" target=""_blank""></a></li>
                        </ul>
                        <address>
                    ");
                WriteLiteral(@"        <p>+506 2511-7550</p>
                            <p><a href=""mailto:youremail.co"">secretaria.rp@ucr.ac.cr</a></p>
                        </address>



                    </div>
                </div>

               

            </div>
        </div>
    </footer>


    <!-- SCRIPTS -->
    <script src=""js/jquery.js""></script>
    <script src=""js/bootstrap.min.js""></script>
    <script src=""js/owl.carousel.min.js""></script>
    <script src=""js/smoothscroll.js""></script>
    <script src=""js/custom.js""></script>
    <script src=""js/site.js""></script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
