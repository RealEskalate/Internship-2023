import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:get_it/get_it.dart';
import 'package:mobile_assessement/injection.dart';

import '../../domain/entities/weather.dart';
import '../bloc/weather_bloc.dart';

class Detail extends StatelessWidget {
  final String query;

  const Detail({required this.query});

  @override
  Widget build(BuildContext context) {
    final weatherBloc = WeatherBloc(getWeatherByCity: locator()); // Retrieve WeatherBloc instance from GetIt

    return Scaffold(
      backgroundColor: Color(0xFFF1F1F2),
      appBar: AppBar(
        leading: IconButton(
          icon: Icon(Icons.arrow_back),
          onPressed: () {
            Navigator.pop(context);
          },
        ),
      ),
      body: BlocProvider.value(
        value: weatherBloc,
        child: BlocBuilder<WeatherBloc, WeatherState>(
          builder: (context, state) {
            if (state is WeatherLoading) {
              return Center(
                child: CircularProgressIndicator(),
              );
            } else if (state is WeatherLoaded) {
              final Weather weather = state.weather;

              return Padding(
                padding: const EdgeInsets.all(16.0),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Text(
                      query,
                      style:
                          TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                    ),
                    SizedBox(height: 20),
                    Text(
                      'Temperature: ${weather.temperature}',
                      style: TextStyle(fontSize: 16),
                    ),
                  ],
                ),
              );
            } else if (state is WeatherFailure) {
              return Center(
                child: Text('Failed to fetch weather data.'),
              );
            } else {
              return SizedBox.shrink();
            }
          },
        ),
      ),
    );
  }
}
