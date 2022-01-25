let canvas = document.getElementById("DisplayCanvas");
let brush = canvas.getContext("2d");

canvas.parentNode.style.height = window.innerHeight;
canvas.parentNode.style.width = canvas.parentNode.style.height;
canvas.height = canvas.parentNode.style.height;
canvas.width = canvas.height;
let q = canvas.height/11;


function updateMap()
{
  let IncomingData = document.getElementId("TileDivs").childNodes;
  IncomingData.Map(function(square) {
    let coVariables = convertLinear(parseInt(square.id));

  });
  
}

function convertLinear(x,l)
{
  let output = [l%x, l-(l%x)/x]
  return output;
}

//get request to obtain a tile from a specific location (ajax request to the game controller)