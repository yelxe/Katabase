namespace Katabase

module SuperMarket =
    
    [<Measure>] type Volume

    [<Measure>] type mL
    [<Measure>] type L
    [<Measure>] type floz
    [<Measure>] type gal

    [<Measure>] type g
    [<Measure>] type Kg
    [<Measure>] type oz
    [<Measure>] type lb

    [<Measure>] type item

    type Unit<[<Measure>] 'u> = float<'u>

    type PricePerUnit<[<Measure>] 'u> = (float*float<'u>)

    let mLperL:float<mL/L> = 1000.0<mL/L>
    let gperKg:float<g/Kg> = 1000.0<g/Kg>

    let convertPrice (f:PricePerUnit<'m>) (t:Unit) =
        f

    //setPriceFor (2.25, 1.0<L>) |> ignore