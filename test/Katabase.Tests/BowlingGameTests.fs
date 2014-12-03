namespace Katabase.Tests

open NUnit.Framework
open FsUnit
open Katabase.BowlingGame

module ``BowlingGame Tests`` =
    
    module ``Partial Games`` =
 
        [<Test>]
        let ``Two frames w/ no spares`` () =
            NewGame
            |> playFrame (3, 4)   //  0
            |> playFrame (2, 6)   //  0
            |> score
            |> should equal 15


        [<Test>]
        let ``Spare followed by score`` () =
            []
            |> playFrame (6, 4)   //  5
            |> playFrame (5, 2)   //  0
            |> score
            |> should equal 22

        [<Test>]
        let ``Strike followed by score`` () =
            []
            |> playFrame (10, 0)  //  7
            |> playFrame (3, 4)   //  0
            |> score
            |> should equal 24

//        [<Test>]
//        let ``Two strikes followed by score`` () =
//            []
//            |> playFrame (10, 0)  // 11
//            |> playFrame (10, 0)  //  3
//            |> playFrame (1, 2)   //  0
//            |> score
//            |> should equal 37
