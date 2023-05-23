
import 'package:flutter/material.dart';

class CityOne {
  String name;
  double averageTemperature;
  IconData weatherIcon;

  CityOne({required this.name, required this.averageTemperature, required this.weatherIcon});
}

class WeatherDay {
  String date;
  double minTemperature;
  double maxTemperature;
  IconData weatherIcon;

  WeatherDay({
    required this.date,
    required this.minTemperature,
    required this.maxTemperature,
    required this.weatherIcon,
  });
}

class WeatherDetailScreen extends StatelessWidget {
  final CityOne city;
  final List<WeatherDay> weatherForecast;

  WeatherDetailScreen({required this.city, required this.weatherForecast});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Weather Details'),
      ),
      body: SingleChildScrollView(
        child: Padding(
          padding: EdgeInsets.all(16.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Row(
                children: [
                  IconButton(
                    icon: Icon(Icons.arrow_back),
                    onPressed: () {
                      Navigator.pop(context);
                    },
                  ),
                  Expanded(
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text(
                          city.name,
                          style: TextStyle(fontSize: 24.0, fontWeight: FontWeight.bold),
                        ),
                        Text(
                          'Date: ${DateTime.now().toString().substring(0, 10)}',
                          style: TextStyle(fontSize: 16.0),
                        ),
                      ],
                    ),
                  ),
                  IconButton(
                    icon: Icon(Icons.favorite),
                    onPressed: () {
                      // Handle favorite button press
                    },
                  ),
                ],
              ),
              SizedBox(height: 16.0),
              Image.asset(
                "assets/images/rainy_lightning_windy_sunny.png", // Replace with your weather image asset
                height: 100.0,
                width: 100.0,
              ),
              SizedBox(height: 8.0),
              Text(
                'Weather Description', // Replace with your weather description
                style: TextStyle(fontSize: 16.0),
              ),
              SizedBox(height: 16.0),
              Text(
                'Average Temperature: ${city.averageTemperature}°C',
                style: TextStyle(fontSize: 16.0),
              ),
              SizedBox(height: 16.0),
              Text(
                'Weather Forecast',
                style: TextStyle(fontSize: 20.0, fontWeight: FontWeight.bold),
              ),
              SizedBox(height: 16.0),
              ListView.builder(
                shrinkWrap: true,
                physics: NeverScrollableScrollPhysics(),
                itemCount: weatherForecast.length,
                itemBuilder: (context, index) {
                  final weatherDay = weatherForecast[index];
                  return GestureDetector(
                    child: Card(
                      child: ListTile(
                        title: Row(
                          children: [
                            Text(weatherDay.date),
                            SizedBox(width: 8.0),
                            Icon(weatherDay.weatherIcon),
                          ],
                        ),
                        subtitle: Text(
                          'Min Temp: ${weatherDay.minTemperature}°C   Max Temp: ${weatherDay.maxTemperature}°C',
                        ),
                      ),
                    ),

                    
                  );
                },
              ),
            ],
          ),
        ),
      ),
    );
  }
}

// void main() {
//   runApp(MaterialApp(
//     title: 'Weather App',
//     home: WeatherDetailScreen(
//       city: City(name: 'New York', averageTemperature: 25.0, weatherIcon: Icons.wb_sunny),
//       weatherForecast: [
//         WeatherDay(date: '2023-05-23', minTemperature: 20.0, maxTemperature: 30.0, weatherIcon: Icons.wb_sunny),
//         WeatherDay(date: '2023-05-24', minTemperature: 18.0, maxTemperature: 28.0, weatherIcon: Icons.cloud),
//         WeatherDay(date: '2023-05-25', minTemperature: 22.0, maxTemperature: 32.0, weatherIcon: Icons.wb_sunny),
//       ],
//     ),
//   ));
// }
