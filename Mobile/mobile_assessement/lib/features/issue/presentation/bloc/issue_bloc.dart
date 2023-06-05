import 'dart:async';

import 'package:dartz/dartz.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile_assessement/features/weather/domain/usecases/get_weather.dart';

import '../../../../core/errors/failures.dart';
import '../../domain/entities/weather.dart';

part 'weather_event.dart';
part 'weather_state.dart';

class WeatherBloc extends Bloc<WeatherEvent, WeatherState> {
  final GetWeather getWeather;

  WeatherState weatherSuccessOrFailure(Either<Failure, Weather> data) {
    return data.fold(
      (failure) => WeatherFailureState(error: failure),
      (success) => WeatherSuccessState(weather: success),
    );
  }

  WeatherBloc({required this.getWeather}) : super(WeatherInitialState()) {
    on<GetWeatherEvent>(_getWeather);
  }

  FutureOr<void> _getWeather(
      GetWeatherEvent event, Emitter<WeatherState> emit) async {
    print("bloc is done");
    emit(WeatherLoadingState());
    final result = await getWeather(event.cityName);
    emit(weatherSuccessOrFailure(result));
  }
}