let canvas = document.getElementById("DisplayCanvas");
let brush = canvas.getContext("2d");

canvas.parentNode.style.height = window.innerHeight;
canvas.parentNode.style.width = canvas.parentNode.style.height;
canvas.height = canvas.parentNode.style.height;
canvas.width = canvas.height;
let q = canvas.height/11;


async function updateMap()
{
  let IncomingData = document.getElementId("TileDivs").childNodes;
  IncomingData.Map(function(square) {
    let coVariables = convertLinear(parseInt(square.id));
    let target = getTile(coVariables[0],coVariables[1],coVariables[2]);
    square.classList = target.Texture;
  });
  
}

function convertLinear(x,l)
{
  let output = [l%x, l-(l%x)/x]
  return output;
}

//get request to obtain a tile from a specific location (ajax request to the game controller)
static async function getTile(x,y,z)
{
  try{
    const response = await fetch(`https://localhost:5000/api/tile/?x=${X},y=${y},z=${z}`);
    if(!response.ok) {
        throw Error(response.statusText);        
      }
      return response.json();
    } catch(error) {  
      return error.message;
    }
}