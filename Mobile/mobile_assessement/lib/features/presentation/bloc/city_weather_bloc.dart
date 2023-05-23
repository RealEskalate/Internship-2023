import 'package:bloc/bloc.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile_assessement/features/domain/entity/city_weather_entity.dart';

import '../../../core/error/failures.dart';
import '../../domain/usecase/get_city_weather.dart';

part 'city_weather_event.dart';
part 'city_weather_state.dart';

class CityWeatherBloc extends Bloc<CityWeatherEvent, CityWeatherState> {
  final GetCityWeatherUseCase getCityWeather;

  CityWeatherBloc(this.getCityWeather) : super(CityWeatherInitial()) {
    on<SearchEvent>(_onSearchEvent);
  }

  void _onSearchEvent(SearchEvent event, Emitter<CityWeatherState> emit) async {
    emit(Loadingstate());

    final failureorCityWeather = await getCityWeather(event.cityName);

    emit(_loginOrFailure(failureorCityWeather));
  }

  CityWeatherState _loginOrFailure(Either<Failure, CityWeather> both) {
    return both.fold(
      (failure) => FailedState(),
      (cityWeather) => LoadedState(
          cityName: cityWeather.cityName,
          temperature: cityWeather.temperature,
          humidity: cityWeather.humidity,
          weatherDescription: cityWeather.weatherDescription),
    );
  }
}
