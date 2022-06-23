// Здесь наше представление  27.34
var view = {
	displayMessage: function(msg){
		var messageArea = document.querySelector('#messageArea');
		messageArea.innerHTML = msg;
	},

	displayHit: function(location){
		var cell = document.getElementById(location);
		cell.setAttribute("class", "hit");
	},

	displayMiss: function(location){
		var cell = document.getElementById(location);
		cell.setAttribute("class", "miss");
	}
};

// Здесь наша модель поведения игры

var model = {
	boardSize: 7,  // размер игрового поля
	numShips: 3,   // количество кораблей в игре
	shipLength: 3, // длина корабля в клетках
	shipsSunk: 0,  // количество потопленных кораблей

	ships: [
		ship1 = { location: ['0', '0', '0'], hits: ['', '', ''] },
		ship2 = { location: ['0', '0', '0'], hits: ['', '', ''] },
		ship3 = { location: ['0', '0', '0'], hits: ['', '', ''] }
		],

	fire: function(guess){ // получает координаты выстрела
		for(var i =0; i < this.numShips; i++){
			var ship = this.ships[i];

			var index = ship.location.indexOf(guess);
			if(index >= 0){
				ship.hits[index] = 'hit';
				view.displayHit(guess);
				view.displayMessage("HIT!!!");
				if(this.isSunk(ship)){
					view.displayMessage("You sank my battleship!");
					this.shipsSunk++;
				}
				return true;
			}
		}
		view.displayMiss(guess);
		view.displayMessage("You missed!");
		return false;
	},

	isSunk: function(ship){
		for(var i = 0; i < this.shipLength; i++){
			if(ship.hits[i] !== "hit"){
				return false;
			}
		}
		return true;
	},

	//Генерация кораблей на игровом поле
	generateShipLocations: function(){
		var location;
		for(var i = 0; i < this.numShips; i++){
			do{
				location = this.generateShip();

			}while(this.collision(location));
			this.ships[i].location = location;
		}
		console.log("Ships array: ")
		console.log(this.ships);
	},
	generateShip: function(){
		var direction = Math.floor(Math.random() * 2);
		var row, col;

		if(direction ===1){
			//Сгенерировать начальную позицию для горизонтального коробля
			row = Math.floor(Math.random() * this.boardSize );
			col = Math.floor(Math.random()* (this.boardSize - this.shipLength));
		}else{
			//Сгенерировать начальную позицию для вертикального коробля
			row = Math.floor(Math.random()* (this.boardSize - this.shipLength));
			col = Math.floor(Math.random() * this.boardSize );
		}

		var newShipLocations = [];

		for(var i = 0; i < this.shipLength; i++){
			if(direction === 1){
				//добовляем в массив для горозинтального коробля
				newShipLocations.push(row + "" + (col +i));
			}else{
				//добовляем в массив для вертикального коробля
				newShipLocations.push((row + i) + "" + col);
			}			
		}
		return newShipLocations;
	},
	collision: function(Location){
		for(var i = 0; i < this.shipLength; i++){
			var ship = model.ships[1];
			for(var j = 0; j < location.length; j++){
				if(ship.locations.indexOf(locations[j]) >=0){
					return true;
				}
			}
		}
		return false;
	}
};

var controller = {
	gusses: 0,

	processGuess: function(guess){
		var location = parseGuess(guess);
		if(location){
			this.gusses++;
			var hit = model.fire(location);
			if(hit && model.shipsSunk === model.numShips){
				view.displayMessage("Вы потопили все корабли за: " + this.gusses + " выстрелов");
			}
		}
	}
}

function parseGuess(guess){
	var alphabet = ["A", "B", "C", "D", "E", "F", "G"];

	if(guess === null || guess.length !== 2){
		alert("Вы ввели неверные координаты");
	}else{
		firstChar = guess.charAt(0); //извлекаем со строки первый символ
		var row = alphabet.indexOf(firstChar);
		var column = guess.charAt(1);

		if(isNaN(row) || isNaN(column)){
			alert("Вы ввели неверные координаты");
		}else if(row < 0 || row >= model.boardSize || column < 0 || column >= model.boardSize){
			alert("Вы ввели неверные координаты");
		}else{
			return row + column;
		}
	}
	return null;
}

function init(){
	var fireButton = document.getElementById('fireButton');
	fireButton.onclick = handleFireButton;
	// поработаем с Enter
	var guessInput = document.getElementById('guessInput');
	guessInput.onkeypress = handleKeyPress;

	model.generateShipLocations();
}

function handleFireButton(){
	var guessInput = document.getElementById('guessInput');
	var guess = guessInput.value;
	controller.processGuess(guess);

	guessInput.value = "";
}

function handleKeyPress(e){
	var fireButton = document.getElementById("fireButton");
	//console.log(e.keyCode);
	if(e.keyCode === 13){
		fireButton.click();
		return false;
	}
}

window.onload = init;