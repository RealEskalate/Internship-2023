import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/weather_forcast/domain/usecases/get_current_weather.dart';
import 'package:mobile_assessement/features/weather_forcast/presentation/bloc/weather_event.dart';
import 'package:mobile_assessement/features/weather_forcast/presentation/bloc/weather_state.dart';

import '../../domain/usecases/get_weather_forcast.dart';

class WeatherBloc extends Bloc<WeatherEvent, WeatherState> {
 final GetCurrentWeather getCurrentWeather;
 final GetWeatherForecast getWeatherForecast;

 WeatherBloc({
 required this.getCurrentWeather,
 required this.getWeatherForecast,
 }) : super(WeatherInitial()) {
 on<GetCurrentWeatherEvent>(_mapGetCurrentWeatherEventToState);
 on<GetWeatherForecastEvent>(_mapGetWeatherForecastEventToState);
 }

 void _mapGetCurrentWeatherEventToState(
 GetCurrentWeatherEvent event, Emitter<WeatherState> emit) async {
 emit(WeatherLoading());
 final failureOrCurrentWeather =
 await getCurrentWeather(event.city);
 emit(failureOrCurrentWeather.fold(
 (failure) => WeatherError(failure),
 (currentWeather) => WeatherLoaded(currentWeather, null)));
 }

 void _mapGetWeatherForecastEventToState(
 GetWeatherForecastEvent event, Emitter<WeatherState> emit) async {
 emit(WeatherLoading());
 final failureOrForecast = await getWeatherForecast(event.city);
 emit(failureOrForecast.fold(
 (failure) => WeatherError(failure),
 (forecast) => WeatherLoaded(null, forecast)));
 }
}
