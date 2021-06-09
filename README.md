# ASP.NET Core and Vue.js

<a href="https://www.packtpub.com/product/asp-net-core-and-vue-js/9781800206694?utm_source=github&utm_medium=repository&utm_campaign=9781800206694"><img src="https://static.packt-cdn.com/products/9781800206694/cover/smaller" alt="ASP.NET Core and Vue.js" height="256px" align="right"></a>

This is the code repository for [ASP.NET Core and Vue.js](https://www.packtpub.com/product/asp-net-core-and-vue-js/9781800206694?utm_source=github&utm_medium=repository&utm_campaign=9781800206694), published by Packt.

**Build real-world, scalable, full-stack applications using Vue.js 3, TypeScript, .NET 5, and Azure**

## What is this book about?
Vue.js 3 is faster and smaller than the previous version, and TypeScript’s full support out of the box makes it a more maintainable and easier-to-use version of Vue.js. Then, there's ASP.NET Core 5, which is the fastest .NET web framework today. Together, Vue.js for the frontend and ASP.NET Core 5 for the backend make a powerful combination. This book follows a hands-on approach to implementing practical methodologies for building robust applications using ASP.NET Core 5 and Vue.js 3. The topics here are not deep dive and the book is intended for busy .NET developers who have limited time and want a quick implementation of a clean architecture with popular libraries. 

This book covers the following exciting features:
* Discover CQRS and mediator patterns in the ASP.NET Core 5 web API
* Use Serilog, MediatR, FluentValidation, and Redis in ASP.NET
* Explore common Vue.js packages such as Vuelidate, Vuetify, and Vuex
* Manage complex app states using the Vuex state management library
* Write integration tests in ASP.NET Core using xUnit and FluentAssertions
* Deploy your app to Microsoft Azure using the new GitHub Actions for continuous integration and continuous deployment (CI/CD)

If you feel this book is for you, get your [copy](https://www.amazon.com/dp/1800206690) today!

<a href="https://www.packtpub.com/?utm_source=github&utm_medium=banner&utm_campaign=GitHubBanner"><img src="https://raw.githubusercontent.com/PacktPublishing/GitHub/master/GitHub.png" 
alt="https://www.packtpub.com/" border="5" /></a>

## Instructions and Navigations
All of the code is organized into folders. For example, Chapter02.

The code will look like the following:
```
public void Configure(IApplicationBuilder app,
IWebHostEnvironment env)
{
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
endpoints.MapGet("/", async context =>
{
await context.Response.WriteAsync("Hello Packt!");
}).AllowAnonymous();
});
}
```

**Following is what you need for this book:**
This app development book is for .NET developers who want to get started with Vue.js and build full-stack real-world enterprise web applications. Developers looking to build a proof-of-concept application quickly and pragmatically using their existing knowledge of ASP.NET Core as well as developers who want to write readable and maintainable code using TypeScript and the C# programming language will also find this book useful. The book assumes intermediate-level .NET knowledge along with an understanding of C# programming, JavaScript, and ECMAScript

With the following software and hardware list you can run all code files present in the book (Chapter 1-19).
### Software and Hardware List
| Chapter | Software required | OS required |
| -------- | ------------------------------------ | ----------------------------------- |
| 3-19 | Visual Studio Code | Windows, Mac OS X, and Linux (Any) |
| 3-19 | Visual Studio 2019 | Windows, Mac OS X, and Linux (Any) |
| 3-19 | Rider | Windows, Mac OS X, and Linux (Any) |
| 3-19 | .NET 5.0 | Windows, Mac OS X, and Linux (Any) |
| 3-19 | Node.js and Node Package Manager | Windows, Mac OS X, and Linux (Any) |
| 3-19 | Postman | Windows, Mac OS X, and Linux (Any) |
| 3-19 | Vue.js DevTools | Windows, Mac OS X, and Linux (Any) |
| 3-19 | Vue.js DevTools (Firefox Browser Addadd-ons): | Windows, Mac OS X, and Linux (Any) |
| 3-19 | DB Browser for SQLite | Windows, Mac OS X, and Linux (Any) |
| 3-19 | SQLiteStudioSQLite Studio | Windows, Mac OS X, and Linux (Any) |
| 3-19 | Git source control | Windows, Mac OS X, and Linux (Any) |

We also provide a PDF file that has color images of the screenshots/diagrams used in this book. [Click here to download it](https://static.packt-cdn.com/downloads/9781800206694_ColorImages.pdf).

### Related products
* Vue.js 3 By Example [[Packt]](https://www.packtpub.com/product/vue-js-3-by-example/9781838826345?utm_source=github&utm_medium=repository&utm_campaign=9781838826345) [[Amazon]](https://www.amazon.com/dp/1838826343)

* Blazor WebAssembly by Example [[Packt]](https://www.packtpub.com/product/blazor-webassembly-by-example/9781800567511?utm_source=github&utm_medium=repository&utm_campaign=9781800567511) [[Amazon]](https://www.amazon.com/dp/1800567510)

## Get to Know the Author
**Devlin Duldulao**
is a full-stack engineer with over eight years of web, mobile, and cloud development experience. He has been a recipient of Microsoft's Most Valuable Professional (MVP since 2018) and earned the title of Auth0 ambassador for his passion for sharing best practices in application securities. Devlin has passed some prestigious exams in software and cloud development such as MSCD, Azure Associate Developer, AWS Associate Developer, and Terraform Associate.
Perhaps it was serendipity that made him venture into the coding world after a short stint in the medical field, however, once he stepped into it, he fell for it hook, line and sinker – but in the right way, he claims. Devlin often finds himself engrossed in solving coding problems and developing apps, even to the detriment of his once-active social life.
One of the things that motivate him is ensuring the long-term quality of his code, including looking into ways to transform legacy code into more maintainable and scalable applications.
Devlin enjoys tackling challenging projects or applications for high-level clients and customers, as he currently does at his company based in Norway. He also provides training and consultation for international corporations.
One of his other interests is giving talks at IT conferences worldwide and meeting unique people in the industry.
Devlin is currently based in Oslo, Norway, with his wife. He is a senior software engineer at Inmeta Consulting Company, a subsidiary of the Crayon Group of Companies

