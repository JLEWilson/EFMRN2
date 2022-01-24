let output = [];
for(let j = 0; j<100; j++){
  output[j] = "new Tile(true, 'white')"
}
let translator = {
  door: "new Door(true,'door',x,y,z)",
  floor: "new Tile(true, 'white')",
  wall: "new Tile(false, 'black')",
  void: "new Tile(false, 'void')",
  lockedDoor: "new LockedDoor(false,'lockedDoor',x,y,z)",
  key: "new Key(true,'key',x,y,z,message)",
  table: "new Tile(false,'table')",
  hole:"new Hole(true,'hole')",
  conveyerN: "new Conveyer(true,'white','N')",
  conveyerE: "new Conveyer(true,'white','E')",
  conveyerS: "new Conveyer(true,'white','S')",
  conveyerW: "new Conveyer(true,'white','W')",
  conveyerButton: "new ConveyerButton(true,'white',x,y,z)",
  trapDoor: "new TrapDoor(true,'white',x,y,z)",
  messageTile: "new MessageTile(true,'white',message)",
  portalTile: "new PortalTile(true,'white','portal')",
  lavaTile: "new LavaTile(true,'white','lava')",
  spikePitTile: "new spikePitTile(true,'white','spikePit')",
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

// let output = [];
// for(let j = 0; j<100; j++){
//   output[j] = "new TilePosition {TilePositionId = 1, TileId=2, x=0,y=6,z=0}"
// }
// let translator = {
//   door: "new Door(true,'door',x,y,z)",
//   floor: "new Tile(true, 'white')",
//   wall: "new Tile(false, 'black')",
//   void: "new Tile(false, 'void')",
//   lockedDoor: "new LockedDoor(false,'lockedDoor',x,y,z)",
//   key: "new Key(true,'key',x,y,z,message)",
//   table: "new Tile(false,'table')",
//   hole:"new Hole(true,'hole')",
//   conveyerN: "new Conveyer(true,'white','N')",
//   conveyerE: "new Conveyer(true,'white','E')",
//   conveyerS: "new Conveyer(true,'white','S')",
//   conveyerW: "new Conveyer(true,'white','W')",
//   conveyerButton: "new ConveyerButton(true,'white',x,y,z)",
//   trapDoor: "new TrapDoor(true,'white',x,y,z)",
//   messageTile: "new MessageTile(true,'white',message)",
//   bugTile: "new BattleTile(true,'white','bug')",
//   typoTile: "new BattleTile(true,'white','typo')",
//   unknownErrorTile: "new BattleTile(true,'white','unknownError')",
// }
// $(document).ready(function(){
// $('#box > div').addClass('floor');
// $('div#box').on('click','div', function(){
//   output[parseInt($(this)[0].attributes[0].value)] = translator[$('#type').val()];
//   $(this).removeClass();
//   $(this).addClass($('#type').val());
// });

// $('#go').on('click', function(){
//   $('#output').text('');
//   let outputString ='[';
//   for(let i = 0; i<10; i++){
//     let midString = '[';
//     for(let k = 0; k<10; k++){
//       let x = i+(k*10)
//       midString = midString + output[x] + ", ";
//     }
//     midString = midString.substring(0,midString.length-2);
//     outputString = outputString + midString + '],';
//   }
//   outputString = outputString.substring(0,outputString.length-1);
//   outputString = outputString + ']'
//   $('#output').append(outputString);
// });
// });


// i need to take make the value of each square in the UI have the x 
// and y coordinate in it so that I can use that value when I am 
//generating the code for a level.  Maybe also have a select box for 
//which z value you want the level to have.  possible function for 
//adding connecting tiles for doors and holes.