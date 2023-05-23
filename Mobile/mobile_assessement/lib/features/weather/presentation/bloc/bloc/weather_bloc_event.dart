part of weather_bloc;

abstract class WeatherEvent extends Equatable {
  const WeatherEvent();

  @override
  List<Object> get props => [];
}

class GetWeatherForCityEvent extends WeatherEvent {
  final String cityName;

  const GetWeatherForCityEvent({required this.cityName});

  @override
  List<Object> get props => [cityName];
}

class AddFavoriteCityEvent extends WeatherEvent {
  final String cityName;

  const AddFavoriteCityEvent({required this.cityName});

  @override
  List<Object> get props => [cityName];
}

class RemoveFavoriteCityEvent extends WeatherEvent {
  final String cityName;

  const RemoveFavoriteCityEvent({required this.cityName});

  @override
  List<Object> get props => [cityName];
}

class GetFavoriteCitiesEvent extends WeatherEvent {
  const GetFavoriteCitiesEvent();

  @override
  List<Object> get props => [];
}