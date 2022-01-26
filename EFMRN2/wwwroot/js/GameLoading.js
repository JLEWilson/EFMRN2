let canvas = document.getElementById("DisplayCanvas");
let brush = canvas.getContext("2d");
let TilesDavis = document.getElementById("TileDivs");

var keysDown = {};
document.addEventListener("keydown",(e)=>{keysDown[e.keyCode] = true;}, false);
document.addEventListener('keyup',(e)=>{delete keysDown[e.keyCode];}, false);


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

setInterval(go, 1000);
var PlayerId = 2;

function go()
{
  let smellyPomegranite = takeInput();
  let apiString = 'http://localhost:5000/api/Game/move/?pid='+PlayerId+'&n='+smellyPomegranite[0]+'&s='+smellyPomegranite[1]+'&e='+smellyPomegranite[2]+'&w='+smellyPomegranite[3]+'';
  console.log(apiString);
  fetch(apiString);
  updateMap();
}

function takeInput(){
  let keyStates=[(38 in keysDown ),(40 in keysDown),(39 in keysDown),(37 in keysDown)];
  console.log(keyStates)
  return keyStates;
}

async function updateMap()
{
  console.log(PlayerId);
  let player = await getPlayer(PlayerId);
  console.log(player);
  let x = player.x;
  let y = player.y;
  let z = player.z;
  let IncomingData = Array.from(document.getElementById("TileDivs").children);
  for(let i = 0; i<IncomingData.length;i++) {
    // square.style.width = q+"px";
    // square.style.height = q+"px";
    let coVariables = convertLinear(dim,parseInt(IncomingData[i].id));
    let target = await getTile(coVariables[0],coVariables[1],z);
    IncomingData[i].classList = target.texture;
  }
  
}

function convertLinear(x,l)
{
  let output = [l%x, ((l-(l%x))/x)+1]
  return output;
}
async function getPlayer(id)
{
  try{
    const response = await fetch(`http://localhost:5000/api/Game/player/?id=${id}`);
    if(!response.ok) {
        throw Error(response.statusText);        
      }
      return response.json();
    } catch(error) {  
      return error.message;
    }
}
//get request to obtain a tile from a specific location (ajax request to the game controller)
async function getTile(x,y,z)
{
  try{
    const response = await fetch(`http://localhost:5000/api/Game/?x=${x}&y=${y}&z=${z}`);
    if(!response.ok) {
        throw Error(response.statusText);        
      }
      return response.json();
    } catch(error) {  
      return error.message;
    }
}