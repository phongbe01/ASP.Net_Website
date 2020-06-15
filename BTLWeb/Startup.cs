using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BTLWeb.Startup))]
namespace BTLWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
