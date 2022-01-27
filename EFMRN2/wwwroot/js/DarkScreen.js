$('#test-btn').on('click', function() {
  advanceText(['Hello', 'How Are you?', 'Great!'])
})

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
}