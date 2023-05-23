import 'city.dart';

class Favourite {
  final List<CityWeather> cities;

  const Favourite({required this.cities});

  void addCity(CityWeather city) {
    cities.add(city);
  }
}
