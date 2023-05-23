part of weather_bloc;



abstract class WeatherState extends Equatable {
  const WeatherState();

  @override
  List<Object> get props => [];
}

class InitialWeatherState extends WeatherState {}

class WeatherLoading extends WeatherState {}

class WeatherLoaded extends WeatherState {
  final CityWeather weather;

  const WeatherLoaded({required this.weather});

  @override
  List<Object> get props => [weather];
}

class WeatherError extends WeatherState {
  final String message;

  const WeatherError({required this.message});

  @override
  List<Object> get props => [message];
}

class FavoriteCitiesLoaded extends WeatherState {
  final List<String> favoriteCities;

  const FavoriteCitiesLoaded({required this.favoriteCities});

  @override
  List<Object> get props => [favoriteCities];
}