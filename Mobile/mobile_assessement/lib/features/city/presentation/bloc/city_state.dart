import 'package:mobile_assessement/features/city/domain/entities/city.dart';

abstract class CityState {}

class CityInitial extends CityState {}

class CityLoading extends CityState {}

class CityLoaded extends CityState {
  final CityWeather cities;

  CityLoaded({required this.cities});
}

class CityError extends CityState {
  final String message;

  CityError({required this.message});
}
