var data = require("./cards.json");
suitNames = ["Weapon","Beast","Land","Flood","Wizard","Artifact","Leader","Army","Flame","Weather","Wild",]
count = 0;
data = data.reduce((acc , suit, suitI) => acc.concat(suit.Cards.map((card, i) => {
    return {
        "Suit": suitNames[suitI],
        "Name": card.Name,
        "Value": card.Value,
        "Action": card.Action,
        "Penalty": card.Penalty,
        "Bonus": card.Bonus,
    }; 
})), []);

console.log(JSON.stringify(data,null,4));
