import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/core/utils/constants/global_variables.dart';

import '../../domain/entities/city.dart';
import '../bloc/favourites/favourite_bloc.dart';
import '../bloc/favourites/favourite_event.dart';
import '../bloc/favourites/favourite_state.dart';

class SearchPage extends StatefulWidget {
  @override
  _SearchPageState createState() => _SearchPageState();
}

class _SearchPageState extends State<SearchPage> {
  TextEditingController _searchController = TextEditingController();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        children: [
          Stack(
            children: [
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: TextField(
                  controller: _searchController,
                  decoration: InputDecoration(
                    labelText: 'Search',
                    border: OutlineInputBorder(),
                  ),
                ),
              ),
              Positioned(
                top: 15.0,
                right: 8.0,
                child: ElevatedButton(
                  onPressed: () {
                    // Handle search button press here
                    String searchText = _searchController.text;
                    // Do something with the search text...
                  },
                  child: Icon(
                    Icons.search,
                    color: primaryButtonColor,
                  ),
                ),
              ),
            ],
          ),
          BlocBuilder<FavouritesBloc, FavouritesState>(
            builder: (context, state) {
              return Expanded(
                child: ListView.builder(
                  itemCount: state.cities.length,
                  itemBuilder: (BuildContext context, int index) {
                    final city = state.cities[index];
                    return ListTile(
                      leading: Text(city.cityName),
                      title: Text(city.avgTempc.toString()),
                      trailing: IconButton(
                        icon: Icon(Icons.favorite),
                        color: Colors.red,
                        onPressed: () {
                          context.read<FavouritesBloc>().add(
                                RemoveCityFromFavourites(city: city),
                              );
                        },
                      ),
                    );
                  },
                ),
              );
            },
          ),
        ],
      ),
    );
  }

  void _search() {
    // String query = _searchController.text;
    // if (query.isNotEmpty) {
    //   // List<CityWeather> cities =
    //   //     _getCities(); // replace with API call or local data source
    //   List<CityWeather> filteredCities = cities
    //       .where((city) =>
    //           city.cityName.toLowerCase().contains(query.toLowerCase()))
    //       .toList();
    //   setState(() {
    //     // _searchResults = filteredCities;
    //   });
    // }
  }
}
