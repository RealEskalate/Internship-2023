import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';

import '../../domain/entities/city_weather.dart';
import '../../domain/usecases/weather_usecase.dart';

part 'weather_event.dart';
part 'weather_state.dart';

class WeatherBloc extends Bloc<WeatherEvent, WeatherState> {
  GetCityWeather getCityWeather;
  WeatherBloc(this.getCityWeather) : super(WeatherInitial()) {
    on<SearchCityEvent>(_onSearchCity);
  }

  void _onSearchCity(SearchCityEvent event, Emitter emit) async {
    emit(SearchLoadingState());

    final failureOrDetail = await getCityWeather(Params(cityName: event.query));

     emit(_detailOrFailure(failureOrDetail));
  }
  _detailOrFailure(both){
    return both.fold(
      (failure) => SearchFailureState(),
      (detail) => SearchSuccessState(detail),
    );
  }
}
