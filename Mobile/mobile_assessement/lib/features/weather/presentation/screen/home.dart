import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/weather/presentation/widget/waether_detail.dart';
import 'package:mobile_assessement/features/weather/presentation/widget/weather_row.dart';

class HomePage extends StatelessWidget {

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Weather App'),
      ),
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const Padding(
            padding: EdgeInsets.all(16.0),
            child: Text(
              'Today',
              style: TextStyle(
                fontSize: 24.0,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 16.0),
            child: TextField(
              decoration: InputDecoration(
                hintText: 'Search for a city',
                border: OutlineInputBorder(),
              ),
            ),
          ),
          const Padding(
            padding: EdgeInsets.all(16.0),
            child: Text(
              'My Cities',
              style: TextStyle(
                fontSize: 20.0,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
Expanded(
  child: ListView.builder(
    itemCount: 5, // Replace with actual number of cities
    itemBuilder: (BuildContext context, int index) {
      return GestureDetector(
        onTap: () {
          Navigator.push(
            context,
            MaterialPageRoute(
              builder: (context) => WeatherDetail(
                cityName: 'City Name',
                countryName: 'Country Name',
                temperature: 25.0, // Replace with actual temperature
                weatherIcon: Icons.cloud,
              ),
            ),
          );
        },
        child: WeatherRow(
          cityName: 'City Name',
          countryName: 'Country Name',
          temperature: 25.0, // Replace with actual temperature
          weatherIcon: Icons.cloud,
        ),
      );
    },
  ),
),

        ],
      ),
    );
  }
}