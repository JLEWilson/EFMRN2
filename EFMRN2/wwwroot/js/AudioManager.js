import $ from "jquery";

export default class AudioManager{
  constructor(){}

  static setVolumeLevels(){
    const audio1 = document.getElementById('over-world-audio');
    audio1.volume = 0.1;
  }
  static startAudio(string, bool){
    let audio = document.getElementById(string);
    audio.loop = bool;
    audio.currentTime = 0;
    if(audio.paused){
      audio.play();
    }
  }
  static pauseAudio(string){
    const audio = document.getElementById(string);
    if(!audio.paused){
      audio.pause();
    }
  }
  static continueAudio(string){
    const audio = document.getElementById(string);
    if(audio.paused){
      audio.play();
    }
  }
}

$(document).ready(() => {
  setVolumeLevels();
});