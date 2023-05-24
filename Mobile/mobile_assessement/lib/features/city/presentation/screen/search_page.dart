import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/city/presentation/screen/weather_detail_screen.dart';

import '../../domain/entities/city_entity.dart';
import '../bloc/search/seach_bloc.dart';
import '../bloc/search/search_event.dart';
import '../bloc/search/search_state.dart';

class SearchPage extends StatefulWidget {
  @override
  _SearchPageState createState() => _SearchPageState();
}

class _SearchPageState extends State<SearchPage> {
  TextEditingController _searchController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Container(
          decoration: BoxDecoration(
            color: Colors.white,
            borderRadius: BorderRadius.circular(10.0),
          ),
          child: TextField(
            controller: _searchController,
            decoration: InputDecoration(
              hintText: "Search city",
              prefixIcon: Icon(Icons.search),
              border: InputBorder.none,
              contentPadding:
                  const EdgeInsets.symmetric(vertical: 12.0, horizontal: 16.0),
            ),
            onChanged: (value) {
              if (value.isNotEmpty) {
                BlocProvider.of<SearchBloc>(context)
                    .add(SearchCityEvent(cityName: value));
              }
            },
          ),
        ),
        backgroundColor: Colors.transparent,
        elevation: 0.0,
      ),
      body: BlocBuilder<SearchBloc, SearchState>(
        builder: (context, state) {
          if (state is SearchInitialState) {
            // Show favorite city weather tile when there's nothing written on the search page
            return _buildFavoriteCityWeatherTile(context);
          } else if (state is SearchLoadingState) {
            return Center(child: CircularProgressIndicator());
          } else if (state is SearchSuccessState) {
            return _buildCityWeatherDetails(state.city);
          } else if (state is SearchFailureState) {
            return Center(child: Text("Error: ${state.error}"));
          }
          return SizedBox.shrink();
        },
      ),
    );
  }

  Widget _buildFavoriteCityWeatherTile(BuildContext context) {
    // Replace "New York" with your favorite city
    return ListTile(
      title: Text("New York"),
      onTap: () {
        _searchController.text = "New York";
        BlocProvider.of<SearchBloc>(context)
            .add(SearchCityEvent(cityName: "New York"));
      },
    );
  }

  Widget _buildCityWeatherDetails(City city) {
    final weather = city.weathers[0];
    return ListTile(
      title: Text(city.name),
      subtitle: Text(weather.avgTempC),
      leading: Image.network(
        weather.url,
        width: 50.0,
        height: 50.0,
        fit: BoxFit.cover,
      ),
      onTap: () {
        Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) => CityWeatherDetailsPage(city: city),
          ),
        );
      },
    );
  }
}
