module NumbersFloatingPoint

let annualPercentageYield (balance: decimal): single =
    if balance < 0.0m then
        -3.213f
    elif balance < 1000.0m then
        0.5f
    elif balance < 5000.0m then
        1.621f
    else
        2.475f
        
let private annualYield (balance: decimal): decimal =
    let multiplier =  decimal (annualPercentageYield balance) / 100.0m
    abs balance * multiplier
    
let annualBalanceUpdate (balance: decimal): decimal =
    balance + annualYield balance
    
let yearsBeforeDesiredBalance (balance: decimal) (targetBalance: decimal): int =
    let mutable accumulatingBalance = balance
    let mutable years = 0

    while accumulatingBalance < targetBalance do
        accumulatingBalance <- annualBalanceUpdate accumulatingBalance
        years <- years + 1

    years
   