// !----------
// !it will give hyderabad weather condition
// // City coordinates (Example: Hyderabad)
// const latitude = 17.3850;
// const longitude = 78.4867;

// // API URL
// const API_URL = `https://api.open-meteo.com/v1/forecast?latitude=${latitude}&longitude=${longitude}&current_weather=true`;



// /* Using Promises   */


// const fetchWeatherWithPromises = () => {
//   fetch(API_URL)
//     .then(response => {
//       if (!response.ok) {
//         throw new Error("Failed to fetch weather data");
//       }
//       return response.json();
//     })
//     .then(data => {
//       const weather = data.current_weather;

//       console.log(`
// Weather Report (Using Promises)
// -----------------------------------
// Temperature: ${weather.temperature}°C
// Wind Speed: ${weather.windspeed} km/h
// Weather Code: ${weather.weathercode}
//       `);
//     })
//     .catch(error => {
//       console.error("Error:", error.message);
//     });
// };



// //  Using Async / Await   


// const fetchWeatherWithAsync = async () => {
//   try {
//     const response = await fetch(API_URL);

//     if (!response.ok) {
//       throw new Error("Failed to fetch weather data");
//     }

//     const data = await response.json();
//     const weather = data.current_weather;

//     console.log(`
// Weather Report (Using Async/Await)
// ---------------------------------------
// Temperature: ${weather.temperature}°C
// Wind Speed: ${weather.windspeed} km/h
// Weather Code: ${weather.weathercode}
//     `);

//   } catch (error) {
//     console.error("Error:", error.message);
//   }
// };


// // Call both versions
// fetchWeatherWithPromises();
// fetchWeatherWithAsync();

// !-----------------------
// ! dynamic input by searching place it will give weather conditon

const city = prompt("Enter city name:");

const fetchWeather = async (cityName) => {
  try {
    // Get latitude & longitude
    const geoResponse = await fetch(
      `https://geocoding-api.open-meteo.com/v1/search?name=${cityName}&count=1`
    );

    if (!geoResponse.ok) {
      throw new Error("Failed to fetch location data");
    }

    const geoData = await geoResponse.json();

    if (!geoData.results || geoData.results.length === 0) {
      throw new Error("City not found");
    }

    const { latitude, longitude, name, country } = geoData.results[0];

    // Fetch weather
    const weatherResponse = await fetch(
      `https://api.open-meteo.com/v1/forecast?latitude=${latitude}&longitude=${longitude}&current_weather=true`
    );

    if (!weatherResponse.ok) {
      throw new Error("Failed to fetch weather data");
    }

    const weatherData = await weatherResponse.json();
    const weather = weatherData.current_weather;

    console.log(`
Weather Report
-----------------------
Location: ${name}, ${country}
Temperature: ${weather.temperature}°C
Wind Speed: ${weather.windspeed} km/h
Weather Code: ${weather.weathercode}
    `);

  } catch (error) {
    console.error("Error:", error.message);
  }
};

fetchWeather(city);