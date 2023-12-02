module Day1

open System
open System.Text.RegularExpressions

let words =
    [| "one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight"; "nine" |]

let makeLines (input: string) =
    input.Split(new string (Environment.NewLine))

let splitOn (splitter: string) (input: string) =
    input.Split([| splitter |], StringSplitOptions.None)

let wordToNum =
    function
    | "one" -> "1"
    | "two" -> "2"
    | "three" -> "3"
    | "four" -> "4"
    | "five" -> "5"
    | "six" -> "6"
    | "seven" -> "7"
    | "eight" -> "8"
    | "nine" -> "9"
    | x -> x

let splitOnWords (input: string) =
    let rec insertAux (currentIndex: int) (acc: string) =
        if currentIndex >= input.Length then
            acc
        else
            match
                words
                |> Array.tryFind (fun word -> input.Substring(currentIndex).StartsWith(word))
            with
            | Some word ->
                let digit = wordToNum word
                let nextIndex = currentIndex + word.Length
                let newAcc = acc + digit + word
                insertAux nextIndex newAcc
            | None ->
                let newAcc = acc + string input[currentIndex]
                insertAux (currentIndex + 1) newAcc

    insertAux 0 ""


let toChars (input: string) = input.ToCharArray()

let tap f x =
    f x
    x

let tryParse (x: char) =
    match Int32.TryParse(x.ToString()) with
    | true, result -> Some result
    | false, _ -> None

let day1Part1 input =
    input
    |> makeLines
    |> Array.map toChars
    |> Array.map (Array.map tryParse)
    |> Array.map (Array.choose id)
    |> Array.map (fun x ->
        match x |> Array.length with
        | y when y > 1 -> [| x |> Array.head |> string; x |> Array.last |> string |]
        | _ -> [| x |> Array.head |> string; x |> Array.head |> string |])
    |> Array.map (String.concat "")
    |> Array.map int
    |> Array.sum

let day1Part2 input =
    input
    |> makeLines
    |> Array.map splitOnWords
    |> tap (printfn "%A")
    |> Array.map toChars
    |> Array.map (Array.map tryParse)
    |> Array.map (Array.choose id)
    |> tap (printfn "%A")
    |> Array.map (fun x ->
        match x |> Array.length with
        | y when y > 1 -> [| x |> Array.head |> string; x |> Array.last |> string |]
        | _ -> [| x |> Array.head |> string; x |> Array.head |> string |])
    |> tap (printfn "%A")
    |> Array.map (String.concat "")
    |> Array.map int
    |> tap (printfn "%A")
    |> Array.sum
