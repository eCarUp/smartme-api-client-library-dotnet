# ![smart-me logo](Doc/icons/logo.png) Api Client Library for .Net

The smart-me Api Client Library enables you to integrate smart-me API functionality into your .Net application. It makes HTTP requests to the smart-me REST API ([see here](https://smart-me.com/swagger)). All HTTP request and response bodies are mapped to .Net classes.

## Examples

First you need a smart-me login which you can create [here](https://web.smart-me.com/login/).

### Console Application using Basic Authentication

See the Console Application Example project in [`Src/Example`](Src/Example). Set your username and password in [`Credentials.json`](Src/Example/Credentials.json). Please keep your username and password private.

### Web Application using OAuth2 Authentication

See the Web Application Example project in [`Src/OAuthWebExample`](Src/OAuthWebExample). Set your OAuth2 client id and secret in [`appsettings.json`](Src/OAuthWebExample/appsettings.json). Contact us to provide you with a client id and secret. Please keep your client id and secret private.

### Web Application using Openid Connect Authentication of an external IdP (identity provider)

See the Web Application Example project in [`Src/OidcWebExample`](Src/OidcWebExample). Set your Openid Connect client id, secret and authority in [`appsettings.json`](Src/OidcWebExample/appsettings.json). See the [`description`](Doc/Okta.md) on how to setup an external Openid Connect identity provider using Okta. See the [`smart-me wiki`](http://wiki.smart-me.com/) on how to register the external Openid Connect identity provider.

## Requirements

- .Net Framework 4.7.2+
- .Net Core 2.1+