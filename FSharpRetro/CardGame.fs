namespace CardGame
module CardGameBoundedContext = 

    type Suit = Club | Diamond | Spade | Heart
                // | means a choice -- pick one from the list
                
    type Rank = Two | Three | Four | Five | Six | Seven | Eight 
                | Nine | Ten | Jack | Queen | King | Ace

    type Card = Suit * Rank   // * means a pair -- one from each type
    
    type Hand = Card list
    type Deck = Card list
    
    type Player = {Name:string; Hand:Hand}
    type Game = {Deck:Deck; Players: Player list}
    
    type Deal = Deck -> (Deck * Card) // X -> Y means a function
                                      // input of type X
                                      // output of type Y

    type PickupCard = (Hand * Card)-> Hand

module TestCardGameBoundedContext = 
    open CardGameBoundedContext

    let aceHearts  = (Heart, Ace)
    let aceSpades = (Spade, Ace)
    let twoClubs = (Club, Two)

    let myHand = [aceHearts; aceSpades; twoClubs]

    let deck = [aceHearts; aceSpades; twoClubs]

    let deal cards = 
        let head::tail = cards   // compiler has found a potential bug here!
        (tail, head)

    deal deck
