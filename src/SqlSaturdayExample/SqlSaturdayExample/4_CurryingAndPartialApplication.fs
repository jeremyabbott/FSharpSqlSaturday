module _4_CurryingAndPartialApplication

    // non curried function
    let saySomethingShort x y =
        sprintf "%s %s" x y

    // curried function
    // If you compare the functions they have the same signature
    let saySomethingShort' x =
        (fun y -> sprintf "%s %s" x y) // lambda evaluates and result is returned

    // Partially applied function
    // the result of passing "hello" to saySomethingShort is a function that accepts a string
    let sayHelloTo = saySomethingShort "Hello"
    printfn "%s" (sayHelloTo "World") // Hello World

    // Practical Partial Application
    // Array.Filter accepts a function to use for filtering and the array to filter
    // If we don't pass the array then we get a function that accepts an array as its last argument
    let filterByName name = Array.filter (fun i -> i = name)

    // Pipe the array as the last argument to filterByName
    let result = [|"Dick";"Jane"|] |> filterByName "Jane"

    // More piping
    let isEven x = x % 2 = 0

    let sumOfEvens args =
        args
        |> Array.filter isEven
        |> Array.sum

    let sum = sumOfEvens [|1..100|] // Initialize an array of 1 to 100