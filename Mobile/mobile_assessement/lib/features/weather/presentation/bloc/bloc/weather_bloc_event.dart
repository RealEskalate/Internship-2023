part of weather_bloc;

abstract class WeatherEvent extends Equatable {
  const WeatherEvent();

  @override
  List<Object> get props => [];
}

class GetWeatherForCity extends WeatherEvent {
  final String cityName;

  const GetWeatherForCity({required this.cityName});

  @override
  List<Object> get props => [cityName];
}

class AddFavoriteCity extends WeatherEvent {
  final String cityName;

  const AddFavoriteCity({required this.cityName});

  @override
  List<Object> get props => [cityName];
}

class RemoveFavoriteCity extends WeatherEvent {
  final String cityName;

  const RemoveFavoriteCity({required this.cityName});

  @override
  List<Object> get props => [cityName];
}

class GetFavoriteCities extends WeatherEvent {
  const GetFavoriteCities();

  @override
  List<Object> get props => [];
}