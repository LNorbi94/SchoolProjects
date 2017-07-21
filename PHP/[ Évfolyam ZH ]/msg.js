function $(id)
{
    return document.getElementById(id);
}

function init()
{
    if ($('msg') != undefined)
    {
        $('msg').addEventListener('keyup', showMsg, false);
    }
    if ($('msgs') != undefined)
    {
         filter($('msgs'));
    }
}

function showMsg(e)
{
    var field = e.target;
    var msg = $('msg');
    var length = msg.value.length;
    if (length >= 160)
    {
        msg.style.borderWidth = "10px"
    }
    else
    {
        msg.style.borderWidth = "1px"
    }
    if (msg.value.indexOf("ELTE") > -1)
    {
        msg.style.borderColor = "green";
    }
    else
    {
        msg.style.borderColor = "black";
    }
    $('msgLength').innerHTML = length;
    var splitText = field.value.split(' ');
    splitText.forEach(chText);
    $('msgPrev').innerHTML = splitText.join(' ');
}

function filter(div)
{
    var childs = div.childNodes;
    for (var i = 0; i < childs.length - 1; ++i)
    {
        if (childs[i] != undefined)
        {
            var inP = childs[i].childNodes[childs[i].childNodes.length - 2];
            if (inP != undefined)
            {
                var splitText = inP.innerHTML.split(' ');
                splitText.forEach(chText);
                inP.innerHTML = splitText.join(' ');
            }
        }
    }
}

function chText(currentValue, index, array)
{
    var changeTo = currentValue;
    currentValue = currentValue.replace("<", "&lt;");
    currentValue = currentValue.replace(">", "&gt;");
    if (currentValue.charAt(0) === '#')
    {
        changeTo = "<a href='https://twitter.com/hashtag/" + currentValue.substring(1) + "'>";
        changeTo += currentValue;
        changeTo += "</a>";
        array[index] = changeTo;
    }
    else if (currentValue.charAt(0) === '@')
    {
        changeTo = "<a href='https://twitter.com/" + currentValue.substring(1) + "'>";
        changeTo += currentValue;
        changeTo += "</a>";
        array[index] = changeTo;
    }
    array[index] = changeTo;
}

window.addEventListener('load', init, false);