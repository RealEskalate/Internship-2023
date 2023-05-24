import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../domain/entities/city_entity.dart';
import '../bloc/favourites/favourite_bloc.dart';
import '../bloc/favourites/favourite_event.dart';
import '../bloc/favourites/favourite_state.dart';

class CityWeatherDetailsPage extends StatelessWidget {
  final City city;

  CityWeatherDetailsPage({required this.city});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Column(
          children: [
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  IconButton(
                    icon: Icon(Icons.arrow_back),
                    onPressed: () {
                      Navigator.pop(context);
                    },
                  ),
                  Text(
                    city.name,
                    style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
                  ),
                  BlocBuilder<FavoritesBloc, FavoritesState>(
                    builder: (context,state) {
                      if (state is FavoritesUpdatedState) {
                        bool isFavorite =
                            state.favoriteCities.contains(city.name);
                        return IconButton(
                          icon: Icon(
                            isFavorite ? Icons.favorite : Icons.favorite_border,
                            color: isFavorite ? Colors.red : Colors.grey,
                          ),
                          onPressed: () {
                            if (isFavorite) {
                              context.read<FavoritesBloc>().add(
                                    RemoveFavoriteCityEvent(
                                        cityName: city.name),
                                  );
                            } else {
                              context.read<FavoritesBloc>().add(
                                    AddFavoriteCityEvent(cityName: city.name),
                                  );
                            }
                          },
                        );
                      } else {
                        return Container();
                      }
                    },
                  ),
                ],
              ),
            ),
            SizedBox(height: 20.0),
            Text(
              city.weathers[0].date,
              style: TextStyle(fontSize: 18.0, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 20.0),
            Expanded(
              child: ListView.builder(
                itemCount: city.weathers.length,
                itemBuilder: (context, index) {
                  final weather = city.weathers[index];
                  return Padding(
                    padding: const EdgeInsets.symmetric(vertical: 8.0, horizontal: 16.0),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Text(
                          weather.date,
                          style: TextStyle(fontSize: 18.0),
                        ),
                        Row(
                          children: [
                            Text(
                             `${weather.maxTempC} / ${weather.minTempC}`,
                              style: TextStyle(
                                fontSize: 18.0,
                                fontWeight: FontWeight.bold,
                              ),
                            ),
                            SizedBox(width: 10.0),
                            Image.network(
                              weather.url,
                              width: 50.0,
                              height: 50.0,
                              fit: BoxFit.cover,
                            ),
                          ],
                        ),
                      ],
                    ),
                  );
                },
              ),
            ),
          ],
        ),
      ),
    );
  }
}