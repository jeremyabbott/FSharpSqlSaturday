module _3_Functions
    // f(x) = x + 2
    let add2 x = x + 2

    // Same function as above but with type annoations
    // Why is it add2' ("add two prime")?
    // Functions are values and are immutable (so no function overloading.
    let add2' (x : int) int = x + 2

    // Another function
    // Mouse over function name to see that it
    // x:string -> y:string -> string
    // Compiler infers that inputs are strings since they're passed to a string formatting function
    let saySomethingShort x y =
        sprintf "%s %s" x y // next line of func indented

    // annotated version of previous example
    let saySomethingShort' (x : string) (y : string) string =
        sprintf "%s %s" x y 