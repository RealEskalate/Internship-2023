

import 'package:flutter/material.dart';

class WeatherRow extends StatelessWidget {
  final String cityName;
  final String countryName;
  final double temperature;
  final IconData weatherIcon;

  const WeatherRow({
    Key? key,
    required this.cityName,
    required this.countryName,
    required this.temperature,
    required this.weatherIcon,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 8.0),
      child: Row(
        children: [
          Icon(weatherIcon, size: 32.0),
          const SizedBox(width: 16.0),
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                cityName,
                style: const TextStyle(fontSize: 18.0, fontWeight: FontWeight.bold),
              ),
              Text(
                countryName,
                style: const TextStyle(fontSize: 14.0),
              ),
            ],
          ),
          const Spacer(),
          Text(
            '${temperature.toStringAsFixed(0)}°C',
            style: const TextStyle(fontSize: 18.0, fontWeight: FontWeight.bold),
          ),
        ],
      ),
    );
  }
}