module Tests

open System.IO
open Xunit
open FsUnit
open Day1
open Day2

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


[<Fact>]
let ``Day 2 Part 1`` () =
    let result =
        Path.Combine(Directory.GetCurrentDirectory(), "Input/Day2TestInput1.txt")
        |> File.ReadAllText
        |> day2Part1 { Red = 12; Blue = 13; Green = 14 }
    
    result |> should equal 8