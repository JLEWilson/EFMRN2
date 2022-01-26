function setVolumeLevels(){
  const audio1 = document.getElementById('main-theme');
  console.log(audio1);
  audio1.volume = 0.1;
}
function startAudio(string, bool){
  let audio = document.getElementById(string);
  audio.loop = bool;
  audio.currentTime = 0;
  if(audio.paused){
    audio.play();
  }
}
function pauseAudio(string){
  const audio = document.getElementById(string);
  if(!audio.paused){
    audio.pause();
  }
}
function continueAudio(string){
  const audio = document.getElementById(string);
  if(audio.paused){
    audio.play();
  }
}
setVolumeLevels();
startAudio("main-theme", true);