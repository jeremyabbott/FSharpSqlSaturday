open Owin

open System.Collections.Generic
open System.Net.Http
open System.Web.Http
open Microsoft.Owin.Hosting

open Module1
open Module4
// This is a class
type Startup() =
    member this.Configuration(appBuilder : IAppBuilder) = // type annotation
        let config = new  HttpConfiguration()
        let route = config.Routes.MapHttpRoute("DefaultApi","api/{controller}/{id}")
        route.Defaults.Add("id", RouteParameter.Optional)
        appBuilder.UseWebApi(config) |> ignore // what are we ignoring?

type ValuesController() =
    inherit ApiController()
    member this.Get() = // this is an action
        [|"value1"; "value2"|] // string[]

[<EntryPoint>] // this is an attribute
let main argv = 
    let baseAddress = "http://localhost:9000"

    // the use binding will dispose of server when we go out of scope.
    use server = WebApp.Start<Startup>(baseAddress)
    let client = new HttpClient() // only need to use the new keyword with IDisposable types
    let response = // mixing a tupled method call with an F# function call
        client.GetAsync(sprintf "%s/%s" baseAddress "api/values").Result
    printfn "%A" response // response is some object so %A just formats any object
    // we're getting a string back so the format argument is %s
    printfn "%s" (response.Content.ReadAsStringAsync().Result)
    
    // Module1.runModule1Example client baseAddress
    // Module4.demoShape () |> ignore
    
    0 // return an integer exit code