let canvas = document.getElementById("DisplayCanvas");
let brush = canvas.getContext("2d");
let TilesDavis = document.getElementById("TileDivs");
let user = document.getElementById("user");

let dimg = document.getElementById("gdown");
let uimg = document.getElementById("gup");
let limg = document.getElementById("gleft");
let rimg = document.getElementById("gright");

let activeTexture = dimg;



var keysDown = {};
document.addEventListener("keydown",(e)=>{keysDown[e.keyCode] = true;}, false);
document.addEventListener('keyup',(e)=>{delete keysDown[e.keyCode];}, false);

let dim = 7;
canvas.parentNode.style.position = "fixed";
canvas.parentNode.style.left = "30.5vw";
canvas.parentNode.style.height = window.innerHeight*0.8+"px";
canvas.parentNode.style.width = canvas.parentNode.style.height;
canvas.height = window.innerHeight*0.8;
canvas.width = canvas.height;
canvas.style.border = "solid black 1px";
canvas.style.position = "fixed";
canvas.style.left = "30.5vw";
TilesDavis.style.width = canvas.height+"px";
TilesDavis.style.height = TilesDavis.style.width;
TilesDavis.style.display = "grid";
TilesDavis.style.gridTemplateColumns="repeat("+dim+",1fr)";
TilesDavis.style.position="absolute";

let q = canvas.height/dim;

console.log(user.textContent);
var PlayerId =0;
setPlayer(user.textContent);
async function setPlayer(s)
{
  var test = await getPlayerByUser(s);
  PlayerId = test.playerId;
  console.log(PlayerId);
}

setInterval(go, 1000/6);
// go();

async function go()
{
  let smellyPomegranite = takeInput();
  let apiString = 'http://localhost:5000/api/Game/move/?pid='+PlayerId+'&n='+smellyPomegranite[0]+'&s='+smellyPomegranite[1]+'&e='+smellyPomegranite[2]+'&w='+smellyPomegranite[3]+'';
  var back = await getMove(apiString);
  drawLocalPlayers(PlayerId, back);
  updateMap2();
  getMessage();
  // if(m!="NoMessages")
  // {
  //   let a = m.split("/");
  //   advanceText(a);
  // }
}



function takeInput(){
  let keyStates=[(38 in keysDown ),(40 in keysDown),(39 in keysDown),(37 in keysDown)];
  if(keyStates[0])
  {
    activeTexture = uimg;
  }
  if(keyStates[1])
  {
    activeTexture = dimg;
  }
  if(keyStates[2])
  {
    activeTexture = rimg;
  }
  if(keyStates[3])
  {
    activeTexture = limg;
  }
  return keyStates;
}

async function updateMap2()
{
  let bucket = await getLocalTiles(PlayerId);
  let counter = 0;
  let IncomingData = Array.from(document.getElementById("TileDivs").children);
  bucket.map(e=>{
    IncomingData[counter].classList = e.texture;
    counter++;
  });
}
async function drawLocalPlayers(id, input)
{
  let mp = await getLocalPlayers(id);
  brush.clearRect(0,0,canvas.width, canvas.height);
  DrawSelf(input.color);
  mp.forEach(async e=>{
    let avalue = await diffCoord(e);
    DrawPlayer(avalue[0],avalue[1],e);
  });
}
async function updateMap()
{
  let player = await getPlayer(PlayerId);
  let x = player.x;
  let y = player.y;
  let z = player.z;
  let IncomingData = Array.from(document.getElementById("TileDivs").children);
  for(let i = 0; i<IncomingData.length;i++) {
    let coVariables = convertLinear(dim,parseInt(IncomingData[i].id));
    let target = await getTile(coVariables[0],y+3+coVariables[1],z);
    IncomingData[i].classList = target.texture;
  }
  
}

function DrawSelf(input)
{
  // brush.clearRect(0,0,canvas.width, canvas.height);
  brush.fillStyle = input;
  brush.beginPath();
  // brush.arc(3.5*q,3.5*q,q/2,0,Math.PI*2,false);
  brush.drawImage(activeTexture, 3*q,3*q,q,q);
  brush.fill();
}

async function DrawPlayer(x,y,input)
{
  brush.fillStyle = input.color;
  let otex = dimg;
  if(input.bearing === 0)
  {
    otex = dimg;
  }
  if(input.bearing === 1)
  {
    otex = uimg;
  }
  if(input.bearing === 2)
  {
    otex = rimg;
  }
  if(input.bearing === 3)
  {
    otex = limg;
  }
  brush.beginPath();
  // brush.arc((x+0.5)*q,(y+0.5)*q,q/2,0,Math.PI*2,false);
  brush.drawImage(otex,x*q,y*q,q,q);
  brush.fill();
}

async function diffCoord(input)
{
  let me = await getPlayer(PlayerId);
  let xdif = (input.x-me.x)+3
  let ydif = (input.y-me.y)+3
  return [xdif,ydif];
}

function convertLinear(x,l)
{
  let output = [l%x, ((l-(l%x))/x)+1]
  return output;
}
async function getMove(greg)
{
  try{
    const response = await fetch(greg);
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
async function getLocalPlayers(id)
{
  try{
    const response = await fetch(`http://localhost:5000/api/Game/fPlayer/?pid=${id}&range=3`);
    if(!response.ok) {
        throw Error(response.statusText);        
      }
      return response.json();
    } catch(error) {  
      return error.message;
    }
}

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
async function getPlayerByUser(id)
{
  try{
    const response = await fetch(`http://localhost:5000/api/Game/user/?pid=${id}`);
    if(!response.ok) {
        throw Error(response.statusText);        
      }
      return response.json();
    } catch(error) {  
      return error.message;
    }
}
// async function getMessage()
// {
//   try{
//     const response = await fetch(`http://localhost:5000/api/Game/checkMes`);
//     if(!response.ok) {
//         throw Error(response.statusText);        
//       }
//       return response;
//     } catch(error) {  
//       return error.message;
//     }
// }
async function setMessage()
{
  try{
    const response = await fetch(`http://localhost:5000/api/Game/setMes/?message=NoMessages`);
    if(!response.ok) {
        throw Error(response.statusText);        
      }
      return response;
    } catch(error) {  
      return error.message;
    }
}
async function getMessage()
{
  fetch(`http://localhost:5000/api/Game/checkMes`)
    .then(response => response.text())
    .then((response) => {
        console.log(response);

        if(response!="NoMessages")
        {
          
          console.log("trigger ran");
          advanceText(response.split("_"));
        }
    });
}


function advanceText(textArr) {
  let currentText = 0;
  $('#dark-screen').css('display', 'flex');
  $('#current-text').text(textArr[currentText]);
  $('#next-btn').on('click', function() {
    
    currentText ++;
    if(currentText < textArr.length) {
      $('#current-text').text(textArr[currentText]);
    } else {
      $('#dark-screen').css('display', 'none');
    }
  })
  setMessage();
}