module NumbersFloatingPointTests

open FsUnit.Xunit
open Xunit

open NumbersFloatingPoint

[<Fact>]
let ``Minimal first annual percentage yield``() = annualPercentageYield 0m |> should equal 0.5f

[<Fact>]
let ``Tiny first annual percentage yield``() = annualPercentageYield 0.000001m |> should equal 0.5f

[<Fact>]
let ``Maximum first annual percentage yield``() = annualPercentageYield 999.9999m |> should equal 0.5f

[<Fact>]
let ``Minimal second annual percentage yield``() = annualPercentageYield 1_000.0m |> should equal 1.621f

[<Fact>]
let ``Tiny second annual percentage yield``() = annualPercentageYield 1_000.0001m |> should equal 1.621f

[<Fact>]
let ``Maximum second annual percentage yield``() = annualPercentageYield 4_999.9990m |> should equal 1.621f

[<Fact>]
let ``Minimal third annual percentage yield``() = annualPercentageYield 5_000.0000m |> should equal 2.475f

[<Fact>]
let ``Tiny third annual percentage yield``() = annualPercentageYield 5_000.0001m |> should equal 2.475f

[<Fact>]
let ``Large third annual percentage yield``() = annualPercentageYield 5_639_998.742909m |> should equal 2.475f

[<Fact>]
let ``Minimal negative annual percentage yield``() = annualPercentageYield -0.000001M |> should equal -3.21300006f

[<Fact>]
let ``Small negative annual percentage yield``() = annualPercentageYield -0.123M |> should equal -3.21300006f

[<Fact>]
let ``Regular negative annual percentage yield``() = annualPercentageYield -300.0M |> should equal -3.21300006f

[<Fact>]
let ``Large negative annual percentage yield``() = annualPercentageYield -152964.231M |> should equal -3.21300006f

[<Fact>]
let ``Annual balance update for empty start balance``() = annualBalanceUpdate 0.0m |> should equal 0.0000m

[<Fact>]
let ``Annual balance update for small positive start balance``() =
    annualBalanceUpdate 0.000001m |> should equal 0.000001005m

[<Fact>]
let ``Annual balance update for average positive start balance``() =
    annualBalanceUpdate 1_000.0m |> should equal 1016.210000m

[<Fact>]
let ``Annual balance update for large positive start balance``() =
    annualBalanceUpdate 1_000.0001m |> should equal 1016.210101621m

[<Fact>]
let ``Annual balance update for huge positive start balance``() =
    annualBalanceUpdate 898124017.826243404425m |> should equal 920352587.26744292868451875m

[<Fact>]
let ``Annual balance update for small negative start balance``() =
    annualBalanceUpdate -0.123M |> should equal -0.12695199M

[<Fact>]
let ``Annual balance update for large negative start balance``() =
    annualBalanceUpdate -152964.231M |> should equal -157878.97174203M

[<Fact>]
let ``Years before desired balance for small start balance``() =
    yearsBeforeDesiredBalance 100.0m 125.80m |> should equal 47

[<Fact>]
let ``Years before desired balance for average start balance``() =
    yearsBeforeDesiredBalance 1_000.0m 1_100.0m |> should equal 6

[<Fact>]
let ``Years before desired balance for large start balance``() =
    yearsBeforeDesiredBalance 8_080.80m 9_090.90m |> should equal 5

[<Fact>]
let ``Years before desired balance for large difference between start and target balance``() =
    yearsBeforeDesiredBalance 2_345.67m 12_345.6789m |> should equal 85
