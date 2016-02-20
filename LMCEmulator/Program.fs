// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
// return an integer exit code
module Program

open LMCTypes

// Memory locations
let memory = 
    [| for _ in 1..100 -> IntegerLMC.create 0 |]

// Store result of last operation.
//let accumulator = 0Z
// Store address of next instruction to perform.
//let programCounter = 0Z
//let instructionRegister = "0"
//let addressRegister = "00"
let testIntegerLMC = 
    let a = 2998Z
    let b = 999Z
    let c = 1000Z
    printfn "a\t2999\t%A" a
    printfn "b\t999\t%A" b
    printfn "c\t1000\t%A" c
    a + IntegerLMC.create 2000
    |> IntegerLMC.toString
    |> printfn "a + 2000\t%A"

let addAccumulator accumulator address = accumulator + memory.[address]
let subAccumulator accumulator address = accumulator - memory.[address]
let storeInMemory = Array.set memory

let executeOpCode i a = 
    match i with
    // opcodes
    | 0 -> Some 1Z
    | 1 -> Some 1Z
    | 2 -> Some 1Z
    | 3 -> Some 1Z
    // Catch invalid inputs.
    | _ -> None

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    printfn "memory: %A" memory
    //    printfn "accumulator: %A" accumulator
    testIntegerLMC
    printf "Input: "
    let x = 
        try 
            System.Console.ReadLine()
            |> int
            |> IntegerLMC.create
            |> Some
        with :? System.FormatException -> 
            printfn "Not an integer!"
            None
    0
