import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/weather/presentation/bloc/bloc/weather_bloc_bloc.dart';
import 'package:mobile_assessement/features/weather/presentation/widget/waether_detail.dart';
import 'package:mobile_assessement/features/weather/presentation/widget/weather_row.dart';
import 'package:mobile_assessement/injection/injection.dart';

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text('Weather App'),
        ),
        body: Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
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
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16.0),
            child: TextField(
              decoration: const InputDecoration(
                hintText: 'Search for a city',
                border: OutlineInputBorder(),
              ),
              onSubmitted: (value) {
                BlocProvider.of<WeatherBloc>(context)
                    .add(GetWeatherForCityEvent(cityName: value));
              },
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
            child: BlocBuilder<WeatherBloc, WeatherState>(
              builder: (context, state) {
                if (state is WeatherLoaded) {
                  final weather = state.weather;
                  return WeatherDetail(
                    cityName: weather.cityName,
                    countryName: weather.countryName,
                    temperature: weather.temperature,
                    weatherDescription: weather.weatherDescription,
                  );
                }
                // if (state is FavoriteCitiesLoaded) {
                //   return ListView.builder(
                //     itemCount: state.favoriteCities.length,
                //     itemBuilder: (BuildContext context, int index) {
                //       final city = state.favoriteCities[index];
                //       return GestureDetector(
                //         onTap: () {
                //           Navigator.push(
                //             context,
                //             MaterialPageRoute(
                //               builder: (context) => WeatherDetail(
                //                 cityName: city.name,
                //                 countryName: city.country,
                //                 temperature: city.temperature,
                //                 weatherIcon: city.weatherIcon,
                //               ),
                //             ),
                //           );
                //         },
                //         child: WeatherRow(
                //           cityName: city.name,
                //           countryName: city.country,
                //           temperature: city.temperature,
                //           weatherIcon: city.weatherIcon,
                //         ),
                //       );
                //     },
                //   );
                else if (state is WeatherError) {
                  return Center(
                    child: Text(state.message),
                  );
                } else {
                  return Center(
                    child: CircularProgressIndicator(),
                  );
                }
              },
            ),
          ),
        ]));
  }
}
