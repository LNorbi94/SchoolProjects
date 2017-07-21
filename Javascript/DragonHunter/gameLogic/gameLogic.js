function grow(table, size, sID, n = -1, m = -1)
{
    if(sID != scrollID)
    {
        return undefined;
    }
	if(size > 0)
	{
		var coords = getDCoords();
		stop = true;
		var tailX;
		var tailY;
		if(n == -1)
		{
			tailX = tails.length < 1 ? headCoord.x : tails[tails.length - 1].x;
			tailY = tails.length < 1 ? headCoord.y : tails[tails.length - 1].y;
		} else {
			tailX = n;
			tailY = m;
			move(table);
		}
		var tail = createImageForTable('theme/Tail.svg', 'Sárkány farka');
		if(sID == scrollID)
		{
			table.rows[tailX].cells[tailY].appendChild(tail);
			addPoint(1);
		}
		var tailCoords = {x: tailX, y: tailY};
		tails.push(tailCoords);
		setTimeout(
			function() { return grow(table, size - 1, sID, tailX, tailY); }
			, speed);
	} else
	{
		stop = false;
		activeScroll = undefined;
		changeText("-");
		animation(table);
	} 
}

function turnScrollOff(table)
{
	switch(activeScroll)
	{
		case 'Fo':
			switchBody(table);
			break;
	}
	speed = baseSpeed;
	activeScroll = undefined;
}

function switchBody(table)
{
    switch(way)
    {
        case LEFT:
            way = RIGHT;
            break;
        case RIGHT:
            way = LEFT;
            break;
        case UP:
            way = DOWN;
            break;
        case DOWN:
            way = UP;
            break;
    }
    activeWay = way;
	if(tails.length > 0)
	{
		var tailCoords = tails[0];
		var tail = createImageForTable('theme/Tail.svg', 'Sárkány farka');
		table.rows[tailCoords.x].cells[tailCoords.y].innerHTML = '';
		table.rows[tailCoords.x].cells[tailCoords.y].appendChild(head);
		tails.splice(0, 0, headCoord);
		table.rows[headCoord.x].cells[headCoord.y].innerHTML = '';
		table.rows[headCoord.x].cells[headCoord.y].appendChild(tail);
	}
}

function changeSpeed(amount)
{
	speed *= amount;
}

function changeSpeedBack(scroll)
{
	if(activeScroll === scroll)
	{
		speed = baseSpeed;
		changeText('-');
		activeScroll = undefined;
	}
}

function notEmpty(cell, table)
{
    ++scrollID;
	if(cell.indexOf('alt="B') != -1)
	{
		turnScrollOff(table);
		generateScroll(table);
		activeScroll = 'B';
		changeText('Bölcsesség tekercse');
		grow(table, 4, scrollID);
	} else if(cell.indexOf('alt="Fa') != -1)
	{
		turnScrollOff(table);
		generateScroll(table);
		activeScroll = 'Fa';
		changeText('Falánkság tekercse');
		grow(table, 10, scrollID);
	} else if(cell.indexOf('alt="T') != -1)
	{
		turnScrollOff(table);
		generateScroll(table);
		activeScroll = 'T';
		changeText('Tükrök tekercse');
	} else if(cell.indexOf('alt="Fo') != -1)
	{
		turnScrollOff(table);
		generateScroll(table);
		switchBody(table);
		activeScroll = 'Fo';
		changeText('Fordítás tekercse');
	} else if(cell.indexOf('alt="M') != -1)
	{
		turnScrollOff(table);
		generateScroll(table);
		activeScroll = 'M';
		changeSpeed(0.75);
		setTimeout(function() { return changeSpeedBack('M'); }, 5000);
		changeText('Mohóság tekercse');
	} else if(cell.indexOf('alt="L') != -1)
	{
		turnScrollOff(table);
		generateScroll(table);
		activeScroll = 'L';
		changeSpeed(1.5);
		setTimeout(function() { return changeSpeedBack('L'); }, 5000);
		changeText('Lustaság tekercse');
	} else {
        stop = true;
		activeScroll = undefined;
        alert("A játéknak vége!");
		return false;
	}
	return true;
}

function move(table)
{
	coords = getDCoords();
	rotate = coords.rotate;
	activeWay = way;
	if(table.rows[headCoord.x + coords.x].cells[headCoord.y + coords.y].innerHTML.indexOf('Tail') == -1)
	{
		head.style.transform = rotate;
		var cell = table.rows[headCoord.x + coords.x].cells[headCoord.y + coords.y].innerHTML;
		var empty = cell.trim() == '';
		var cont = empty ? true : notEmpty(cell, table);
		if(empty || cont)
		{
			table.rows[headCoord.x].cells[headCoord.y].innerHTML = "";
			headCoord.x += coords.x;
			headCoord.y += coords.y;
			table.rows[headCoord.x].cells[headCoord.y].innerHTML = "";
			table.rows[headCoord.x].cells[headCoord.y].appendChild(head);
			if(tails.length > 0)
			{
				var img = createImageForTable('theme/Tail.svg', 'Sárkány farka');
				var lastTail = tails.pop();
				if(headCoord.x != lastTail.x || headCoord.y != lastTail.y)
                {
					table.rows[lastTail.x].cells[lastTail.y].innerHTML = "";
                }
				var newTail =
				{
					x: headCoord.x - coords.x
					, y: headCoord.y - coords.y
				};
				tails.splice(0, 0, newTail);
				table.rows[newTail.x].cells[newTail.y].appendChild(img);
			}
		}
	} else
	{
		stop = true;
		activeScroll = undefined;
        alert("A játéknak vége!");
	}
}

function getDCoords()
{
	var x = 0;
	var y = 0;
	var rotate = "rotate(";
	switch(way)
	{
		case RIGHT:
			rotate += "0";
			y = 1;
			break;
		case LEFT:
			rotate += "180";
			y = -1;
			break;
		case UP:
			rotate += "270";
			x = -1;
			break;
		case DOWN:
			rotate += "90";
			x = 1;
			break;
	}
	rotate += "deg)";
	return {
		x: x
		, y: y
		, rotate: rotate
	};
}

function animation(table)
{
	if(!stop)
	{
		coords = getDCoords();
		if(table.rows[headCoord.x + coords.x] != undefined && table.rows[headCoord.x + coords.x].cells[headCoord.y + coords.y] != undefined)
	 	{
			move(table);
			setTimeout(
				function() { return animation(table); }
				, speed);
		} else
        {
            alert("A játéknak vége!");
        }
	}
}
