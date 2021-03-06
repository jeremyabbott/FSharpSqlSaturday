﻿module Module6

// This compiles down to an enumeration
type Color =
| Red = 0
| Blue = 1
| Green = 2

printfn "%i" (int Color.Red)

// note that named union type fields is part of F# 3.1
// prior to this named union types used tuple syntax

// This compiles down to an abstract class with 
// three inner classes inheriting from it
type Shape =
| Circle of Radius : float
| Triangle of Base : float * Height : float
| Rectangle of Length : float * Height : float
    member x.getArea () = 
        match x with // pattern matching
        | Circle (r) -> (r ** 2.0) * System.Math.PI 
        | Triangle (b, h) -> 0.5 * (b * h)
        | Rectangle (l, h) -> l * h

let demoShape () =

    printfn "%s" "Discriminated Union (Shape) Info:"
        
    let circle = Shape.Circle(4.0)
    printfn "%A" (circle.getArea())

    let triangle = Shape.Triangle(3.0, 4.0)
    printfn "%A" (triangle.getArea())

    let rectangle = Shape.Rectangle(3.0, 4.0)
    printfn "%A" (rectangle.getArea())

[<Measure>] type foot
[<Measure>] type ft = foot
[<Measure>] type sqft = foot ^ 2
[<Measure>] type meter
[<Measure>] type m = meter
[<Measure>] type mSqrd = m ^ 2

// convert from unitless to units
let measuredInFeet = 15.0 * 1.0<ft>
let unitLess = 15.0<ft> / 1.0<ft>
let squarefeet = 15.0<foot> * 16.0<foot> // note the return type ends up being <ft ^ 2> even though I defined sqft

let getArea (b : int<ft>) (h : int<ft>) : int<sqft> = b * h

// let areaInMismatch = getArea 15<m> 16<m>

let areaInSqft = getArea 15<ft> 16<ft>

let getArea' (b : int<'u>) (h : int<'u>) : int<'u ^ 2> = b * h

let areaInSomeUnits = getArea' 15<m> 16<m>

[<Measure>] type inch =
                static member perFoot = 12.0<inch/foot>

let inchesPerFoot = 3.0<foot> * inch.perFoot

    

[<Measure>] type farenheit
[<Measure>] type celsius

let fromFarenheitToCelsius (f : float<farenheit>) = ((float f - 32.0) * (5.0/9.0)) * 1.0<celsius>
let fromCelsiusToFarenheit (c : float<celsius>) = ((float c * (9.0/5.0)) + 32.0) * 1.0<farenheit>
    
// Type extensions 
type farenheit with static member toCelsius = fromFarenheitToCelsius
                    static member fromCelsius = fromCelsiusToFarenheit
    
type celsius with   static member toFarenheit = fromCelsiusToFarenheit
                    static member fromFarenheit = fromFarenheitToCelsius

let printFToC () =
    let brrr = farenheit.toCelsius 35.0<farenheit>
    printfn "%A" brrr

let printCToF () =
    let brrr = celsius.toFarenheit 4.0<celsius>
    printfn "%A" brrr