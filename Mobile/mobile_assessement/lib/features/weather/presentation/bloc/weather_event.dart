import 'package:equatable/equatable.dart';

abstract class WeatherEvent extends Equatable {
  @override
  List<Object?> get props => [];
}

class UpdateCityName extends WeatherEvent {
  final String cityName;

  UpdateCityName(this.cityName);

  @override
  List<Object?> get props => [cityName];
}

class UpdateFavorite extends WeatherEvent {
  final bool isFavorite;

  UpdateFavorite(this.isFavorite);

  @override
  List<Object?> get props => [isFavorite];
}

class Submitted extends WeatherEvent {
  dynamic weather;
  Submitted({required this.weather});
}
