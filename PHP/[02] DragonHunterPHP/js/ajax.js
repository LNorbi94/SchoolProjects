function newXHR()
{
  var xhr = null;
  try { xhr = new XMLHttpRequest(); } catch(e) {
  try { xhr = new ActiveXObject("Msxml2.XMLHTTP"); } catch(e) {
  try { xhr = new ActiveXObject("Microsoft.XMLHTTP"); } catch(e) {
        xhr = null;
  }}}
  return xhr;
}

function scoreHandler(xhr) {
  alert(xhr.responseText);
}

function saveScore(score, name, game)
{
  var xhr = newXHR();
  xhr.open('POST', 'index.php?saveScore', true);
  xhr.setRequestHeader('Content-Type', 
    'application/x-www-form-urlencoded');
  xhr.addEventListener('readystatechange', function () {
    if (xhr.readyState == 4)
    {
      if (xhr.status == 200)
      {
        scoreHandler(xhr);
      }
      else
      {
        console.log('Hiba történt.');
      }
    }
  }, false);
  var snd = [];
  snd.push(name);
  snd.push(game);
  if(score == undefined)
  {
    score = 0;
  }
  snd.push(score);
  xhr.send('values[]=' + snd);
}
