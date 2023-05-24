import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/weather/presentation/bloc/bloc/weather_bloc_bloc.dart';
import 'package:mobile_assessement/features/weather/presentation/widget/weather_detail.dart';
import 'package:mobile_assessement/features/weather/presentation/widget/weather_row.dart';
import 'package:mobile_assessement/injection/injection.dart';

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text('Choose a city'),
          backgroundColor: Color(0xFF3B7DE3),
        ),
        body: Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16.0),
            child: TextField(
              decoration: InputDecoration(
                hintText: 'Search for a city',
                border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(30),
                ),
                focusedBorder: OutlineInputBorder(
                  borderSide: BorderSide(color: Color(0xFF3B7DE3)),
                  borderRadius: BorderRadius.circular(30),
                ),
                prefixIcon: Icon(Icons.search),
                contentPadding:
                    EdgeInsets.symmetric(vertical: 12, horizontal: 16),
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
            child: BlocConsumer<WeatherBloc, WeatherState>(
              listener: (context, state) {
                if (state is WeatherLoaded){
    Navigator.push(context, MaterialPageRoute(
                                builder: (context) =>  WeatherDetail(

                    cityName: state.weather.cityName,
                  
                    temperature: state.weather.temperature,
                    weatherDescription: state.weather.weatherDescription,
                  )));

                }
        },
         
              builder: (context, state) {
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
                if (state is WeatherError) {
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
          
       ) ]));
  }
}
