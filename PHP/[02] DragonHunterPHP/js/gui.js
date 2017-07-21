function init()
{
    $('newGameBtn').addEventListener('click', function() { window.location = "index.php?game"; }, false);
    document.addEventListener('keydown', changeDirection, false);
    start();
}

function initGame(n, m, k)
{
    var table = $('gameTable');

    table.innerHTML = tableGenerator(n, m);
    headCoord.x = n % 2 == 0 ? n / 2 : Math.round(n / 2);
    headCoord.y = 0;
    head = createImageForTable('img/Head.svg', 'Sárkány feje');
    wisdomScroll = createImageForTable('img/Scroll.svg', 'Bölcsesség tekercse');
    mirrorScroll = createImageForTable('img/Scroll.svg', 'Tükrök tekercse');
    switchScroll = createImageForTable('img/Scroll.svg', 'Fordítás tekercse');
    greedScroll = createImageForTable('img/Scroll.svg', 'Mohóság tekercse');
    slothScroll = createImageForTable('img/Scroll.svg', 'Lustaság tekercse');
    gluttonyScroll = createImageForTable('img/Scroll.svg', 'Falánkság tekercse');

    table.rows[headCoord.x].cells[headCoord.y].appendChild(head);

    for(var i = 0; i < k; ++i)
    {
        var blockage = createImageForTable('img/Blockage.svg', 'A Tereptárgy');
        var coords = randomCoords(table);
        table.rows[coords.x].cells[coords.y].appendChild(blockage);
    }

    generateScroll(table);
    animation(table);
}

function generateScroll(table)
{
    var rNum = randomNumber(0, 99);
    var coords = randomCoords(table);
    if(rNum >= 0 && rNum <= 79)
    {
        table.rows[coords.x].cells[coords.y].appendChild(wisdomScroll);
    } else if(rNum > 79 && rNum <= 83)
    {
        table.rows[coords.x].cells[coords.y].appendChild(mirrorScroll);
    } else if(rNum > 83 && rNum <= 87)
    {
        table.rows[coords.x].cells[coords.y].appendChild(switchScroll);
    } else if(rNum > 87 && rNum <= 91)
    {
        table.rows[coords.x].cells[coords.y].appendChild(greedScroll);
    } else if(rNum > 91 && rNum <= 95)
    {
        table.rows[coords.x].cells[coords.y].appendChild(slothScroll);
    } else if(rNum > 95 && rNum <= 99)
    {
        table.rows[coords.x].cells[coords.y].appendChild(gluttonyScroll);
    }
}

function changeDirection(e)
{
    var oldWay = way;
    var keyCode;

    if(window.event)
    {
        keyCode = window.event.keyCode;
    } else if(e)
    {
        keyCode = e.which;
    }

    if( (activeWay != RIGHT    || keyCode != LEFT  ) 
        && (activeWay != LEFT  || keyCode != RIGHT )
        && (activeWay != UP    || keyCode != DOWN  )
        && (activeWay != DOWN  || keyCode != UP    )
        && keyCode >= 36       && keyCode <= 40 )
    {
        if(activeScroll === 'T')
        {
            switch(keyCode)
            {
                case DOWN:
                    way = UP;
                    break;
                case UP:
                    way = DOWN;
                    break;
                case LEFT:
                    way = RIGHT;
                    break;
                case RIGHT:
                    way = LEFT;
                    break;
            }
        } else 
        {
            way = keyCode;
        }
    }
}

function changeText(text)
{
    $('activeScroll').innerHTML = text;
}

function addPoint(point)
{
    if (myPoints === undefined)
    {
        myPoints = 0;
    }
    myPoints += 1;
    $('points').innerHTML = myPoints;
}

window.addEventListener('load', init, false);
