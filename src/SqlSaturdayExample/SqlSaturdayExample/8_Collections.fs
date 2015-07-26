module _8_Collections

    // *********************************
    // Arrays
    // *********************************
    let array = [|1..100|]

    // *********************************
    // Lists
    // *********************************
    let list = List.init 100 (fun i -> i * i) // Initialize a list with squares of 1 - 100

    let head = List.head list
    let tail = List.tail list

    // cons oprator, add an element to the head of the list and return new list
    let list' = (101 * 101)::list

    // *********************************
    // Sequences (Any .NET Framework type that implements System.IEnumerable can be used as a sequence.)
    // *********************************

    // initialize a sequence with the squares of 1 - 10
    let seq = seq { for i in 1 .. 10 do yield i * i }