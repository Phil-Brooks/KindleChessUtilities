open KindleChess

[<EntryPoint>]
let main args =
    if args.Length<>4 then
        System.Console.WriteLine("Syntax error: need to pass 4 arguments to this program.")
        System.Console.WriteLine("First argument is full name and path to pgn file.")
        System.Console.WriteLine("Second argument is path to Templates folder.")
        System.Console.WriteLine("Third argument is path to Images folder.")
        System.Console.WriteLine("Fourth argument is path to Output folder.")
        System.Console.WriteLine("Example usage: KindleChessCmd \"D:\GitHub\KindleChessUtils\Sample\Inputs\Grob.pgn\" \"D:\GitHub\KindleChessUtils\Sample\Inputs\Templates\" \"D:\GitHub\KindleChessUtils\Sample\Inputs\Images\" \"D:\GitHub\KindleChessUtils\Sample\Outputs\"")
        -1
    else
        let pgn = args.[0]
        let tfol = args.[1]
        let ifol = args.[2]
        let ofol = args.[3]
        let str = Book.genh pgn tfol ifol ofol
        // Return 0. This indicates success.
        0