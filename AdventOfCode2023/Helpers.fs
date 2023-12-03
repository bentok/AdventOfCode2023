[<AutoOpen>]
module Helpers

open System

let makeLines (input: string) =
    input.Split(new string (Environment.NewLine))

let splitOn (splitter: string) (input: string) =
    input.Split([| splitter |], StringSplitOptions.None)

let tap f x =
    f x
    x