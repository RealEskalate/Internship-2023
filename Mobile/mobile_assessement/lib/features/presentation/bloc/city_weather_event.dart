part of 'city_weather_bloc.dart';

abstract class CityWeatherEvent extends Equatable {
  const CityWeatherEvent();

  @override
  List<Object> get props => [];
}

class Getstarted extends CityWeatherEvent {}

// ignore: must_be_immutable
class SearchEvent extends CityWeatherEvent {
  String cityName;
  SearchEvent({required this.cityName});
}
