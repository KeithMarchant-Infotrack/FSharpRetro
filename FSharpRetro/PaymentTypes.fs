module PaymentTypes

    type CardType = CardType of string
    type CardNumber = CardNumber of string

    type PaymentMethod = 
        | Cash
        | Cheque of string
        | Card of CardType * CardNumber
    
    let printPayment paymentMethod = 
        match paymentMethod with
        | Cash -> 
            printfn "Paid in cash"
        | Cheque chequeNo ->
            printfn "Paid by cheque: %s" chequeNo
        | Card (cardType,cardNo) ->
            printfn "Paid with %A %A" cardType cardNo

    let cashPayment = Cash
    let chequePayment  = Cheque "999"
    let cardPayment  = Card (CardType "Visa",CardNumber "123")
    
    printPayment cashPayment
    printPayment chequePayment
    printPayment cardPayment

