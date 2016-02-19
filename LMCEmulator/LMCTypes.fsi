namespace LMCTypes

module IntegerLMC = 
    type T = 
        | IntegerLMC of int
        member ToInt32 : int32
        member ToString : string
        static member (+) : T * T -> T
        static member (-) : T * T -> T
        static member (*) : T * T -> T
        static member (/) : T * T -> T
    
    val create : i:int -> T
    val toInt32 : T -> int32
    val toString : T -> string
    val add : a:T -> b:T -> T
    val subtract : a:T -> b:T -> T
    val multiply : a:T -> b:T -> T
    val divide : a:T -> b:T -> T

module NumericLiteralZ = 
    val FromZero : unit -> IntegerLMC.T
    val FromOne : unit -> IntegerLMC.T
    val FromInt32 : i:int -> IntegerLMC.T
