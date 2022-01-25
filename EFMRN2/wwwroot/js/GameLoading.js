let canvas = document.getElementById("DisplayCanvas");
let brush = canvas.getContext("2d");
let TilesDavis = document.getElementById("TileDivs");

let dim = 7;

canvas.parentNode.style.height = window.innerHeight*0.8+"px";
canvas.parentNode.style.width = canvas.parentNode.style.height;
canvas.style.height = canvas.parentNode.style.height;
canvas.style.width = canvas.style.height;
TilesDavis.style.width = canvas.style.height;
TilesDavis.style.height = TilesDavis.style.width;
TilesDavis.style.display = "grid";
TilesDavis.style.gridTemplateColumns="repeat("+dim+",1fr)";
canvas.style.position = "absolute";

let q = canvas.height/dim;

// setInterval(updateMap, 1000);
updateMap();

async function updateMap()
{
  let IncomingData = Array.from(document.getElementById("TileDivs").children);
  console.log(IncomingData);
  IncomingData.map(function(square) {
    square.style.width = q+"px";
    square.style.height = q+"px";
    let coVariables = convertLinear(dim,parseInt(square.id));
    let target = getTile(coVariables[0],coVariables[1],0);
    console.log(target);
    square.classList = target.Texture;
  });
  
}

function convertLinear(x,l)
{
  let output = [l%x, ((l-(l%x))/x)+1]
  console.log("for position "+l);
  console.log(output);
  return output;
}

//get request to obtain a tile from a specific location (ajax request to the game controller)
async function getTile(x,y,z)
{
  try{
    const response = await fetch(`https://localhost:5000/api/Game/?x=${x}&y=${y}&z=${z}`);
    if(!response.ok) {
        throw Error(response.statusText);        
      }
      return response.json();
    } catch(error) {  
      return error.message;
    }
}