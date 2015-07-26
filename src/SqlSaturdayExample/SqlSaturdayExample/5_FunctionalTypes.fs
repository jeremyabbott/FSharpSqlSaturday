module _5_FunctionalTypes

    // ============================
    // Unit
    // ============================
    
    let sayHelloWorld () = printfn "Hello World"

    let add x y =
        let result = x + y
        () // ineplicably returning unit

    let add' x y =
        x + y |> ignore // inexplicably ignoring the result (ignore is a function that accepts T and returns unit)

    // ============================
    // Tuples
    // ============================

    let point = 1, 2 // int * int
    let x = fst point // get the first value
    let y = snd point // get the second value

    // fst and snd only work on "pairs" or tuples with only two vaues

    // A tuple pattern lets you assign 
    // explicit values from a tuple 
    let x', y' = point

    // ============================
    // Record Types
    // ============================

    // Simple record type
    type Person =
        { FirstName : string; LastName : string }
    let someone =
        {   FirstName = "Jeremy";
            LastName = "Abbott" }

    // copy everything and update first name
    let updateFirstName person firstName =
        { person with FirstName = firstName }

    let updatedPerson = updateFirstName someone "John"

    // Record type with a method on it
    type pointRecord = { XCoord : int; YCoord : int}
                        override x.ToString() =
                            sprintf "x coord: %i; y coord: %i" x.XCoord x.YCoord
                        member x.CalculateDistance(otherCoord : pointRecord) =
                            let xDiff = otherCoord.XCoord - x.XCoord
                            let yDiff = otherCoord.YCoord - x.YCoord
                            let result =  ((xDiff * xDiff) + (yDiff * yDiff))
                            int (sqrt (float result))