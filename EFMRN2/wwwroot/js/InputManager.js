// var keysDown = {};
// document.addEventListener("keydown",(e)=>{keysDown[e.keyCode] = true;}, false);
// document.addEventListener('keyup',(e)=>{delete keysDown[e.keyCode];}, false);

// var c = document.getElementById("playerCanvas");
// var brush = c.getContext("2d");
// c.parentNode.style.height = window.innerHeight/2+"px";
// c.parentNode.style.width= c.parentNode.style.height;
// c.parentNode.style.border="solid black 1em";
// c.width = c.parentNode.offsetWidth;
// c.height = c.parentNode.offsetHeight;
// var q = c.height/7;

// function takeInput(){
//   let keyStates=[(38 in keysDown ),(40 in keysDown),(39 in keysDown),(37 in keysDown)];
//   return keyStates;
// }

// async function drawPlayers()
// {
//   let tempKeys = takeInput();
//   let henry = await GameApiService.con(document.getElementById("player-selection").value, tempKeys[0],tempKeys[1],tempKeys[2],tempKeys[3]);
//   brush.clearRect(0,0,c.width, c.height);
//   for(let i = 0; i<henry.length;i++)
//   {
//     drawPlayer(henry[i].x,henry[i].y);
//   }
// }
// function drawPlayer(x,y)
// {
//   brush.fillStyle = "red";
//   brush.beginPath();
//   brush.arc(x*q,y*q,q/2,0,Math.PI*2,false);
//   brush.fill();
// }