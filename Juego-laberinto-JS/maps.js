/*
 * Reglas:
 * El final de cada nivel debe ser el inicio del siguiente
*/

const emojis = {
  '-': ' ',
  'O': '🚪',
  'X': '💣',
  'I': '🎁',
  'PLAYER': '💀',
  'BOMB_COLLISION': '🔥',
  'GAME_OVER': '👎',
  'WIN': '🏆',
};

const maps = [];
maps.push(`
  IXXXXXXXXX
  -XXXXXXXXX
  -XXXXXXXXX
  -XXXXXXXXX
  -XXXXXXXXX
  -XXXXXXXXX
  -XXXXXXXXX
  -XXXXXXXXX
  -XXXXXXXXX
  OXXXXXXXXX
`);
maps.push(`
  O--XXXXXXX
  X--XXXXXXX
  XX----XXXX
  X--XX-XXXX
  X-XXX--XXX
  X-XXXX-XXX
  XX--XX--XX
  XX--XXX-XX
  XXXX---IXX
  XXXXXXXXXX
  `);
maps.push(`
  I-----XXXX
  XXXXX-XXXX
  XX----XXXX
  XX-XXXXXXX
  XX-----XXX
  XXXXXX-XXX
  XX-----XXX
  XX-XXXXXXX
  XX-----OXX
  XXXXXXXXXX
`);
maps.push(`
  I-----XXXX
  X-XXX-XXXX
  X--XX-XXXX
  XX-XXXXXXX
  XX-----XXX
  XXXX-XXXXX
  XX-----XXX
  XXXX-XXXXX
  XX-----XXX
  XXXXXX-XXX
`);
maps.push(`
  I---------
  --XXX-XXX-
  ---XX-XXX-
  -X-XXXXXX-
  -X-----XX-
  -XXX-XXXX-
  -X-----XX-
  -XXX-XXXX-
  -X-----XX-
  ----XX-XX-
`);