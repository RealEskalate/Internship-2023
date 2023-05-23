import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/weather/presentation/bloc/bloc/weather_bloc_bloc.dart';
import 'package:mobile_assessement/features/weather/presentation/widget/waether_detail.dart';
import 'package:mobile_assessement/features/weather/presentation/widget/weather_row.dart';
import 'package:mobile_assessement/injection/injection.dart';

class HomePage extends StatelessWidget {

  @override
  Widget build(BuildContext context) {
    return BlocProvider<WeatherBloc>(
        create: (_) => sl<WeatherBloc>()..add(const GetFavoriteCitiesEvent()),
        child: Scaffold(
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
              builder: (context) => const WeatherDetail(
                cityName: 'City Name',
                countryName: 'Country Name',
                temperature: 25.0, // Replace with actual temperature
                weatherIcon: Icons.cloud,
              ),
            ),
          );
        },
        child: const WeatherRow(
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
    ));
  }
}