module Day2

type Game = { Red: int; Blue: int; Green: int }

let day2Part1 allowed input =
    input
    |> makeLines
    |> Array.map (fun x ->
        x
        |> splitOn ":"
        |> (fun x -> x[0] |> splitOn " " |> (fun a -> a[1] |> int, x[1])))
    |> Array.map (fun (game, sets) -> game, sets |> splitOn ";")
    |> Array.map (fun (game, sets) ->
        game,
        ({ Red = 0; Blue = 0; Green = 0 }, sets)
        ||> Array.fold (fun acc set ->
            set
            |> (splitOn ",")
            |> Array.map (splitOn " ")
            |> Array.map (Array.filter (fun x -> x <> ""))
            |> fun x ->
                (acc, x)
                ||> Array.fold (fun acc x ->
                    match x[1] with
                    | "red" -> { acc with Red = acc.Red + int x[0] }
                    | "blue" -> { acc with Blue = acc.Blue + int x[0] }
                    | "green" -> { acc with Green = acc.Green + int x[0] }
                    | _ -> acc)))
    |> Array.filter (fun (_, sets) ->
        sets.Red <= allowed.Red
        && sets.Blue <= allowed.Blue
        && sets.Green <= allowed.Green)
    |> tap (fun x -> printfn "%A" x)
    |> Array.map fst
    |> Array.sum
