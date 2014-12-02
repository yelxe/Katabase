namespace Katabase.Tests

open NUnit.Framework
open FsUnit
open Katabase.BowlingGame

module ``BowlingGame Tests`` =
    
    module ``Partial Games`` =
 
        [<Test>]
        let ``Two frames w/ no spares`` () =
            (0, 0)
            |> frame (3, 4)   //  0
            |> frame (2, 6)   //  0
            |> should equal (15, 0)

        [<Test>]
        let ``Spare followed by score`` () =
            (0, 0)
            |> frame (6, 4)   //  5
            |> frame (5, 2)   //  0
            |> should equal (22, 0)

        [<Test>]
        let ``Strike followed by score`` () =
            (0, 0)
            |> frame (10, 0)  //  7
            |> frame (3, 4)   //  0
            |> should equal (24, 0)

        [<Test>]
        let ``Two strikes followed by score`` () =
            (0, 0)
            |> frame (10, 0)  // 11
            |> frame (10, 0)  //  3
            |> frame (1, 2)   //  0
            |> should equal (37, 0)
