var cards = require("./cards.json");

cards = cards.filter(card => card.Bonus !== undefined);

console.log(JSON.stringify(cards,null,4));
console.log(cards.length);
