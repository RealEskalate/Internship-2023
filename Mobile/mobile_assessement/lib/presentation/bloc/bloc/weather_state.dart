



import 'package:equatable/equatable.dart';

import '../../../core/error_handle/failure.dart';
import '../../../domain/Entity/weather_entity.dart';

abstract class WeatherDataState extends Equatable {
  const WeatherDataState();

  @override
  List<Object> get props => [];
}

class WeatherDataLoading extends WeatherDataState {}

class WeatherDataInitial extends WeatherDataState {}
class WeatherDataLoaded extends WeatherDataState {
  final WeatherEntity  weather ;

  const WeatherDataLoaded({required this.weather});

  @override
  List<Object> get props => [weather];
}

class WeatherDataFailure extends WeatherDataState {
  final Failure error;

  const WeatherDataFailure({required this.error});

  @override
  List<Object> get props => [error];
}
