class Gift {
  constructor(order, id, giftName, attacker, target, damage, from, to, diamondCount) {
    this.order = order;
    this.id = id;
    this.name = giftName;
    this.attacker = attacker;
    this.target = target;
    this.damage = damage;
    this.from = from;
    this.to = to;
    this.diamondCount = diamondCount;
  }
}

const giftConfig = [
  // ronaldo attacks messi
  new Gift(1, 5655, "Gift 1", "Ronaldo", "Messi", 0.01, 0, 0, 1),
  new Gift(2, 6064, "Gift 2", "Ronaldo", "Messi", 0.01, 0, 0, 1),
  new Gift(3, 37, "Gift 3", "Ronaldo", "Messi", 0.1, 0, 0, 5),
  new Gift(4, 8913, "Gift 4", "Ronaldo", "Messi", 0.25, 0, 0, 10),
  new Gift(5, 5879, "Gift 5", "Ronaldo", "Messi", 0.4, 0, 0, 30),
  new Gift(6, 5585, "Gift 6", "Ronaldo", "Messi", 3, 0, 0, 100),
  new Gift(7, 12356, "Gift 7", "Ronaldo", "Messi", 0, 0.15, 0.2, 9),

  // messi attacks ronaldo
  new Gift(8, 5760, "Gift 8", "Messi", "Ronaldo", 0.01, 0, 0, 1),
  new Gift(9, 5269, "Gift 9", "Messi", "Ronaldo", 0.01, 0, 0, 1),
  new Gift(10, 5487, "Gift 10", "Messi", "Ronaldo", 0.1, 0, 0, 5),
  new Gift(11, 5853, "Gift 11", "Messi", "Ronaldo", 0.25, 0, 0, 10),
  new Gift(12, 5492, "Gift 12", "Messi", "Ronaldo", 0.4, 0, 0, 30),
  new Gift(13, 7264, "Gift 13", "Messi", "Ronaldo", 3, 0, 0, 100),
  new Gift(14, 8243, "Gift 14", "Messi", "Ronaldo", 0, 0.15, 0.2, 9),

  // random
  new Gift(15, 9139, "Gift 15", "Random", "Random", 0, 0.01, 0.08, 2),
];

module.exports = giftConfig;
