import 'package:flutter/material.dart';

class WeatherDetail extends StatelessWidget {
  final String cityName;
  final String countryName;
  final double temperature;
  final IconData weatherIcon;

  const WeatherDetail({
    Key? key,
    required this.cityName,
    required this.countryName,
    required this.temperature,
    required this.weatherIcon,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(cityName),
      ),
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: [
          Container(
            padding: const EdgeInsets.all(16.0),
            color: Colors.blue,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  '$cityName, $countryName',
                  style: const TextStyle(
                    fontSize: 24.0,
                    fontWeight: FontWeight.bold,
                    color: Colors.white,
                  ),
                ),
                const SizedBox(height: 16.0),
                Row(
                  children: [
                    Icon(
                      weatherIcon,
                      color: Colors.white,
                      size: 64.0,
                    ),
                    const SizedBox(width: 16.0),
                    Text(
                      'Mostly Sunny',
                      style: const TextStyle(
                        fontSize: 24.0,
                        fontWeight: FontWeight.bold,
                        color: Colors.white,
                      ),
                    ),
                  ],
                ),
                const SizedBox(height: 16.0),
                Text(
                  '${temperature.toStringAsFixed(0)}°C',
                  style: const TextStyle(
                    fontSize: 48.0,
                    fontWeight: FontWeight.bold,
                    color: Colors.white,
                  ),
                ),
              ],
            ),
          ),
          Expanded(
            child: ListView.builder(
              itemCount: 7, // Replace with actual number of days
              itemBuilder: (BuildContext context, int index) {
                return ListTile(
                  leading: Icon(Icons.cloud),
                  title: Text('Day ${index + 1}'),
                  subtitle: Text('XX°C'),
                );
              },
            ),
          ),
        ],
      ),
    );
  }
}