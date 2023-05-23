import 'package:bloc/bloc.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile_assessement/features/weatherify/domain/entities/weather.dart';
import 'package:mobile_assessement/features/weatherify/domain/usecases/search_city.dart';
import '../../../../core/errors/failure.dart';
part 'weatherify_state.dart';
part 'weatherify_event.dart';

class WeatherBloc extends Bloc<WeatherifyEvent, WeatherifyState> {
  final SearchCity searchCity;

  WeatherBloc({required this.searchCity}) : super(WeatherInitial()) {
    on<SearchWeatherEvent>(_searchCity);
  }

  void _searchCity(
      SearchWeatherEvent event, Emitter<WeatherifyState> emit) async {
    emit(WeatherLoading());

    final result = await searchCity(event.cityName);

    emit(_searchSuccessOrFailure(result));
  }

  WeatherifyState _searchSuccessOrFailure(Either<Failure, Weather> data) {
    return data.fold((failure) => WeatherFailed(failure: failure),
        (success) => WeatherLoaded(weather: success));
  }
}
