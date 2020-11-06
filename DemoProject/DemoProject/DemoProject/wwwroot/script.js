

window.getSimpleString = (name) => {
	return 'hallo daar ' + name + '!';
};




window.getLocationForBlazor = () => {
	console.log('Hallo vanuit getLocationForBlazor');
	return new Promise((resolve, reject) => {
		console.log('Async werk starten');
		navigator.geolocation.getCurrentPosition(
			pos => {
				console.log('Locatie te pakken!');
				resolve({
					Latitude: pos.coords.latitude,
					Longitude: pos.coords.longitude,
					Accuracy: pos.coords.accuracy,
				});
			},
			err => {
				console.log('Locatie nogo');
				reject(err);
			}
		);
	});
};