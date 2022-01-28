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
      void : "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      floor : "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      carpet1 : "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      carpet2: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      carpet3: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      carpet4: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      carpet4fancy: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      wall: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      hedge: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      window: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      darkfloor: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      grass : "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      grass2: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      grass3: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      hedge: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      mud: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      ice: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      lava: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      pressure: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      door: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
      trapdoor: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }"
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