namespace Katabase.Tests

open NUnit.Framework
open FsUnit
open Katabase.BowlingGame

module ``BowlingGame Tests`` =
    
    module ``Partial Games`` =
 
        [<Test>]
        let ``Two frames w/ no spares`` () =
            (0, 0)
            |> frame (3, 4)         // 7
            |> frame (2, 6)         // 8
            |> should equal (15, 0)

        [<Test>]
        let ``Spare followed by score`` () =
            (0, 0)
            |> frame (6, 4)         // 15
            |> frame (5, 2)         // 7
            |> should equal (22, 0)

        [<Test>]
        let ``Strike followed by score`` () =
            (0, 0)
            |> frame (10, 0)        // 17
            |> frame (3, 4)         // 7
            |> should equal (24, 0)

        [<Test>]
        let ``Two strikes followed by score`` () =
            (0, 0)
            |> frame (10, 0)        // 21
            |> frame (10, 0)        // 13
            |> frame (1, 2)         // 3
            |> should equal (37, 0)
