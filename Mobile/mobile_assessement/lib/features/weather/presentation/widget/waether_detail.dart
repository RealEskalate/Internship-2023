import 'package:flutter/material.dart';

class WeatherDetail extends StatelessWidget {
  final String cityName;
  final String countryName;
  final double temperature;
  final String weatherDescription;


  const WeatherDetail({
    Key? key,
    required this.cityName,
    required this.countryName,
    required this.temperature,
  required this.weatherDescription,
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
                    const Icon(
                      Icons.add,
                      color: Colors.white,
                      size: 64.0,
                    ),
                    const SizedBox(width: 16.0),
                    const Text(
                      'Mostly Sunny',
                      style: TextStyle(
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
                  leading: const Icon(Icons.cloud),
                  title: Text('Day ${index + 1}'),
                  subtitle: const Text('XX°C'),
                );
              },
            ),
          ),
        ],
      ),
    );
  }
}
