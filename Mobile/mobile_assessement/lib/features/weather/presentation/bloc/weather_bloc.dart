import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/weather/domain/entity/weather.dart';
import 'package:mobile_assessement/features/weather/presentation/bloc/weather_event.dart';
import 'package:mobile_assessement/features/weather/presentation/bloc/weather_search_status.dart';
import 'package:mobile_assessement/features/weather/presentation/bloc/weather_state.dart';

class WeatherBloc extends Bloc<WeatherEvent, WeatherState> {
  WeatherBloc()
      : super(WeatherState(formSubmittionStatus: const InititalStatus())) {
    on<UpdateCityName>((event, emit) {
      emit(state.copyWith(cityName: event.cityName));
    });
    on<UpdateFavorite>((event, emit) {
      emit(state.copyWith(isFavorite: event.isFavorite));
    });
    on<Submitted>((event, emit) {
      emit(state.copyWith(
          formSubmittionStatus: const SuccessStatus(), weather: event.weather as Weather));
    });
  }
}
