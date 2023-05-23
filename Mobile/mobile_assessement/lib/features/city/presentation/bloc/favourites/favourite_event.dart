import 'package:mobile_assessement/features/city/domain/entities/city.dart';

abstract class FavouritesEvent {}

class AddCityToFavourites extends FavouritesEvent {
  final CityWeather city;

  AddCityToFavourites({required this.city});
}

class RemoveCityFromFavourites extends FavouritesEvent {
  final CityWeather city;

  RemoveCityFromFavourites({required this.city});
}
