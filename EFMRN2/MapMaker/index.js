// arranging necessary global variables
let outputQ = [];
let x;
let y;
let z;

// utility functions

function setMapSize(x) {
  document.getElementById('box').style.gridTemplateColumns = "repeat("+x+",1fr)";
}

function switchForm() {
  $('#level-setup').hide();
  $('.scrappydoo').show();  
}

function convertLinearX(x, l)
{
  let outputX = l%x;
  return outputX;
}

function convertLinearY(x, l)
{
  let outputY = ((l-(l%x))/x);
  return outputY;
}


// initial xyz form submit
$(document).ready(function() { 
  $('#level-setup').on('submit', function() {
    event.preventDefault();
    switchForm();
    let target = $('#box');
    x = $('#x-max').val();
    y = $('#y-max').val();
    z = $('#z-value').val();
    setMapSize(x);
    let q = target.width()/x;
  
    for(let i = 1; i <= (x * y); i++) {
      target.append('<div id="' + i + '"></div>')
    }
    
    for(let j = 2; j<(x*y); j++) {    
      stonyNose = document.getElementById(j);
      stonyNose.style.width = q+"px";
      stonyNose.style.height = q+"px";
    }
    $('#box > div').addClass('floor');

    
    let translator = {  
      floor: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      wall: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }",
      void: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = false, Texture = 'void', Aux = '0', Method = 0 }",
      door: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'door', Aux = '0', Method = 1 }",
      lockedDoor: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = false, Texture = 'lockedDoor', Aux = '0', Method = 1 }",
      key: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'key', Aux = '0', Method = 2 }",
      table: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = false, Texture = 'table', Aux = '0', Method = 0 }",
      hole:"new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'hole', Aux = '0', Method = 1 }",
      conveyerN: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'conveyerN', Aux = '0', Method = 2 }",
      conveyerE: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'conveyerE', Aux = '0', Method = 3 }",
      conveyerS: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'conveyerS', Aux = '0', Method = 4 }",
      conveyerW: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'conveyerW', Aux = '0', Method = 5 }",
      conveyerButton: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'conveyerButton', Aux = '', Method = 6 }",
      trapDoor: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'trapDoor', Aux = '0', Method = 7 }",
      messageTile: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 8 }",
      portalTile: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'portal', Aux = '0', Method = 1 }",
      lavaTile: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'lava', Aux = '0', Method = 9 }",
      spikePitTile: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'spikePit', Aux = '0', Method = 9 }"
    }

    let output = [];
    for(let j = 0; j< (x*y); j++){
      output[j] = "new Tile { TileId = " + (j+1) + ", X = " + convertLinearX(x,j) + ", Y = " + convertLinearY(x,j) + ", Z = " + z + ", Transparent = true, Texture = 'turtle', Aux = 'glorp', Method = 'plumbus' },"
    }
  
    // string maker below
    $('#go').on('click', function(){
      $('#output').text('');
      let outputString ='';
      for(let i = 0; i<x; i++){
        let midString = ' ';
        for(let k = 0; k<y; k++){
          let index = i+(k*x);
          midString = midString + outputQ[index] + "</br>";
        }
        midString = midString.substring(0,midString.length-2);
        outputString = outputString + "</br>" + midString+ "</br>";
      }
      outputString = outputString.substring(0,outputString.length-1);
      $('#output').append(outputString);
    }); 
  });

  for(let j = 0; j< (x*y); j++){
      outputQ[j] = "new Tile { TileId = " + (j+1) + ", X = " + convertLinearX(x,j) + ", Y = " + convertLinearY(x,j) + ", Z = " + z + ", Transparent = true, Texture = 'turtle', Aux = 'glorp', Method = 'plumbus' },"
      
    }

  //apply tile properties at each click on tile.  All tiles must be clicked or you get empty values
  $('div#box').on('click','div', function(){
    outputQ[+this.id - 1] = "new Tile { TileId = " + (+this.id + +$("#idMod-select").val()) + ", X = " + convertLinearX(x,this.id - 1) + ", Y = " + convertLinearY(x,this.id -1) + ", Z = " + z + ", Transparent = " + $("#transparent-select").val() + ", Texture = " + $("#texture-select").val() + ", Aux = " + $("#aux-select").val() + ", Method = " + $("#method-select").val() + " },";      
    $(this).removeClass();
    $(this).addClass($('#type').val());
  }); 
});