namespace LMCTypes

module IntegerLMC =

    // LMC integer type. Range: -999 to 999, wraps around.
    type T = 
        | IntegerLMC of int

    // Functional constructor.
    // Always use this to prevent illegal values being created.
    let rec create i = 
        match i with
        | i when i > 999 -> create (i - 1999)
        | i when i < -999 -> create (i + 1999)
        | i -> IntegerLMC i

    // Functional conversions.
    let toInt32 (IntegerLMC i) : int32 = i
    let toString (IntegerLMC i) : string = i.ToString()

    // Attach as members.
    type T with
        member this.ToInt32 = toInt32 this
        member this.ToString = toString this

    // Infix operators.
    type T with
        static member (+) (IntegerLMC a, IntegerLMC b) = create (a + b)
        static member (-) (IntegerLMC a, IntegerLMC b) = create (a - b)
        static member (*) (IntegerLMC a, IntegerLMC b) = create (a * b)
        static member (/) (IntegerLMC a, IntegerLMC b) = create (a / b)

    // Functional operators.
    let add a b : T = a + b
    let subtract a b : T = a - b
    let multiply a b : T = a * b
    let divide a b : T = a / b

// Literal syntax for IntegerLMC
// eg. "let a = 34Z" is equivalent to let "a = IntegerLMC.create 34"
module NumericLiteralZ =
    let FromZero () = IntegerLMC.IntegerLMC 0
    let FromOne () = IntegerLMC.IntegerLMC 1
    let FromInt32 i = IntegerLMC.create i