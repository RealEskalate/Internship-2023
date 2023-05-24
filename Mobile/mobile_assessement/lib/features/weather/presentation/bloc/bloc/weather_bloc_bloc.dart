library weather_bloc;

import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/core/usecase/usecase.dart';
import 'package:mobile_assessement/features/weather/domain/entity/weather.dart';
import 'package:mobile_assessement/features/weather/domain/usecases/add_favorite_city.dart';
import 'package:mobile_assessement/features/weather/domain/usecases/get_city_weather.dart';
import 'package:mobile_assessement/features/weather/domain/usecases/get_favorite_cities.dart';
import 'package:mobile_assessement/features/weather/domain/usecases/remove_favorite_city.dart';

part 'weather_bloc_event.dart';
part 'weather_bloc_state.dart';

class WeatherBloc extends Bloc<WeatherEvent, WeatherState> {
  final GetCityWeather getCityWeather;
  // final AddFavoriteCity addFavoriteCity;
  // final RemoveFavoriteCity removeFavoriteCity;
  // final GetFavoriteCities getFavoriteCities;

  WeatherBloc({
    required this.getCityWeather,
    // required this.addFavoriteCity,
    // required this.removeFavoriteCity,
    // required this.getFavoriteCities,
  }) : super(InitialWeatherState()) {

    on<GetWeatherForCityEvent>((event, emit) async {
      
      emit(WeatherLoading());
      final cityWeatherEither = await getCityWeather(event.cityName);
      emit(cityWeatherEither.fold(
        (failure) => WeatherError(message: _mapFailureToMessage(failure)),
        (cityWeather) => WeatherLoaded(weather: cityWeather),
      ));
    });

    // on<AddFavoriteCityEvent>((event, emit) async {
    //   await addFavoriteCity(event.cityName);
    //   final favoriteCities = await getFavoriteCities(NoParams());

    //   emit(favoriteCities.fold(
    //     (failure) => WeatherError(message: _mapFailureToMessage(failure)),
    //     (favoriteCitie) => FavoriteCitiesLoaded(favoriteCities: favoriteCitie),
    //   ));
    // });

    // on<RemoveFavoriteCityEvent>((event, emit) async {
    //   await removeFavoriteCity(event.cityName);
    //   final favoriteCities = await getFavoriteCities(NoParams());

    //    emit(favoriteCities.fold(
    //     (failure) => WeatherError(message: _mapFailureToMessage(failure)),
    //     (favoriteCitie) => FavoriteCitiesLoaded(favoriteCities: favoriteCitie),
    //   ));
    // });

    // on<GetFavoriteCitiesEvent>((event, emit) async {
    //   final favoriteCities = await getFavoriteCities(NoParams());

    //   emit(favoriteCities.fold(
    //     (failure) => WeatherError(message: _mapFailureToMessage(failure)),
    //     (favoriteCitie) => FavoriteCitiesLoaded(favoriteCities: favoriteCitie),
    //   ));
    // });
  }

  String _mapFailureToMessage(Failure failure) {
    switch (failure.runtimeType) {
      case ServerFailure:
        return 'Server Failure';
      case UnknownFailure:
        return 'Unknown Failure';
      default:
        return 'Unexpected Error';
    }
  }
}