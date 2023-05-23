import 'package:mobile_assessement/features/city/domain/entities/city.dart';

class FavouritesState {
  final List<CityWeather> cities;

  FavouritesState({required this.cities});

  factory FavouritesState.initial() {
    return FavouritesState(cities: []);
  }
}
