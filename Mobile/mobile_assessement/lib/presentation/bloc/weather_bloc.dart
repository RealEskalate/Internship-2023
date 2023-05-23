import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';
import 'package:mobile_assessement/domain/usecase/get_weather_by_city.dart';

import '../../core/errors/failur.dart';
import '../../domain/entities/weather.dart';

part 'weather_event.dart';
part 'weather_state.dart';

class WeatherBloc extends Bloc<WeatherEvent, WeatherState> {
  final GetWeatherByCity getWeatherByCity;

  WeatherBloc({
    required this.getWeatherByCity,
  }) : super(WeatherInitial()) {
    on<SearchEvent>(_search);
  }

  void _search(SearchEvent event, Emitter<WeatherState> emit) async {
    emit(WeatherLoading());
    final result = await getWeatherByCity(event.query);
    emit(_searchSuccessOrFailure(result));
  }

  WeatherState _searchSuccessOrFailure(Either<Failure, Weather> data) {
    return data.fold(
      (failure) => WeatherFailure(error: failure),
      (success) => WeatherLoaded(weather: success),
    );
  }

  @override
  Stream<WeatherState> mapEventToState(WeatherEvent event) async* {
    if (event is SearchEvent) {
      yield WeatherLoading();
      try {
        final result = await getWeatherByCity(event.query);
        yield _searchSuccessOrFailure(result);
      } catch (error) {
        yield WeatherFailure(
            error: ServerFailure('Failed to fetch weather data.'));
      }
    }
  }
}
