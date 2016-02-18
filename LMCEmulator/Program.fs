// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
// return an integer exit code
module Program

module IntegerLMC = 
    // LMC integer type. Range: -999 to 999, wraps around.
    type T = 
        | IntegerLMC of int
        static member op_Explicit (source : T) : int = 
            let (IntegerLMC n) = source in n
    
    let rec create (n : int) = 
        match n with
        | n when n > 999 -> create (n - 1999)
        | n when n < -999 -> create (n + 1999)
        | n -> IntegerLMC n

module Program = 
    let ram = [| for _ in 1 .. 100 -> IntegerLMC.create 0 |]
    let ram' : IntegerLMC.T array = Array.zeroCreate 100
    let accumulator = 0
    
    let testIntegerLMC = 
        let a = IntegerLMC.create 2998
        let b = IntegerLMC.create 999
        let c = IntegerLMC.create 1000
        printfn "a\t2999\t%A" a
        printfn "b\t999\t%A" b
        printfn "c\t1000\t%A" c
        printfn "a + 2000\t%A" (int a + 2000)
    
    [<EntryPoint>]
    let main argv = 
        printfn "%A" argv
        printfn "ram: %A" ram
        printfn "ram': %A" ram'
        printfn "accumulator: %A" accumulator
        testIntegerLMC
        0
