// let output = [];
// for(let j = 0; j<100; j++){
//   output[j] = "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 1 }"
// }
// let translator = {  
//   floor: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }",
//   wall: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }",
//   void: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = false, Texture = 'void', Aux = '0', Method = 0 }",
//   door: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'door', Aux = '0', Method = 1 }",
//   lockedDoor: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = false, Texture = 'lockedDoor', Aux = '0', Method = 1 }",
//   key: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'key', Aux = '0', Method = 2 }",
//   table: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = false, Texture = 'table', Aux = '0', Method = 0 }",
//   hole:"new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'hole', Aux = '0', Method = 1 }",
//   conveyerN: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'conveyerN', Aux = '0', Method = 2 }",
//   conveyerE: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'conveyerE', Aux = '0', Method = 3 }",
//   conveyerS: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'conveyerS', Aux = '0', Method = 4 }",
//   conveyerW: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'conveyerW', Aux = '0', Method = 5 }",
//   conveyerButton: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'conveyerButton', Aux = '', Method = 6 }",
//   trapDoor: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'trapDoor', Aux = '0', Method = 7 }",
//   messageTile: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 8 }",
//   portalTile: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'portal', Aux = '0', Method = 1 }",
//   lavaTile: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'lava', Aux = '0', Method = 9 }",
//   spikePitTile: "new Tile { TileId = 1, X = 0, Y = 4, Z = " + z + ", Transparent = true, Texture = 'spikePit', Aux = '0', Method = 9 }"
// }
let outputQ = [];
let x;
let y;
let z;
let finalString = "";
let crazyArray = [];
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

    //for(let f = 1; f<=(x*y);f++)
    //{
    //  let target = document.getElementById(f);
    //  
    //}


    let output = [];
    for(let j = 0; j< (x*y); j++){
      output[j] = "new Tile { TileId = " + (j+1) + ", X = " + convertLinearX(x,j) + ", Y = " + convertLinearY(x,j) + ", Z = " + z + ", Transparent = true, Texture = 'turtle', Aux = 'glorp', Method = 'plumbus' },"
    }

  crazyArray = output.slice(0)
  
  // string maker below
  $('#go').on('click', function(){
    $('#output').text('');
    let outputString ='';
    for(let i = 0; i<x; i++){
      let midString = ' ';
      for(let k = 0; k<y; k++){
        let index = i+(k*x);
        midString = midString + outputQ[index] + "</br>";
        // console.log(midString);
        console.log(outputQ[index])
      }
      midString = midString.substring(0,midString.length-2);
      outputString = outputString + "</br>" + midString+ "</br>";
    }
    outputString = outputString.substring(0,outputString.length-1);
    $('#output').append(outputString);
    console.log(output)
  }); 
});

  for(let j = 0; j< (x*y); j++){
      outputQ[j] = "new Tile { TileId = " + (j+1) + ", X = " + convertLinearX(x,j) + ", Y = " + convertLinearY(x,j) + ", Z = " + z + ", Transparent = true, Texture = 'turtle', Aux = 'glorp', Method = 'plumbus' },"
      
    }

  $('div#box').on('click','div', function(){
    outputQ[+this.id - 1] = "new Tile { TileId = " + (+this.id + +$("#idMod-select").val()) + ", X = " + convertLinearX(x,this.id - 1) + ", Y = " + convertLinearY(x,this.id -1) + ", Z = " + z + ", Transparent = " + $("#transparent-select").val() + ", Texture = " + $("#texture-select").val() + ", Aux = " + $("#aux-select").val() + ", Method = " + $("#method-select").val() + " },";
    
    
        // console.log(outputQ);
        // outputQ.forEach(function(string) {
        //   if (string.includes("TileId = " + (this.id))) {
        //     finalString = string.replace("true", $("#transparent-select").val());
        //     finalString = string.replace("turtle", $("#texture-select").val());
        //     finalString = string.replace("glorp", $("#aux-select").val());
        //     finalString = string.replace("plumbus", $("#method-select").val());
        //     console.log(finalString);
        //   }
          

        // })
        
        // Have to find a way to have a unique TileId for every Tile in the entire database

         
      
    $(this).removeClass();
    $(this).addClass($('#type').val());
    // output[this.id]
  }); 


});

function setMapSize(x) {
  document.getElementById('box').style.gridTemplateColumns = "repeat("+x+",1fr)";
}

function switchForm() {
  $('#level-setup').hide();
  $('.scrappydoo').show();  
}


// i need to take make the value of each square in the UI have the x 
// and y coordinate in it so that I can use that value when I am 
//generating the code for a level.  Maybe also have a select box for 
//which z value you want the level to have.  possible function for 
//adding connecting tiles for doors and holes.


//form will ask for y and x this will be max y and max x
//you will generate x*y divs
//display : grid;
//grid-Collumn-template: repeat(x, 1fr);

//Math.Floor(div-Id-number/x) = y
//div-Id-number%%x = which collumn you are in

//let target = $("#ParentDiv");
//target.style.Display = "grid";
//target.style.grid-columns-template = "reapeat(${xInput}, 1fr)";
//for(let i =1; i<=(x*y);i++)
//{
//
//  target.append("<div id=${i}></div>");  
//}


// $(document).ready(function(){
//   $('#box > div').addClass('floor');
//   $('div#box').on('click','div', function(){
//     output[parseInt($(this)[0].attributes[0].value)] = translator[$('#type').val()];
//     $(this).removeClass();
//     $(this).addClass($('#type').val());
//   });

// new Tile { TileId = 1, X = 0, Y = 0, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 13, X = 1, Y = 0, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 25, X = 3, Y = 0, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 37, X = 4, Y = 0, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 49, X = 5, Y = 0, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 61, X = 6, Y = 0, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 73, X = 7, Y = 0, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 85, X = 8, Y = 0, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 97, X = 9, Y = 0, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 109, X = 10, Y = 0, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 121, X = 11, Y = 0, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 133, X = 12, Y = 0, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 },
// new Tile { TileId = 2, X = 0, Y = 1, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 14, X = 1, Y = 1, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 26, X = 3, Y = 1, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 38, X = 4, Y = 1, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 50, X = 5, Y = 1, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 62, X = 6, Y = 1, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 74, X = 7, Y = 1, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 86, X = 8, Y = 1, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 98, X = 9, Y = 1, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 110, X = 10, Y = 1, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 122, X = 11, Y = 1, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 134, X = 12, Y = 1, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 },
// new Tile { TileId = 3, X = 0, Y = 2, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 15, X = 1, Y = 2, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 27, X = 3, Y = 2, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 39, X = 4, Y = 2, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 51, X = 5, Y = 2, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 63, X = 6, Y = 2, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 75, X = 7, Y = 2, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 87, X = 8, Y = 2, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 99, X = 9, Y = 2, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 111, X = 10, Y = 2, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 123, X = 11, Y = 2, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 135, X = 12, Y = 2, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 },
// new Tile { TileId = 4, X = 0, Y = 3, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 16, X = 1, Y = 3, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 28, X = 3, Y = 3, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 40, X = 4, Y = 3, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 52, X = 5, Y = 3, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 64, X = 6, Y = 3, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 76, X = 7, Y = 3, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 88, X = 8, Y = 3, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 100, X = 9, Y = 3, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 112, X = 10, Y = 3, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 124, X = 11, Y = 3, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 136, X = 12, Y = 3, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 },
// new Tile { TileId = 5, X = 0, Y = 4, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 17, X = 1, Y = 4, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 29, X = 3, Y = 4, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 41, X = 4, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 53, X = 5, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 65, X = 6, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 77, X = 7, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 89, X = 8, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 101, X = 9, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 113, X = 10, Y = 4, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 125, X = 11, Y = 4, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 137, X = 12, Y = 4, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 },
// new Tile { TileId = 6, X = 0, Y = 5, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 18, X = 1, Y = 5, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 30, X = 3, Y = 5, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 42, X = 4, Y = 5, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 54, X = 5, Y = 5, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 66, X = 6, Y = 5, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 78, X = 7, Y = 5, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 90, X = 8, Y = 5, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 102, X = 9, Y = 5, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 114, X = 10, Y = 5, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 126, X = 11, Y = 5, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 138, X = 12, Y = 5, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 },
// new Tile { TileId = 7, X = 0, Y = 6, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 19, X = 1, Y = 6, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 31, X = 3, Y = 6, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 43, X = 4, Y = 6, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 55, X = 5, Y = 6, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 67, X = 6, Y = 6, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 79, X = 7, Y = 6, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 91, X = 8, Y = 6, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 103, X = 9, Y = 6, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 115, X = 10, Y = 6, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 127, X = 11, Y = 6, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 139, X = 12, Y = 6, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 },
// new Tile { TileId = 8, X = 0, Y = 7, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 20, X = 1, Y = 7, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 32, X = 3, Y = 7, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 44, X = 4, Y = 7, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 56, X = 5, Y = 7, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 68, X = 6, Y = 7, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 80, X = 7, Y = 7, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 92, X = 8, Y = 7, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 104, X = 9, Y = 7, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 116, X = 10, Y = 7, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 128, X = 11, Y = 7, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 140, X = 12, Y = 7, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 },
// new Tile { TileId = 9, X = 0, Y = 8, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 21, X = 1, Y = 8, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 33, X = 3, Y = 8, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 45, X = 4, Y = 8, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 57, X = 5, Y = 8, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 69, X = 6, Y = 8, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 81, X = 7, Y = 8, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 93, X = 8, Y = 8, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 105, X = 9, Y = 8, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 117, X = 10, Y = 8, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 129, X = 11, Y = 8, Z = " + z + ", Transparent = true, Texture = 'floor', Aux = '0', Method = 0 }, new Tile { TileId = 141, X = 12, Y = 8, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 },
// new Tile { TileId = 10, X = 0, Y = 9, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 22, X = 1, Y = 9, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 34, X = 3, Y = 9, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 46, X = 4, Y = 9, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 58, X = 5, Y = 9, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 70, X = 6, Y = 9, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 82, X = 7, Y = 9, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 94, X = 8, Y = 9, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 106, X = 9, Y = 9, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 118, X = 10, Y = 9, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 130, X = 11, Y = 9, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 142, X = 12, Y = 9, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 },
// new Tile { TileId = 11, X = 0, Y = 10, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 23, X = 1, Y = 10, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 35, X = 3, Y = 10, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 47, X = 4, Y = 10, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 59, X = 5, Y = 10, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 71, X = 6, Y = 10, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 83, X = 7, Y = 10, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 95, X = 8, Y = 10, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 107, X = 9, Y = 10, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 119, X = 10, Y = 10, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 131, X = 11, Y = 10, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 143, X = 12, Y = 10, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 },
// new Tile { TileId = 12, X = 0, Y = 11, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 24, X = 1, Y = 11, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 36, X = 3, Y = 11, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 48, X = 4, Y = 11, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 60, X = 5, Y = 11, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 72, X = 6, Y = 11, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 84, X = 7, Y = 11, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 96, X = 8, Y = 11, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 108, X = 9, Y = 11, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 120, X = 10, Y = 11, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 132, X = 11, Y = 11, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 }, new Tile { TileId = 144, X = 12, Y = 11, Z = " + z + ", Transparent = false, Texture = 'wall', Aux = '0', Method = 0 },

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

// let outputStringArray = outputString.split('},');
// console.log(outputStringArray)
// for(let i = 0; i<outputStringArray.length; i++)  {
//   let finalString = "";
//   if (outputStringArray[i].includes("TileId = " + (i+ 1))) {
    
//     outputStringArray[i].replace("true", $("#transparent-select").val());
//     outputStringArray[i].replace("turtle", $("#texture-select").val());
//     outputStringArray[i].replace("glorp", $("#aux-select").val());
//     outputStringArray[i].replace("plumbus", $("#method-select").val());
//     return outputStringArray;
//   }
//   outputStringArray.forEach(element => {
//       finalString.append(element)
//   });
//   return finalString;
// }
