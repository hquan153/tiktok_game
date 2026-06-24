class Gift {
  constructor(order, giftName, attacker, target, damage, diamondCount) {
    this.order = order;
    this.giftName = giftName;
    this.attacker = attacker;
    this.target = target;
    this.damage = damage;
    this.winTimes = Math.floor(damage);
    this.diamondCount = diamondCount;
  }
}

const giftConfig = [
  // ronaldo attacks messi
  new Gift(1, "GG", "Ronaldo", "Messi", 0.01, 1),
  new Gift(2, "Rosa", "Ronaldo", "Messi", 0.1, 10),
  new Gift(3, "Confetti", "Ronaldo", "Messi", 5, 100),

  // messi attacks ronaldo
  new Gift(4, "Rose", "Messi", "Ronaldo", 0.01, 1),
  new Gift(5, "Lucky Pig", "Messi", "Ronaldo", 0.1, 10),
  new Gift(6, "Mini Star", "Messi", "Ronaldo", 5, 100),
];

module.exports = giftConfig;

/* [
  Gift {
    order: 1,
    id: 6064,
    name: 'GG',
    attacker: 'Ronaldo',
    target: 'Messi',
    damage: 0.01,
    diamondCount: 1
  },
  Gift {
    order: 2,
    id: 8913,
    name: 'Rosa',
    attacker: 'Ronaldo',
    target: 'Messi',
    damage: 0.1,
    diamondCount: 10
  },
  Gift {
    order: 3,
    id: 0,
    name: 'Confetti',
    attacker: 'Ronaldo',
    target: 'Messi',
    damage: 5,
    diamondCount: 100
  },

  Gift {
    order: 4,
    id: 5655,
    name: 'Rose',
    attacker: 'Messi',
    target: 'Ronaldo',
    damage: 0.01,
    diamondCount: 1
  },
  Gift {
    order: 5,
    id: 0,
    name: 'Lucky Pig',
    attacker: 'Messi',
    target: 'Ronaldo',
    damage: 0.1,
    diamondCount: 10
  },
  Gift {
    order: 6,
    id: 0,
    name: 'Mini Star',
    attacker: 'Messi',
    target: 'Ronaldo',
    damage: 5,
    diamondCount: 100
  }
] */
