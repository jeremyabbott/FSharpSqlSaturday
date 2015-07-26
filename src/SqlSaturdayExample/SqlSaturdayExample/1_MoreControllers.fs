module Module1

open System.Web.Http
open System.Net.Http

// Discriminated Union
type Breed =
    | Siamese = 1
    | Persian = 2

// Record Type
type Cat = {Name : string; Breed : Breed }

type RecordsController() =
    inherit ApiController()
        member this.Get() =
            let cat1 = {Name = "Rowdy"; Breed = Breed.Persian }
            let cat2 = {Name = "Tinker"; Breed = Breed.Siamese }
            [cat1; cat2]

let runModule1Example (client : HttpClient) baseAddress =
    let response' = client.GetAsync(sprintf "%s/%s" baseAddress "api/Records").Result
    printfn "%s" (response'.Content.ReadAsStringAsync().Result)