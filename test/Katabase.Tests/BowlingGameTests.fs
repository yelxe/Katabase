namespace Katabase.Tests

open NUnit.Framework
open FsUnit
open Katabase.BowlingGame

module ``BowlingGame Tests`` =
    
    let gutter _ = (0, 0)
    let spare n _ = (n, 10 - n)
    let strike _ = (10, 0)

    let playFor f n = List.init n f
    
    module ``Partial Games`` =
        
        [<Test>]
        let ``Two frames w/ no spares`` () =
            NewGame
            |> List.append(playFor gutter 8)
            |> playFrame (3, 4)   //  0
            |> playFrame (2, 6)   //  0
            |> score
            |> should equal 15

        [<Test>]
        let ``Spare followed by score`` () =
            NewGame
            |> List.append(playFor gutter 8)
            |> playFrame (6, 4)   //  5
            |> playFrame (5, 2)   //  0
            |> score
            |> should equal 22

        [<Test>]
        let ``Strike followed by score`` () =
            NewGame
            |> List.append(playFor gutter 8)
            |> playFrame (10, 0)  //  7
            |> playFrame (3, 4)   //  0
            |> score
            |> should equal 24

        [<Test>]
        let ``Two strikes followed by score`` () =
            NewGame
            |> List.append(playFor gutter 7)
            |> playFrame (10, 0)  // 11
            |> playFrame (10, 0)  //  3
            |> playFrame (1, 2)   //  0
            |> score
            |> should equal 37

    module ``Complete Games`` =
        
        [<Test>]
        let ``Perfect Game`` () =
            NewGame
            |> List.append(playFor strike 12)  // 200
            |> score
            |> should equal 300
            
        [<Test>]
        let ``All Spares`` () =
            NewGame
            |> List.append(playFor (spare 5) 10)  // 47
            |> playFrame (2, 0)
            |> score
            |> should equal 147
