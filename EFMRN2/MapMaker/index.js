let output = [];
for(let j = 0; j<100; j++){
  output[j] = "new Tile { TileId = 1, X = 0, Y = 0, Z = 0, Transparent = true, Texture = 'floor', Method = 1)"
}
let translator = {  
  floor: "new Tile { TileId = 1, X = 0, Y = 0, Z = 0, Transparent = true, Texture = 'floor', Method = 1)",
  wall: "new Tile { TileId = 2, X = 0, Y = 0, Z = 0, Transparent = false, Texture = 'wall', Method = 1)",
  void: "new Tile { TileId = 3, X = 0, Y = 0, Z = 0, Transparent = false, Texture = 'void', Method = 1)",
  door: "new Tile { TileId = 4, X = 0, Y = 0, Z = 0, Transparent = true, Texture = 'door', Method = 2)",
  lockedDoor: "new Tile { TileId = 5, X = 0, Y = 0, Z = 0, Transparent = false, Texture = 'lockedDoor', Method = 2)",
  key: "new Tile { TileId = 6, X = 0, Y = 0, Z = 0, Transparent = true, Texture = 'key', Method = 3)",
  table: "new Tile { TileId = 7, X = 0, Y = 0, Z = 0, Transparent = false, Texture = 'table', Method = 1)",
  hole:"new Tile { TileId = 8, X = 0, Y = 0, Z = 0, Transparent = true, Texture = 'hole', Method = 2)",
  conveyerN: "new Tile { TileId = 9, X = 0, Y = 0, Z = 0, Transparent = true, Texture = 'conveyerN', Method = 4)",
  conveyerE: "new Tile { TileId = 10, X = 0, Y = 0, Z = 0, Transparent = true, Texture = 'conveyerE', Method = 5)",
  conveyerS: "new Tile { TileId = 11, X = 0, Y = 0, Z = 0, Transparent = true, Texture = 'conveyerS', Method = 6)",
  conveyerW: "new Tile { TileId = 12, X = 0, Y = 0, Z = 0, Transparent = true, Texture = 'conveyerW', Method = 7)",
  conveyerButton: "new Tile { TileId = 13, X = 0, Y = 0, Z = 0, Transparent = true, Texture = 'conveyerButton', Method = 8)",
  trapDoor: "new Tile { TileId = 14, X = 0, Y = 0, Z = 0, Transparent = true, Texture = 'trapDoor', Method = 9)",
  messageTile: "new Tile { TileId = 15, X = 0, Y = 0, Z = 0, Transparent = true, Texture = 'floor', Method = 10)",
  portalTile: "new Tile { TileId = 16, X = 0, Y = 0, Z = 0, Transparent = true, Texture = 'portal', Method = 2)",
  lavaTile: "new Tile { TileId = 17, X = 0, Y = 0, Z = 0, Transparent = true, Texture = 'lava', Method = 11)",
  spikePitTile: "new Tile { TileId = 18, X = 0, Y = 0, Z = 0, Transparent = true, Texture = 'skikePit', Method = 11)"
}
$(document).ready(function(){
$('#box > div').addClass('floor');
$('div#box').on('click','div', function(){
  output[parseInt($(this)[0].attributes[0].value)] = translator[$('#type').val()];
  $(this).removeClass();
  $(this).addClass($('#type').val());
});

$('#go').on('click', function(){
  $('#output').text('');
  let outputString ='[';
  for(let i = 0; i<10; i++){
    let midString = '[';
    for(let k = 0; k<10; k++){
      let x = i+(k*10)
      midString = midString + output[x] + ", ";
    }
    midString = midString.substring(0,midString.length-2);
    outputString = outputString + midString + '],';
  }
  outputString = outputString.substring(0,outputString.length-1);
  outputString = outputString + ']'
  $('#output').append(outputString);
});
});




// i need to take make the value of each square in the UI have the x 
// and y coordinate in it so that I can use that value when I am 
//generating the code for a level.  Maybe also have a select box for 
//which z value you want the level to have.  possible function for 
//adding connecting tiles for doors and holes.