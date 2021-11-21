// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Write your JavaScript code.




























//CREATE CANDLE STICK CHART

let symbol = document.querySelector(".symbol").innerHTML;
let url = "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=" + String(symbol) + "&apikey=T496J6ATH5QH6NY9";

fetch(url)
	.then(response => response.json())
	.then(data => {

		let dataReceive = [];
		let count = 0;
		for (let key in data['Time Series (Daily)']) {
			if (count < 30) {
				let d = new Date(key);
				d.setDate(d.getDate() + 1);
				dataReceive.push({ x: d, y: [parseFloat(data['Time Series (Daily)'][key]['1. open']), parseFloat(data['Time Series (Daily)'][key]['2. high']), parseFloat(data['Time Series (Daily)'][key]['3. low']), parseFloat(data['Time Series (Daily)'][key]['4. close'])] })
				count++;
			};
		}



		var chart = new CanvasJS.Chart("chartContainer",
			{
				title: {
					text: `${symbol} Stock Prices`
				},
				zoomEnabled: true,
				axisY: {
					includeZero: false,
					title: "Prices",
					prefix: "$ "
				},
				axisX: {
					interval: 2,
					intervalType: "day",
					valueFormatString: "DD-MM-YY",
					labelAngle: -45
				},
				data: [
					{
						type: "candlestick",
						risingColor: "green",
						color: "red",
						dataPoints: dataReceive
					}
				]
			});
		chart.render();			
	});

