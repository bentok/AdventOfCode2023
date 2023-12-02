module Program

open System.IO
open Day1

let main () =
    let d1p1, d1p2 =
        let input =
            Path.Combine(Directory.GetCurrentDirectory(), "Input/Day1Input.txt")
            |> File.ReadAllText
        
        day1Part1 input, day1Part2 input
    
    printfn "Day1 Part 1: %A" d1p1
    printfn "Day1 Part 2: %A" d1p2