let canvas = document.getElementById("DisplayCanvas");
let brush = canvas.getContext("2d");
let TilesDavis = document.getElementById("TileDivs");

var keysDown = {};
document.addEventListener("keydown",(e)=>{keysDown[e.keyCode] = true;}, false);
document.addEventListener('keyup',(e)=>{delete keysDown[e.keyCode];}, false);


let dim = 7;
canvas.parentNode.style.position = "fixed";
canvas.parentNode.style.left = "25%";
canvas.parentNode.style.height = window.innerHeight*0.8+"px";
canvas.parentNode.style.width = canvas.parentNode.style.height;
canvas.height = window.innerHeight*0.8;
canvas.width = canvas.height;
canvas.style.border = "solid black 1px";
canvas.style.position = "fixed";
canvas.style.left = "25%";
TilesDavis.style.width = canvas.height+"px";
TilesDavis.style.height = TilesDavis.style.width;
TilesDavis.style.display = "grid";
TilesDavis.style.gridTemplateColumns="repeat("+dim+",1fr)";
TilesDavis.style.position="absolute";

console.log(canvas.height);
console.log(canvas.width);

let q = canvas.height/dim;

setInterval(go, 1000/6);
var PlayerId = 3;

async function go()
{
  let smellyPomegranite = takeInput();
  let apiString = 'http://localhost:5000/api/Game/move/?pid='+PlayerId+'&n='+smellyPomegranite[0]+'&s='+smellyPomegranite[1]+'&e='+smellyPomegranite[2]+'&w='+smellyPomegranite[3]+'';
  console.log(apiString);
  var back = await getMove(apiString);
  console.log(back);
  DrawSelf(back);
  updateMap2();
}

function takeInput(){
  let keyStates=[(38 in keysDown ),(40 in keysDown),(39 in keysDown),(37 in keysDown)];
  console.log(keyStates)
  return keyStates;
}

async function updateMap2()
{
  let bucket = await getLocalTiles(PlayerId);
  console.log(bucket);
  let counter = 0;
  let IncomingData = Array.from(document.getElementById("TileDivs").children);
  bucket.forEach(e=>{
    IncomingData[counter].classList = e.texture;
    console.log(e.texture);
    counter++;
  });
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
    let target = await getTile(coVariables[0],y+3+coVariables[1],z);
    IncomingData[i].classList = target.texture;
  }
  
}

function DrawSelf(input)
{
  brush.clearRect(0,0,canvas.width, canvas.height);
  brush.fillStyle = input.color;
  brush.beginPath();
  brush.arc(3.5*q,3.5*q,q/2,0,Math.PI*2,false);
  brush.fill();
}

function convertLinear(x,l)
{
  let output = [l%x, ((l-(l%x))/x)+1]
  return output;
}
async function getMove(string)
{
  try{
    const response = await fetch(string);
    if(!response.ok) {
        throw Error(response.statusText);        
      }
      return response.json();
    } catch(error) {  
      return error.message;
    }
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
async function getLocalTiles(id)
{
  try{
    const response = await fetch(`http://localhost:5000/api/Game/fMap/?pid=${id}&range=3`);
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