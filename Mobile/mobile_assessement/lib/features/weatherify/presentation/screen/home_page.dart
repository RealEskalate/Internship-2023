import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/weatherify/presentation/screen/detail_page.dart';

import '../bloc/bloc/weather_bloc.dart';

class HomePage extends StatelessWidget {
  final TextEditingController _searchController = TextEditingController();
  
  @override
  Widget build(BuildContext context) {
    return BlocBuilder<WeatherBloc, WeatherState>(
      builder: (context, state) {
        return Scaffold(
          appBar: AppBar(
            title: Text('Choose a city'),
            centerTitle: true,
          ),
          body: Column(
            children: [
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: Row(
                  children: [
                    Expanded(
                      child: TextField(
                        controller: _searchController,
                        decoration: InputDecoration(
                          hintText: 'Search',
                          prefixIcon: Icon(Icons.search),
                          border: OutlineInputBorder(
                            borderRadius: BorderRadius.circular(10),
                          ),
                        ),
                      ),
                    ),
                    SizedBox(width: 10),
                    ElevatedButton(
                      child: Text('Search'),
                      onPressed: () {
                        String searchText = _searchController.text;

                        (context).read<WeatherBloc>().add(GetWeatherEvent( city: searchText));
                        // Do something with searchText
                      },
                    ),
                  ],
                ),
              ),
              state is WeatherLoaded
                  ? ListTile(
                      onTap: () {
                        Navigator.push(
                            context,
                            MaterialPageRoute(
                                builder: (context) =>
                                    DetailPage(weather: state.weather)));
                      },
                      leading: Text(state.weather.cityName),
                      trailing: Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          Text('${state.weather.maxtemperature}°C'),
                          SizedBox(height: 5),
                          // Image.network(cities[index].photoUrl),
                        ],
                      ),
                    )
                  : Text("City not found"),
            ],
          ),
        );
      },
    );
  }
}