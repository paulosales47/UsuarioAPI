using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace UsuarioAPI.Test.SpecFlow.Steps
{
    [Binding]
    public sealed class UsuarioSteps
    {
        [Given(@"que a url do endpoint é http://localhost:27174/api/Usuario/Get/(.*)")]
        public void DadoQueAUrlDoEndpointEHttpLocalhostApiUsuarioGet(string url)
        {
            ScenarioContext.Current["Endpoint"] = url;
        }

        [Given(@"o metodo é '(.*)'")]
        public void DadoOMetodoE(string url)
        {
            ScenarioContext.Current["Endpoint"] = url;
        }


    }
}
