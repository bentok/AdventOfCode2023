module Tests

open System.IO
open Xunit
open FsUnit
open Day1

[<Fact>]
let ``Day 1 Part 1`` () =
    let result =
        Path.Combine(Directory.GetCurrentDirectory(), "Input/Day1TestInput.txt")
        |> File.ReadAllText
        |> day1Part1
    
    result |> should equal 142

[<Fact>]
let ``Day 1 Part 2`` () =
    let result =
        Path.Combine(Directory.GetCurrentDirectory(), "Input/Day1TestInput2.txt")
        |> File.ReadAllText
        |> day1Part2
    
    result |> should equal 281